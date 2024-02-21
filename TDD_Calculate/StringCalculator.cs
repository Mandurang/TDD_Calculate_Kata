
using Newtonsoft.Json.Linq;

namespace TDD_Calculate
{
    public static class StringCalculator
    {
        //public event Action<string, int> AddOccured;
        
        public static int Add(string numbers) 
            => numbers == string.Empty ? 0 
                : SumNumbers(numbers
                .Split(AddAnySeparators(numbers)));


        private static int SumNumbers(string[] arrayNumbers) 
            => ParseStringToInt(arrayNumbers).Sum();

        private static List<int> ParseStringToInt(string[] arrayNumbers)
        {
            List<int> numbers = new List<int>();

            foreach (var number in arrayNumbers)
            {
                int.TryParse(number, out int value);
                numbers.Add(value);
            }

            CheckNegativeNumbers(numbers);
            return numbers;
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
