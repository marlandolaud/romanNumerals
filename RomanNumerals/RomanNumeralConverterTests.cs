using System;
using System.Collections.Generic;
using Xunit;

namespace RomanNumerals
{
    public class RomanNumeralConverterTests
    {
        RomanNumeralConverter target;

        public RomanNumeralConverterTests()
        {
            IRunningSetCounter runningSetCounter = new RunningSetCounter(3);
            IRomanNumeralRepository romanNumeralRepository = new RomanNumeralRepository();

            target = new RomanNumeralConverter(runningSetCounter, romanNumeralRepository);
        }

        [Fact]
        public void NullShouldReturn0()
        {
            string input = null;
            int expected = 0;

            int actual = target.ConvertToInt(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void InvalidCharShouldReturnThrowException()
        {
            var input = "PRBDJSH";

            Assert.Throws<KeyNotFoundException>(() => target.ConvertToInt(input));
        }


        [Fact]
        public void MoreThan3RepitionsThrowExceptionTest()
        {
            var input = "IIII";

            Assert.Throws<InvalidOperationException>(() => target.ConvertToInt(input));
        }

        [Fact]
        public void MoreThan3RepitionsInMiddleThrowExceptionTest()
        {
            var input = "DCXXXXIII";

            Assert.Throws<InvalidOperationException>(() => target.ConvertToInt(input));
        }

        public static IEnumerable<object[]> ValidData => new List<object[]>
        {
            new object[] { "", 0 },
            new object[] { "   ", 0 },
            new object[] { "I", 1 },
            new object[] { "II", 2},
            new object[] { "III", 3},
            new object[] { "IV", 4},
            new object[] { "V", 5},
            new object[] { "DCXLVIII", 648},
            new object[] { "XXVI", 26 },
            new object[] { "XXXIX", 39 },
            new object[] { "XCIX", 99 },           
        };

        [Theory]
        [MemberData(nameof(ValidData))]
        public void ShouldConvertToProperValue(string input, int expected)
        {
            int actual = target.ConvertToInt(input);

            Assert.Equal(expected, actual);
        }
    }
}
