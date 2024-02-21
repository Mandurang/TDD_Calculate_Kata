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

        //[Fact]
        //public void GetSumCount()
        //{
        //    //ARRAGE
        //    StringCalculator calculator = new StringCalculator();
        //    string separatorsInput = "1\n2,3";
        //    calculator.Add(separatorsInput);
        //    int expectation = 1;
        //    //ACT 
        //    var expectedResult = calculator.GetCalledCount();
        //    //ASSERT
        //    Assert.Equal(expectedResult, expectation);
        //}
    }
}
