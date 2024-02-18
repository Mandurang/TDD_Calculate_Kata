
namespace TDD_Calculate
{
    public static class StringCalculator
    {
        //public event Action<string, int> AddOccured;
        
        public static int Add(string numbers)
        {
            int result = 0;

             if (numbers == string.Empty)
             {
                 return 0;
             }

             var punctuation = numbers.Where(c => char.IsSymbol(c) || char.IsWhiteSpace(c) || char.IsSeparator(c) || char.IsPunctuation(c)).Distinct().ToArray();

            var arrayNumbers = numbers.Split(punctuation);

             foreach (var number in arrayNumbers)
             {
                 Int32.TryParse(number, out int value);
                 if (value < 0)
                     throw new ArgumentException($"Negatives not allowed {value}");
                 result += value;
             }
             return result;
        }

        //public int GetCalledCount()
        //{
        //    return Count;
        //}
    }
}
