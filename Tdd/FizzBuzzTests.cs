using Xunit;

namespace Tdd
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
            Assert.Equal(expected, GetFizzBuzz(number));
        }

        private string GetFizzBuzz(int number)
        {
            if (number % 15 == 0) return "FizzBuzz";
            if (number % 3 == 0) return "Fizz";
            if (number % 5 == 0) return "Buzz";
            return "";
        }
    }
}
