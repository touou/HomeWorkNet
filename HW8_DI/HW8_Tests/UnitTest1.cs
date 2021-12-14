using System;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using HW8_DI;
using HW8_DI.Models;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using HW8_DI;
using HW8_DI.Controllers;

namespace HW8_Tests
{
    public class UnitTest1
    {
        private Calculator _Calculator = new Calculator();
        [Theory]
        [InlineData(1, "plus", 2, 3)]
        [InlineData(3, "plus", 2, 5)]
        [InlineData(12.4, "minus", 2.6, 9.8)]
        public void Calc(decimal val1, string operation, decimal val2, decimal result)
        {
            var actual = _Calculator.Calc(new CalcArguments()
            {
                Value1 = val1.ToString(),
                Value2 = val2.ToString(),
                Operation = operation
            });
            Assert.Equal(result, actual);
        }
    }
}