using System.Collections.Generic;
using Xunit;

namespace Tdd.TddInAction
{
    public class FibonacciTests
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(1, 2)]
        [InlineData(2, 3)]
        public void GetFibonacci_Gets(int expected, int index)
        {
            Assert.Equal(expected, GetFibonacci(index));
        }

        private static readonly Dictionary<int, int> _cache = new();

        private static int GetFibonacci(int index)
        {
            if (index < 2) return index;
            if (_cache.ContainsKey(index)) return _cache[index];

            var result = GetFibonacci(index - 1) + GetFibonacci(index - 2);
            _cache[index] = result;
            return result;
        }
    }
}
