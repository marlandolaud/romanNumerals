using System.Collections.Generic;

namespace RomanNumerals
{
    public class RomanNumeralRepository : IRomanNumeralRepository
    {
        private readonly Dictionary<char, int?> dictionary;

        public RomanNumeralRepository()
        {
            this.dictionary = new Dictionary<char, int?>
            {
                {'I',1 },
                {'V',5 },
                {'X',10 },
                {'L',50 },
                {'C',100 },
                {'D',500 },
                {'M',1000 },
            };
        }

        public int? GetValueFromRomanNumeralKey(char key) => dictionary[key];

    }
}