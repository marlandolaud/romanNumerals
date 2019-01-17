using System;
using System.Collections.Generic;
using System.Text;

namespace RomanNumerals
{
    public class RunningSetCounter : IRunningSetCounter
    {
        private int maxLengthOfSet;

        private int lengthOfRepition;

        public RunningSetCounter(int maxLengthOfSet)
        {
            this.maxLengthOfSet = maxLengthOfSet;
            lengthOfRepition = 0;
        }

        public void Check(int currentValue, int? nextValue)
        {
            lengthOfRepition = IsRunningSequence(nextValue, currentValue) ? lengthOfRepition + 1 : 0;

            if (lengthOfRepition >= maxLengthOfSet)
            {
                throw new InvalidOperationException($"MAX_LENGTH_OF_SET");
            }
        }

        private bool IsRunningSequence(int? prevValue, int currentValue) => 
            prevValue.HasValue && prevValue.Value == currentValue;
    }
}
