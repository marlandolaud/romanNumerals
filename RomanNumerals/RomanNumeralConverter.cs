using System;
using System.Collections.Generic;
using System.Text;

namespace RomanNumerals
{
    public class RomanNumeralConverter
    {
        private IRunningSetCounter counter;

        private IRomanNumeralRepository romanNumeralRepository;

        public RomanNumeralConverter(IRunningSetCounter counter, IRomanNumeralRepository romanNumeralRepository)
        {
            this.counter = counter;
            this.romanNumeralRepository = romanNumeralRepository;
        }

        public int ConvertToInt(string input)
        {
            int totalSum = 0;
       
            if (!string.IsNullOrWhiteSpace(input))
            {
                for (int index = 0; index < input.Length; index++)
                {
                    int currentValue = romanNumeralRepository.GetValueFromRomanNumeralKey(input[index]).Value;
                    int? nextValue = IsInBounds(input, index + 1) ? romanNumeralRepository.GetValueFromRomanNumeralKey(input[index + 1]) : null;

                    counter.Check(currentValue, nextValue);

                    if (IsNextValueGreaterThanCurrent(nextValue, currentValue))
                    {
                        totalSum += nextValue.Value - currentValue;

                        index++;
                    }
                    else
                    {
                        totalSum += currentValue;
                    }
                }
            }

            return totalSum;
        }

        private bool IsNextValueGreaterThanCurrent(int? nextValue, int currentValue) =>
            nextValue.HasValue && nextValue.Value > currentValue;        

        private bool IsInBounds(string input, int i) => i >= 0 && i <= input.Length - 1;
    }
}
