using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_Calculate
{
    public static class StringCalculator
    {
        //public event Action<string, int> AddOccured;
        
        public static int Add(string numbers)
        {
            int result = 0;

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

        //public int GetCalledCount()
        //{
        //    return Count;
        //}
    }
}
