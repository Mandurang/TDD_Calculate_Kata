
using Newtonsoft.Json.Linq;

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

            var punctuation = AddAnySeparators(numbers);

            var arrayNumbers = numbers.Split(punctuation);

             result = SumNumbers(arrayNumbers);
             return result;
        }

        private static int SumNumbers(string[] arrayNumbers)
        {
            List<int> values = new List<int>();

            foreach (var number in arrayNumbers)
            {
                int.TryParse(number, out int value);
                values.Add(value);
            }

            CheckNegativeNumbers(values);

            int result = values.Sum();

            return result;
        }

        private static void CheckNegativeNumbers(IEnumerable<int> values)
        {
            var negativeNumbers = values.Where(v => v < 0).ToList();

            if (negativeNumbers.Any())
            {
                string negativeNumbersString = string.Join(", ", negativeNumbers);
                throw new ArgumentException($"Negatives not allowed: {negativeNumbersString}");
            }
        }

        private static char[] AddAnySeparators(string numbers) 
            => numbers
                .Where(c => (char.IsSymbol(c) || char.IsWhiteSpace(c) || char.IsSeparator(c) || char.IsPunctuation(c)) && c != '-')
                .Distinct()
                .ToArray();

        //public int GetCalledCount()
        //{
        //    return Count;
        //}
    }
}
