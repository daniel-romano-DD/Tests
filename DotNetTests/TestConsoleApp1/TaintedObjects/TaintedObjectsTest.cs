using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestConsoleApp1.FrozenSegments;

namespace TestConsoleApp1.TaintedObjects;

internal static class TaintedObjectsTest
{
	const int reps = 10000;

	public static int Main_(string[] args)
	{
#if NET8_0_OR_GREATER
		var sw = new Stopwatch();
		sw.Start();

		GC.Collect(); GC.WaitForPendingFinalizers();
		TestContextCreation();
		GC.Collect(); GC.WaitForPendingFinalizers();
		TestTainting();
		GC.Collect(); GC.WaitForPendingFinalizers();
		TestLookup();
		GC.Collect(); GC.WaitForPendingFinalizers();
		TestMixed();
		GC.Collect(); GC.WaitForPendingFinalizers();

		sw.Stop();
		var elapsed = sw.Elapsed;
		//Console.WriteLine($"---------------------------------");
		//Console.WriteLine($"TOTAL  : {elapsed.TotalMicroseconds} us");
#endif
		return 0;
	}

	private static void TestContextCreation()
	{
		var sw = new Stopwatch();
		sw.Start();
		for (int x = 0; x < reps / 100; x++)
		{
			using var taintedObjects = new TaintedObjects();

			var str1 = "String 1";
			var str2 = "String 2";
			//Range[] ranges = [new Range(2, 3), new Range(7, 1)];
			//taintedObjects.Taint(str1, ranges);

			if (taintedObjects.Get(str2) is not null) { throw new Exception($"str2 should not be tainted"); }
			//if (taintedObjects.Get(str1) is null) { throw new Exception($"str2 should be tainted"); }
		}

		sw.Stop();
		var elapsed = sw.Elapsed;

		Console.WriteLine($"---------------------------------");
		Console.WriteLine($"CONTEXT  : {elapsed.TotalMicroseconds / (double)reps} us");
	}

	private static void TestTainting()
	{
		var sw = new Stopwatch();
		using var taintedObjects = new TaintedObjects();

		Range[] ranges = [new Range(2, 3), new Range(7, 1)];

		sw.Start();

		for (int y = 0; y < reps / 10; y++)
		{
			var str = $"String - {y}";
			taintedObjects.Taint(str, ranges);
		}

		sw.Stop();
		var elapsed = sw.Elapsed;

		Console.WriteLine($"---------------------------------");
		Console.WriteLine($"TAINTING : {elapsed.TotalMicroseconds / (double)reps} us");
	}

	private static void TestLookup()
	{
		var sw = new Stopwatch();
		using var taintedObjects = new TaintedObjects();

		var str1 = "String 1";

		Range[] ranges = [new Range(2, 3), new Range(7, 1)];

		taintedObjects.Taint(str1, ranges);
		for (int y = 0; y < reps; y++)
		{
			var str = $"String - {y}";
			taintedObjects.Taint(str, ranges);
		}

		sw.Start();

		for (int y = 0; y < reps; y++)
		{
			if (taintedObjects.Get(str1) is null) { throw new Exception($"str1 should be tainted"); }
		}

		sw.Stop();
		var elapsed = sw.Elapsed;

		Console.WriteLine($"---------------------------------");
		Console.WriteLine($"LOOKUP   : {elapsed.TotalMicroseconds / (double)reps} us");
	}

	private static void TestMixed()
	{
		var sw = new Stopwatch();
		sw.Start();
		for (int x = 0; x < reps / 100; x++)
		{
			using var taintedObjects = new TaintedObjects();

			var str1 = "String 1";
			var str2 = "String 2";
			Range[] ranges = [new Range(2, 3), new Range(7, 1)];

			for (int y = 0; y < reps / 10; y++)
			{
				str1 = $"String - {y}";
				taintedObjects.Taint(str1, ranges);
			}

			for (int z = 0; z < reps; z++)
			{
				if (taintedObjects.Get(str1) is null) { throw new Exception($"str1 should be tainted"); }
				if (taintedObjects.Get(str2) is not null) { throw new Exception($"str2 should not be tainted"); }
			}
		}

		sw.Stop();
		var elapsed = sw.Elapsed;

		Console.WriteLine($"---------------------------------");
		Console.WriteLine($"ALL      : {elapsed.TotalMicroseconds / (double)reps} us");
	}
}