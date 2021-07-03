using Tdd.TddInAction;
using Xunit;

namespace Tdd.Tests.TddInAction
{
    public class FizzBuzzTests
    {
        [Theory]
        [InlineData("", 1)]
        [InlineData("Fizz", 3)]
        [InlineData("Fizz", 6)]
        [InlineData("Buzz", 5)]
        [InlineData("Buzz", 10)]
        [InlineData("FizzBuzz", 15)]
        [InlineData("FizzBuzz", 30)]
        public void GetFizzBuzz_Gets(string expected, int number)
        {
            Assert.Equal(expected, FizzBuzz.GetFizzBuzz(number));
        }
    }
}
