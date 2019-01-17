namespace RomanNumerals
{
    public interface IRunningSetCounter
    {
        void Check(int currentValue, int? nextValue);
    }
}