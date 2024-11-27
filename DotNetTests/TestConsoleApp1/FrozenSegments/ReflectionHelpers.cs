
using System.Reflection.Emit;
using System.Reflection;
using System;
using System.Linq;
using System.Text;

namespace TestConsoleApp1.FrozenSegments;

public class ReflectionHelpers
{
	static Func<T1, T2, TRes> GetFunc<T1, T2, TRes>(MethodInfo method)
	{
		Func<T1, T2, TRes> res = null;
		try
		{
			DynamicMethod dynMethod = new DynamicMethod(method.Name + "_dynMethod", typeof(TRes), new Type[] { typeof(T1), typeof(T2) }, method.DeclaringType, true);
			ILGenerator il = dynMethod.GetILGenerator();
			il.Emit(OpCodes.Ldarg_0);
			il.Emit(OpCodes.Ldarg_1);
			il.EmitCall(method.IsVirtual ? OpCodes.Callvirt : OpCodes.Call, method, null);
			il.Emit(OpCodes.Ret);
			res = (Func<T1, T2, TRes>)dynMethod.CreateDelegate(typeof(Func<T1, T2, TRes>));
		}
		catch (Exception err)
		{
			Console.WriteLine(err.ToString());
		}
		return res;
	}

	static Action<T1> GetAction<T1>(MethodInfo method)
	{
		Action<T1> res = null;
		try
		{
			DynamicMethod dynMethod = new DynamicMethod(method.Name + "_dynMethod", null, new Type[] { typeof(T1) }, method.DeclaringType, true);
			ILGenerator il = dynMethod.GetILGenerator();
			il.Emit(OpCodes.Ldarg_0);
			il.EmitCall(method.IsVirtual ? OpCodes.Callvirt : OpCodes.Call, method, null);
			il.Emit(OpCodes.Ret);
			res = (Action<T1>)dynMethod.CreateDelegate(typeof(Action<T1>));
		}
		catch (Exception err)
		{
			Console.WriteLine(err.ToString());
		}
		return res;
	}

	abstract public class MethodWrapper
	{
		public string Name { get; }
		public string ParamsSignature { get; }
		public string MethodSignature { get => Name + ParamsSignature; }
		public string AssemblyName { get; }

		bool initialized = false;
		string typeName = null;
		MethodInfo method = null;
		ConstructorInfo ctor = null;

		protected bool IsCtor => Name == ".ctor";
		protected MethodWrapper(string methodSignature, string assemblyName = null)
		{
			int typeIndex = methodSignature.IndexOf("::");
			if (typeIndex >= 0)
			{
				this.typeName = methodSignature.Substring(0, typeIndex);
				methodSignature = methodSignature.Substring(typeIndex + 2);
			}
			int paramsIndex = methodSignature.IndexOf('(');
			Name = methodSignature.Substring(0, paramsIndex);
			ParamsSignature = methodSignature.Substring(paramsIndex);
			AssemblyName = assemblyName;
		}

		protected MethodInfo ResolveMethod(object obj = null)
		{
			if (!initialized)
			{
				if (typeName == null && obj == null) { throw new ArgumentNullException("obj"); }
				Type t = typeName != null ? GetType(typeName) : obj.GetType();
				if (t == null && obj != null) { t = obj.GetType(); }
				SetMethod(t);
			}
			if (method == null)
			{
				// Logger.Trace("Execute -> Method {0}::{1} not found on", typeName, MethodSignature);
				throw new MissingMethodException(typeName, MethodSignature);
			}
			return method;
		}

		protected ConstructorInfo ResolveCtor()
		{
			if (!initialized)
			{
				if (typeName == null) { throw new ArgumentNullException("obj"); }
				Type t = GetType(typeName);
				SetCtor(t);
			}
			if (ctor == null)
			{
				// Logger.Trace("Execute -> Method {0}::{1} not found on", typeName, MethodSignature);
				throw new MissingMethodException(typeName, MethodSignature);
			}
			return ctor;
		}

		private void SetMethod(Type t)
		{
			if (t != null)
			{
				if (typeName == null) { typeName = t.ToString(); }
				method = t.GetMethods().FirstOrDefault(m => IsMethod(m));
				if (method == null)
				{
					method = t.GetMethods(BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).FirstOrDefault(m => IsMethod(m));
				}
			}
			initialized = true;
		}
		private void SetCtor(Type t)
		{
			if (t != null)
			{
				if (typeName == null) { typeName = t.ToString(); }
				ctor = t.GetConstructors().FirstOrDefault(m => IsMethod(m));
				if (ctor == null)
				{
					ctor = t.GetConstructors(BindingFlags.Public | BindingFlags.NonPublic).FirstOrDefault(m => IsMethod(m));
				}
			}
			initialized = true;
		}

		private Type GetType(string typeName)
		{
			if (typeName == null) { return null; }

			if (AssemblyName == null)
			{
				Type t = Type.GetType(typeName);
				if (t != null) { return t; }

				string assemblyName = typeName;
				int pos = assemblyName.LastIndexOf(".");
				while (pos >= 0)
				{
					assemblyName = assemblyName.Substring(0, pos);
					var res = AppDomain.CurrentDomain.GetAssemblies().Where(a => a.FullName.StartsWith(assemblyName)).Select(a => a.GetType(typeName)).FirstOrDefault(type => type != null);
					if (res != null) { return res; }
					pos = assemblyName.LastIndexOf(".");
				}
			}
			else
			{
				return AppDomain.CurrentDomain.GetAssemblies().Where(a => a.FullName.StartsWith(AssemblyName)).Select(a => a.GetType(typeName)).FirstOrDefault(type => type != null);
			}
			return null;
		}
		private bool IsMethod(MethodBase m)
		{
			if (m.Name != Name) { return false; }
			var parameters = m.GetParameters().Select(p => p.ParameterType.ToString()).ToArray();
			string signature = string.Format("({0})", string.Join(",", parameters));
			return signature == ParamsSignature;
		}
	}
	public class FuncWrapper<T1, T2, TRes> : MethodWrapper
	{
		Func<T1, T2, TRes> func = null;
		public FuncWrapper(string methodSignature) : base(methodSignature) { }

		public TRes Invoke(T1 arg1, T2 arg2)
		{
			if (func == null)
			{
				func = GetFunc<T1, T2, TRes>(ResolveMethod(arg1));
			}

			return func.Invoke(arg1, arg2);
		}
	}

	public class ActionWrapper<T1> : MethodWrapper
	{
		Action<T1> func = null;
		public ActionWrapper(string methodSignature) : base(methodSignature) { }

		public void Invoke(T1 arg1)
		{
			if (func == null)
			{
				func = GetAction<T1>(ResolveMethod(arg1));
			}

			func.Invoke(arg1);
		}
	}

}
