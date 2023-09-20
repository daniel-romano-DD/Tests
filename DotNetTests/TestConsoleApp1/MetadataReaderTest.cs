using System;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.PortableExecutable;

namespace TestconsoleApp1 // Note: actual namespace depends on the project name.
{
    internal static class MetadataReaderTest
	{
        static void Main_(string[] args)
        {
            var assembly = typeof(Program).Assembly;
            using var fs = new FileStream(assembly.Location, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            using var peReader = new PEReader(fs);
            MetadataReader mr = peReader.GetMetadataReader();


            StringHandle stringHandle = mr.GetNextHandle(new StringHandle());
            while (!stringHandle.IsNil)
            {
                var str = mr.GetString(stringHandle);
                Console.WriteLine($"String: {str}");
                stringHandle = mr.GetNextHandle(stringHandle);
            }

            UserStringHandle userStringHandle = mr.GetNextHandle(new UserStringHandle());
            while (!userStringHandle.IsNil)
            {
                var userString = mr.GetUserString(userStringHandle);
                Console.WriteLine($"UserString: {userString}");
                userStringHandle = mr.GetNextHandle(userStringHandle);
            }



            string txt = "";
            if (args == null)
            {
                txt = "NULL args";
            }
            else 
            {
                txt = $"{args.Length} args";
            }
            Console.WriteLine(Function1(txt, Function2(txt)));

            for (int x = 0; x < 10; x++)
            {
                System.Threading.Thread.Sleep(1);
            }
        }
        static string Function1(string param1, int param2)
        {
            return param1 + new string('_', param2);
        }

        static int Function2(string param1)
        {
            return param1.Length;
        }
    }
} 