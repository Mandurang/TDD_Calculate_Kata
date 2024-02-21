using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace TDD_Calculate.UnitTests
{
    public class CalculatorTest
    {
        [Theory]
        [InlineData("", 0)]
        [InlineData("2", 2)]
        [InlineData("2,5", 7)]
        [InlineData("1\n2,3", 6)]
        [InlineData("//;\n1;2", 3)]
        public void TestInAdd_ReturnValidValues(string userInput, int expectation)
        {
            var result = StringCalculator.Add(userInput);
            result.Should().Be(expectation);
        }

        [Theory]
        [InlineData("-10")]
        [InlineData("-1,-2;-3")]
        [InlineData("//;\n-1;-2")]
        public void TestInAddNegativeNumbers_ThrowArgumentException(string userInput)
        {
            Action action = () => StringCalculator.Add(userInput);
            action.Should().Throw<ArgumentException>();
        }

        [Theory]
        [InlineData(1,1)]
        [InlineData(4, 4)]
        public void TestHowMuchCalledCount_ReturnValidCount(int calleCount, int expectation)
        {
            //ARRAGE
            for (int i = 0; i < expectation; i++)
            {
                StringCalculator.Add(String.Empty);
            }
            //ACT 
            var result = StringCalculator.GetCalledCount();
            //ASSERT
            result.Should().Be(expectation);
        }
    }
}
