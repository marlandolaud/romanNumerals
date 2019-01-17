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

        public static Dictionary ValidData => new List<Tuple<string, int>>
        {
            { "", 0 },
            { "   ", 0 },
            { "I", 1 },
            { "II", 2},
            { "III", 3},
            { "IV", 4},
            { "V", 5},
            { "DCXLVIII", 648},
            { "XXVI", 26 },
            { "XXXIX", 39 },
            { "XCIX", 99 },           
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
