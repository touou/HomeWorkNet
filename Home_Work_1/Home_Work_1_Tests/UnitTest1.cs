using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Home_Work_1;

namespace Home_Work_1_Tests
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void Minus()
        {
            //arrange
            var a = 10;
            var b = 2;
            var operation = Calculator.operations.Minus;
            //act
            var result = Calculator.Calculate(10, 2, operation);
            //assert
            Assert.AreEqual(8, result);
        }

        [TestMethod]
        public void Mult()
        {
            //arrange
            var a = 10;
            var b = 11;
            var operation = Calculator.operations.Mult;
            //act
            var result = Calculator.Calculate(10, 11, operation);
            //assert
            Assert.AreEqual(110, result);
        }

        [ExcludeFromCodeCoverage]
        [TestMethod]
        public void Divide()
        {
            //arrange
            var a = 10;
            var b = 5;
            var operation = Calculator.operations.Divide;
            //act
            var result = Calculator.Calculate(10, 5, operation);
            //assert
            Assert.AreEqual(2, result);
            
            //arrange
            var a1 = 10;
            var b1 = 0;
            var operation1 = Calculator.operations.Divide;
            //act
            try
            {
                Calculator.Calculate(a1, b1, operation1);
            }
            //assert
            catch (Exception e)
            {
                Assert.AreEqual(Calculator.DivideZero,e);
            }
        }

        [TestMethod]
        public void Plus()
        {
            //arrange
            var a = 10;
            var b = 5;
            var operation = Calculator.operations.Plus;
            //act
            var result = Calculator.Calculate(10, 5, operation);
            //assert
            Assert.AreEqual(15, result);
        }

        
        [TestMethod]
        public void IsOperatorRight()
        {
            //arrange
            var a = 3232;
            var b = 3232;
            Calculator.operations operation=default;
            //act
            try
            {
                Calculator.Calculate(a, b, operation);
            }
            //assert
            catch (Exception e)
            {
                Assert.AreEqual(Calculator.WrongOperator, e);
            }
        }

        [TestMethod]
        public void CoreProcess()
        {
            //arrange
            var point0 = 0;
            var point1 = 1;
            var point2 = 2;
            var point3 = 3;
            
            //act
            var result0 = Home_Work_1.Program.Main(new[] {""});
            var result1 = Program.Main(new[] {"z", "+", "q"});
            var result2 = Program.Main(new[] {"1", "zx", "1"});
            var result3 = Program.Main(new[] {"31", "+", "31"});
            
            //assert
            Assert.AreEqual(point0, result0);
            Assert.AreEqual(point1, result1);
            Assert.AreEqual(point2, result2);
            Assert.AreEqual(point3, result3);
        }
        
        [TestMethod]
        public void Parser()
        {
            //arrange
            var str1 = "zxc";
            var str2 = "32";
            
            //act
            var result1 = Home_Work_1.Parser.IsInt(str1, out _);
            var result2 = Home_Work_1.Parser.IsInt(str2, out var res);
            
            //assert
            Assert.AreEqual(false, result1);
            Assert.AreEqual(true, result2);
            Assert.AreEqual(32, res);
            
            //arrange
            var symbolPlus = "+";
            var symbolMinus = "-";
            var symbolDivide = "/";
            var symbolMult = "*";
            
            //act
            var resultPlus = Home_Work_1.Parser.OperationDetector(symbolPlus);
            var resultMinus = Home_Work_1.Parser.OperationDetector(symbolMinus);
            var resultDivide = Home_Work_1.Parser.OperationDetector(symbolDivide);
            var resultMult = Home_Work_1.Parser.OperationDetector(symbolMult);
            
            //assert
            Assert.AreEqual(Calculator.operations.Plus, resultPlus);
            Assert.AreEqual(Calculator.operations.Divide, resultDivide);
            Assert.AreEqual(Calculator.operations.Minus,resultMinus);
            Assert.AreEqual(Calculator.operations.Mult,resultMult);
        }

    }
}