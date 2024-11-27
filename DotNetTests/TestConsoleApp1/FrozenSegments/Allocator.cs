using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

#if NET8_0_OR_GREATER

#nullable enable
namespace TestConsoleApp1.FrozenSegments;

public unsafe class BumpPointerNativeAllocator : IDisposable
{
	private readonly IntPtr _segment;
	private readonly long _limit;

	private bool _isDisposed;
	private long _start;
	private long _address;
	private long _allocated;

	List<WeakReference<string>> _externalRefs = new List<WeakReference<string>>();


	public BumpPointerNativeAllocator(nint size)
	{
		_isDisposed = false;
		_address = (IntPtr)NativeMemory.AlignedAlloc((nuint)size, 8);
		_start = _address;
		_segment = RegisterFrozenSegment((IntPtr)_address, size);

		var segment = (Heap_segment*)_segment;
		_allocated = _address;
		segment->allocated = (nint)_allocated;

		_limit = _address + size;
	}

	~BumpPointerNativeAllocator()
	{
		Dispose();
	}

	public void Dispose()
	{
		if (_isDisposed)
		{
			return;
		}

		_isDisposed = true;
		GC.SuppressFinalize(this);
		UnregisterFrozenSegment(_segment);
		NativeMemory.AlignedFree((void*)_start);
		_address = 0;
	}

	public long Available => _limit - _address;

	public long Alive => _externalRefs.Count(x => x.TryGetTarget(out _));

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public int SizeOf<T>()
	{
		var mt = typeof(T).TypeHandle.Value;
		var methodTable = *(MethodTable*)mt;

		return methodTable.BaseSize;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public bool Contains(object? obj)
	{
		if(obj is null)
		{
			return false;
		}

		var ptr = *(nint*)&obj;
		return _start <= ptr && ptr < _limit;
	}

	public T AllocateObject<T>() where T : class
	{
		var mt = typeof(T).TypeHandle.Value;
		var methodTable = *(MethodTable*)mt;

		var ptr = ReserveMemory(methodTable.BaseSize, true);

		// Write the header
		*ptr = 0;
		ptr++;

		// Write the mt
		*ptr = mt;

		return *(T*)&ptr;
	}

	public ref T AllocateStruct<T>() where T : struct
	{
		var mt = typeof(T).TypeHandle.Value;
		var methodTable = *(MethodTable*)mt;

		var ptr = ReserveMemory(methodTable.BaseSize, true);

		return ref Unsafe.AsRef<T>(ptr);
	}

	public string AllocateString(ReadOnlySpan<char> data)
	{
		var mt = typeof(string).TypeHandle.Value;
		var methodTable = *(MethodTable*)mt;

		var size = methodTable.BaseSize + (data.Length + 1) * sizeof(char);

		// Align up the size
		size = (size + IntPtr.Size - 1) & ~(IntPtr.Size - 1);

		var ptr = ReserveMemory(size, false);

		// Write the header
		*ptr = 0;
		ptr++;

		// Write the MT
		*ptr = mt;

		var dataPtr = (byte*)(ptr + 1);

		// Write the length
		*(int*)dataPtr = data.Length;

		// Write the chars
		var destination = new Span<char>(dataPtr + sizeof(int), data.Length + 1);

		data.CopyTo(destination);
		destination[^1] = '\0';

		var res = *(string*)&ptr;

		_externalRefs.Add(new WeakReference<string>(res));

		return res;
	}

	public T[] AllocateArray<T>(int length, bool clear = false)
	{
		var arrayMt = typeof(T[]).TypeHandle.Value;
		var arrayMethodTable = *(MethodTable*)arrayMt;

		var arraySize = arrayMethodTable.BaseSize + length * arrayMethodTable.ComponentSize;

		var ptr = ReserveMemory(arraySize, clear);

		// Write the header
		*ptr = 0;
		ptr++;

		// Write the MT
		*ptr = arrayMt;

		// Write the length
		*(ptr + 1) = length;

		return (T[])*(Array*)&ptr;
	}

	static ReflectionHelpers.FuncWrapper<IntPtr, IntPtr, IntPtr> _register = new ReflectionHelpers.FuncWrapper<IntPtr, IntPtr, IntPtr>("System.GC::_RegisterFrozenSegment(System.IntPtr,System.IntPtr)");
	private static IntPtr RegisterFrozenSegment(IntPtr sectionAddress, nint sectionSize)
	{
		return (IntPtr)typeof(GC).GetMethod("_RegisterFrozenSegment", BindingFlags.NonPublic | BindingFlags.Static)!.Invoke(null, [sectionAddress, sectionSize])!;
	}

	static ReflectionHelpers.ActionWrapper<IntPtr> _unregister = new ReflectionHelpers.ActionWrapper<IntPtr>("System.GC::_UnregisterFrozenSegment(System.IntPtr)");
	private static void UnregisterFrozenSegment(IntPtr segment)
	{
		typeof(GC).GetMethod("_UnregisterFrozenSegment", BindingFlags.NonPublic | BindingFlags.Static)!.Invoke(null, [segment]);
	}

	private nint* ReserveMemory(int size, bool clear)
	{
		ObjectDisposedException.ThrowIf(_address == 0, typeof(BumpPointerNativeAllocator));

		if (_address + size > _limit)
		{
			throw new OutOfMemoryException();
		}

		var objectAddress = Interlocked.Add(ref _address, size);

		if (objectAddress > _limit)
		{
			throw new OutOfMemoryException();
		}

		if (clear)
		{
			NativeMemory.Clear((void*)objectAddress, (nuint)size);
		}

		var segment = (Heap_segment*)_segment;
		Interlocked.Add(ref _allocated, size);
		segment->allocated = (nint)_allocated;
		

		return (nint*)(objectAddress - size);
	}


	[StructLayout(LayoutKind.Sequential)]
	public struct Heap_segment
	{
		public nint allocated;
		public nint committed;
		public nint reserved;
		public nint used;
		public nint mem;
	}

	[StructLayout(LayoutKind.Explicit)]
	public struct MethodTable
	{
		[FieldOffset(0)]
		public ushort ComponentSize;

		[FieldOffset(4)]
		public int BaseSize;
	}
}

#endif