using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#if NET8_0_OR_GREATER

#nullable enable

namespace TestConsoleApp1.FrozenSegments;

internal class StringTaintedObject
{
	private string _value;

	internal void Init(string value, Range[] ranges)
	{
		_value = value;
		Ranges = ranges;
	}

	public object? Value => _value;

	public bool IsAlive => true;

	public Range[] Ranges { get; private set; }

}

#endif