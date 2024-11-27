using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleApp1
{
	internal class StringHashTest
	{
		public static int Main_(string[] args)
		{
			for(int b = 0; b < 301; b++)
			{
				PrintHash(b.ToString());
				PrintHash(b.ToString());
			}

			return 0;
		}

		static void PrintHash(string s)
		{
			Console.WriteLine($"{s} : {RuntimeHelpers.GetHashCode(s)}  {s.GetHashCode()} ");
		}
	}
}