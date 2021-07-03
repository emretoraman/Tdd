using System.Collections.Generic;

namespace Tdd.TddInAction
{
    public class RomanNumeralParser
    {
        private static readonly Dictionary<char, int> _map = new()
        {
            { 'I', 1 },
            { 'V', 5 },
            { 'X', 10 },
            { 'L', 50 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1000 }
        };

        public static int Parse(string romanNumeral)
        {
            int result = 0;
            for (int i = 0; i< romanNumeral.Length; i++)
            {
                if (i + 1 < romanNumeral.Length && _map[romanNumeral[i]] < _map[romanNumeral[i + 1]])
                {
                    result -= _map[romanNumeral[i]];
                }
                else
                {
                    result += _map[romanNumeral[i]];
                }
            }

            return result;
        }
    }
}
