using Tdd.TddInAction;
using Xunit;

namespace Tdd.Tests.TddInAction
{
    public class RomanNumeralParserTests
    {
        [Theory]
        [InlineData(1, "I")]
        [InlineData(2, "II")]
        [InlineData(4, "IV")]
        [InlineData(7, "VII")]
        [InlineData(28, "XXVIII")]
        [InlineData(49, "XLIX")]
        public void Parse_Parses(int expected, string romanNumeral)
        {
            Assert.Equal(expected, RomanNumeralParser.Parse(romanNumeral));
        }
    }
}
