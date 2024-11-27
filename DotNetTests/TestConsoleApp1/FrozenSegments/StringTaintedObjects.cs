using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

#if NET8_0_OR_GREATER

#nullable enable

namespace TestConsoleApp1.FrozenSegments;

internal unsafe class StringTaintedObjects : IDisposable
{
	internal BumpPointerNativeAllocator _allocator;
	int taintedObjectSize;


	public StringTaintedObjects()
	{
		_allocator = new BumpPointerNativeAllocator(1024 * 1024 * 5); //5MB
		taintedObjectSize = _allocator.SizeOf<StringTaintedObject>();
	}

	public void Dispose()
	{
		_allocator.Dispose();
	}

	public string? Taint(string? stringToTaint, Range[] ranges)
	{
		if (stringToTaint is null)
		{
			return stringToTaint;
		}

		// Alloc the Range[]
		var rangesPtr = _allocator.AllocateArray<Range>(ranges.Length);
		rangesPtr = ranges;

		//Alloc the StringTaintedObject
		var stringTaintedObject = _allocator.AllocateObject<StringTaintedObject>();

		//Alloc the actual string
		var taintedString = _allocator.AllocateString(stringToTaint);

		stringTaintedObject.Init(taintedString, rangesPtr);

		return taintedString;
	}

	public unsafe StringTaintedObject? Get(string? stringToFind)
	{
		if(!_allocator.Contains(stringToFind))
		{
			return null;
		}

		//Retrieve the StringTaintedObject

		var ptr = (nint*)&stringToFind; //Address of the string
		var taintedObjectPtr = *ptr - taintedObjectSize; //Address of the StringTaintedObject
		var taintedObject = (StringTaintedObject*)&taintedObjectPtr;

		return *taintedObject;
	}
}

#endif