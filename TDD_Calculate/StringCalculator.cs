
using Newtonsoft.Json.Linq;

namespace TDD_Calculate
{
    public class StringCalculator
    {
        //public event Action<string, int> AddOccured;
        private int _calleCount;

        public int Add(string numbers)
        {
            _calleCount++;
            return numbers == string.Empty ? 0
                : SumNumbers(numbers
                    .Split(AddAnySeparators(numbers)));
        }
        

        private int SumNumbers(string[] arrayNumbers)
        {
            return ParseStringToInt(arrayNumbers).Sum();
        }

        private List<int> ParseStringToInt(string[] arrayNumbers)
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

        private void CheckNegativeNumbers(IEnumerable<int> values)
        {
            var negativeNumbers = values.Where(v => v < 0).ToList();

            if (negativeNumbers.Any())
            {
                string negativeNumbersString = string.Join(", ", negativeNumbers);
                throw new ArgumentException($"Negatives not allowed: {negativeNumbersString}");
            }
        }

        private char[] AddAnySeparators(string numbers) 
            => numbers
                .Where(c => (char.IsSymbol(c) || char.IsWhiteSpace(c) || char.IsSeparator(c) || char.IsPunctuation(c)) && c != '-')
                .Distinct()
                .ToArray();

        public int GetCalledCount()
        {
            return _calleCount;
        }
    }
}
