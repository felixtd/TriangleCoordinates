using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CherwellTest
{
	public static class ExtensionMethods
	{
		private static Dictionary<char, int> charToIntMap;
		private static Dictionary<int, char> intToCharMap;

		static ExtensionMethods()
		{
			charToIntMap = new Dictionary<char, int>()
			{
				['A'] = 1,
				['B'] = 2,
				['C'] = 3,
				['D'] = 4,
				['E'] = 5,
				['F'] = 6,
			};

			intToCharMap = new Dictionary<int, char>()
			{
				[1] = 'A',
				[2] = 'B',
				[3] = 'C',
				[4] = 'D',
				[5] = 'E',
				[6] = 'F',
			};
		}

		public static int ToRowInt(this char c)
		{
			var val = Char.ToUpper(c);
			if (!charToIntMap.Keys.Contains(val))
			{
				throw new ArgumentOutOfRangeException($"Row value \"{c}\" is out of range.");
			}

			return charToIntMap[val];
		}

		public static char ToRowChar(this int i)
		{
			if (!intToCharMap.Keys.Contains(i))
			{
				throw new ArgumentOutOfRangeException($"Row value \"{i}\" is out of range.");
			}

			return intToCharMap[i];
		}
	}
}
