
namespace TDD_Calculate
{
    public class StringCalculator
    {
        public event Action<string, int> AddOccured;

        private int _calleCount;

        public int Add(string numbers)
        {
            _calleCount++;

            if (numbers == string.Empty)
            {
                OnAddOccured(numbers, 0);
                return 0;
            }

            var result = SumNumbers(numbers.Split(AddAnySeparators(numbers)));

            OnAddOccured(numbers, result);

            return result;
        }

        public int GetCalledCount()
            => _calleCount;

        private int SumNumbers(string[] arrayNumbers)
            => ParseStringToInt(arrayNumbers).Sum();

        private IEnumerable<int> ParseStringToInt(string[] arrayNumbers)
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

        private void CheckNegativeNumbers(IEnumerable<int> numbers)
        {
            if (AddNegativeNumbers(numbers).Any())
            {
                throw new ArgumentException($"Negatives not allowed: {NegativeNumbersString(AddNegativeNumbers(numbers))}");
            }
        }

        private char[] AddAnySeparators(string numbers)
            => numbers
                .Where(c => (char.IsSymbol(c) || char.IsWhiteSpace(c) || char.IsSeparator(c) || char.IsPunctuation(c)) && c != '-')
                .Distinct()
                .ToArray();



        private static IEnumerable<int> AddNegativeNumbers(IEnumerable<int> values)
            => values.Where(v => v < 0).ToList();

        private static string NegativeNumbersString(IEnumerable<int> negativeNumbers)
            => string.Join(", ", negativeNumbers);

        protected virtual void OnAddOccured(string input, int result)
        {
            AddOccured?.Invoke(input, result);
        }

    }
}
