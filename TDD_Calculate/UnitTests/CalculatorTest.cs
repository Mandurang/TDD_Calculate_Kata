﻿using System;
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
        [InlineData("//[***]\n1***2***3", 6)]
        [InlineData("//////////1[**][%%]\n**2^$$$%%^^25", 28)]
        [InlineData("2;1001", 2)]
        public void TestInAdd_ReturnValidValues(string userInput, int expectation)
        {
            StringCalculator calculator = new StringCalculator();

            var result = calculator.Add(userInput);
            result.Should().Be(expectation);
        }

        [Theory]
        [InlineData("-10")]
        [InlineData("-1,-2;-3")]
        [InlineData("//;\n-1;-2")]
        [InlineData("//[***]\n-1***-2***-3")]
        [InlineData("//////////1[**][%%]\n**2^$$$%%^^-25")]
        public void TestInAddNegativeNumbers_ThrowArgumentException(string userInput)
        {
            StringCalculator calculator = new StringCalculator();

            Action action = () => calculator.Add(userInput);
            action.Should().Throw<ArgumentException>();
        }

        [Theory]
        [InlineData(1,1)]
        [InlineData(4, 4)]
        [InlineData(6, 6)]
        public void TestHowMuchCalledCount_ReturnValidCount(int calleCount, int expectation)
        {
            //ARRAGE
            StringCalculator calculator = new StringCalculator();

            for (int i = 0; i < calleCount; i++)
            {
                calculator.Add(String.Empty);
            }
            //ACT 
            var result = calculator.GetCalledCount();
            //ASSERT
            result.Should().Be(expectation);
        }

        [Theory]
        [InlineData("//;\n1;2", 3)]
        [InlineData("", 0)]
        public void AddOccured_AfterAdd(string input, int expectedResult)
        {
            StringCalculator calculator = new StringCalculator();

            string givenInput = string.Empty;
            int result = 0; 

            calculator.AddOccured += (input, res) =>
            {
                givenInput = input;
                result = res;
            };

            calculator.Add(input);

            // Assert
            givenInput.Should().Be(input);
            result.Should().Be(expectedResult);
        }
    }
}
