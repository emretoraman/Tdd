using System.Collections.Generic;

namespace Tdd.TddInAction
{
    public class Fibonacci
    {
        private static readonly Dictionary<int, int> _cache = new();

        public static int GetFibonacci(int index)
        {
            if (index < 2) return index;
            if (_cache.ContainsKey(index)) return _cache[index];

            var result = GetFibonacci(index - 1) + GetFibonacci(index - 2);
            _cache[index] = result;
            return result;
        }
    }
}
