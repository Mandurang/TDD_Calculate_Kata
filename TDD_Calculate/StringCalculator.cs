using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_Calculate
{
    public delegate void AddOccured();
    class StringCalculator
    {
        private int Count;
        public event Action<string, int> AddOccured;

        public StringCalculator()
        {
            Count = 0;
        }

        public int Add(string numbers)
        {
            Count++;
            int result = 0;
            OnAddOccurred("Method was called", Count);

            char[] separators = { '\n' , ',', ';'};

             if (numbers == string.Empty || numbers == "")
             {
                 return 0;
             }

             var arrayNumbers = numbers.Split(separators);

             foreach (var number in arrayNumbers)
             {
                 Int32.TryParse(number, out int value);
                 if (value < 0)
                     throw new ArgumentException($"Negatives not allowed {value}");
                 result += value;
             }
             return result;
        }

        public int GetCalledCount()
        {
            return Count;
        }

        protected virtual void OnAddOccurred(string message, int value)
        {
            AddOccured?.Invoke(message, value);
        }
    }
}
