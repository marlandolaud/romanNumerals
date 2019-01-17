namespace RomanNumerals
{
    public interface IRomanNumeralRepository
    {
        int? GetValueFromRomanNumeralKey(char key);
    }
}