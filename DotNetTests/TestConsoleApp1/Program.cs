using System;
using TestConsoleApp1;
using TestConsoleApp1.FrozenSegments;
using TestConsoleApp1.TaintedObjects;

namespace TestconsoleApp1
{
	internal class Program
	{
	    static int Main(string[] args)
	    {
			Console.WriteLine("Allocator");
			AllocatorTest.Main_(args);
			Console.WriteLine();
			Console.WriteLine("*****************************");
			Console.WriteLine();
			Console.WriteLine("TaintedMap");
			TaintedObjectsTest.Main_(args);


	        return -1;
	    }
	}
}
