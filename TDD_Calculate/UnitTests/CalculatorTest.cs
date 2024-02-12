using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TDD_Calculate.UnitTests
{
    public class CalculatorTest
    {
        [Fact]
        public void SumWithEmptyString()
        {
            //ARRAGE
            StringCalculator calculator = new StringCalculator();
            string emptyInput = "";
            int testResult = 0;
            //ACT 
            var expectedResult = calculator.Add(emptyInput);
            //ASSERT
            Assert.Equal(expectedResult, testResult);
        }

        [Fact]
        public void SumWithOneValue()
        {
            //ARRAGE
            StringCalculator calculator = new StringCalculator();
            string oneValueInput = "2";
            int testResult = 2;
            //ACT 
            var expectedResult = calculator.Add(oneValueInput);
            //ASSERT
            Assert.Equal(expectedResult, testResult);
        }

        [Fact]
        public void SumWithTwoValue()
        {
            //ARRAGE
            StringCalculator calculator = new StringCalculator();
            string twoValueInput = "2,5";
            int testResult = 7;
            //ACT 
            var expectedResult = calculator.Add(twoValueInput);
            //ASSERT
            Assert.Equal(expectedResult, testResult);
        }

        [Fact]
        public void SumWithSeparators()
        {
            //ARRAGE
            StringCalculator calculator = new StringCalculator();
            string separatorsInput = "1\n2,3";
            int testResult = 6;
            //ACT 
            var expectedResult = calculator.Add(separatorsInput);
            //ASSERT
            Assert.Equal(expectedResult, testResult);
        }

        [Fact]
        public void SumWithDelimiters()
        {
            //ARRAGE
            StringCalculator calculator = new StringCalculator();
            string separatorsInput = "//;\n1;2";
            int testResult = 3;
            //ACT 
            var expectedResult = calculator.Add(separatorsInput);
            //ASSERT
            Assert.Equal(expectedResult, testResult);
        }

        [Fact]
        public void SumThrowsArgumentException()
        {
            //ARRAGE
            StringCalculator calculator = new StringCalculator();
            string separatorsInput = "-1,-2;-3";
            //ACT&ASSERT
            Assert.Throws<ArgumentException>(() => calculator.Add(separatorsInput));
        }

        [Fact]
        public void GetSumCount()
        {
            //ARRAGE
            StringCalculator calculator = new StringCalculator();
            string separatorsInput = "1\n2,3";
            calculator.Add(separatorsInput);
            int testResult = 1;
            //ACT 
            var expectedResult = calculator.GetCalledCount();
            //ASSERT
            Assert.Equal(expectedResult, testResult);
        }
    }
}
