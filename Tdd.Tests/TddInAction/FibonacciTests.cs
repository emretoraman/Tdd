using Tdd.TddInAction;
using Xunit;

namespace Tdd.Tests.TddInAction
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
            Assert.Equal(expected, Fibonacci.GetFibonacci(index));
        }
    }
}
