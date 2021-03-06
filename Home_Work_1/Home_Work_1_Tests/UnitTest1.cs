using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Home_Work_1;
using ILzxc;
using Calculator = Home_Work_1.Calculator;
using FSLibrary;

namespace Home_Work_1_Tests
{
    
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
            //Arrange
            var a = 10;
            var b = 5;
            var operation = Calculator.operations.Plus;
            
            //Act
            var result = Calculator.Calculate(10, 5, operation);
            
            //Assert
            Assert.AreEqual(15, result);
        }

        [ExcludeFromCodeCoverage]
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
        public void IsElementsEnough()
        {
            //arrange
            var point0 = 0;
            
            //act
            var result0 = Home_Work_1.Program.Main(new[] {""});

            //assert
            Assert.AreEqual(point0, result0);
        }

        [TestMethod] 
        public void IsElementsInteger()
        {
            //arrange
            var point1 = 1;
            //act
            var result1 = Program.Main(new[] {"z", "+", "q"});
            //assert
            Assert.AreEqual(point1, result1);
        }

        [TestMethod] 
        public void IsOperatorAvailable()
        {
            //arrange
            var point2 = 2;
            //act
            var result2 = Program.Main(new[] {"1", "zx", "1"});
            //assert
            Assert.AreEqual(point2, result2);
        }

        [TestMethod]
        public void IsDone()
        {
            //arrange
            var point3 = 3;
            //act
            var result3 = Program.Main(new[] {"31", "+", "31"});
            //assert
            Assert.AreEqual(point3, result3);
        }
        
        

        [TestMethod]
        public void ElementIsString()
        {
            //arrange
            var str1 = "zxc";
            //act
            var result1 = Home_Work_1.Parser.IsInt(str1, out _);
            //assert
            Assert.IsFalse(result1);
        }
        
        [TestMethod]
        public void ElementIsInteger()
        {
            //arrange
            var str2 = "32";
            //act
            var result2 = Home_Work_1.Parser.IsInt(str2, out var res1);
            //assert
            Assert.IsTrue(result2);
        }
        
        [TestMethod]
        public void IsElementConvertsRight()
        {
            //arrange
            var str3 = "31";
            //act
            var result3 = Home_Work_1.Parser.IsInt(str3, out var res2);
            //assert
            Assert.AreEqual(31,res2);
        }
        
        [TestMethod]
        public void IsOperationRight_Plus()
        {
            //arrange
            var symbolPlus = "+";
            //act
            var resultPlus = Home_Work_1.Parser.OperationDetector(symbolPlus);
            //assert
            Assert.AreEqual(Calculator.operations.Plus, resultPlus);
        }

        [TestMethod]
        public void IsOperationRight_Minus()
        {
            //arrange
            var symbolMinus = "-";
            //act
            var resultMinus = Home_Work_1.Parser.OperationDetector(symbolMinus);
            //assert
            Assert.AreEqual(Calculator.operations.Minus, resultMinus);
        }

        [TestMethod]
        public void IsOperationRight_Divide()
        {
            //arrange
            var symbolDivide = "/";
            //act
            var resultDivide = Home_Work_1.Parser.OperationDetector(symbolDivide);
            //assert
            Assert.AreEqual(Calculator.operations.Divide, resultDivide);
        }

        [TestMethod]
        public void IsOperationRight_Mult()
        {
            //arrange
            var symbolMult = "*";
            //act
            var resultMult = Home_Work_1.Parser.OperationDetector(symbolMult);
            //assert
            Assert.AreEqual(Calculator.operations.Mult, resultMult);
        }
        
        
        //IL Tests
        //IL Tests
        //IL Tests
        
        [TestMethod]
        public void MinusIL()
        {
            //arrange
            var a = 10;
            var b = 2;
            var operation = ILzxc.Calculator.operations.Minus;
            //act
            var result = ILzxc.Calculator.Calculate(10, 2, operation);
            //assert
            Assert.AreEqual(8, result);
        }

        [TestMethod]
        public void MultIL()
        {
            //arrange
            var a = 10;
            var b = 11;
            var operation = ILzxc.Calculator.operations.Mult;
            //act
            var result = ILzxc.Calculator.Calculate(10, 11, operation);
            //assert
            Assert.AreEqual(110, result);
        }

        [ExcludeFromCodeCoverage]
        [TestMethod]
        public void DivideIL()
        {
            //arrange
            var a = 10;
            var b = 5;
            var operation = ILzxc.Calculator.operations.Divide;
            //act
            var result = ILzxc.Calculator.Calculate(10, 5, operation);
            //assert
            Assert.AreEqual(2, result);
            
            
        }

        [TestMethod]
        public void PlusIL()
        {
            //Arrange
            var a = 10;
            var b = 5;
            var operation = ILzxc.Calculator.operations.Plus;
            
            //Act
            var result = ILzxc.Calculator.Calculate(10, 5, operation);
            
            //Assert
            Assert.AreEqual(15, result);
        }

        
        [TestMethod] 
        public void IsElementsEnoughIL()
        {
            //arrange
            var point0 = 0;
            
            //act
            var result0 = Home_Work_1.Program.Main(new[] {""});

            //assert
            Assert.AreEqual(point0, result0);
        }

        [TestMethod] 
        public void IsElementsIntegerIL()
        {
            //arrange
            var point1 = 1;
            //act
            var result1 = Program.Main(new[] {"z", "+", "q"});
            //assert
            Assert.AreEqual(point1, result1);
        }

        [TestMethod] 
        public void IsOperatorAvailableIL()
        {
            //arrange
            var point2 = 2;
            //act
            var result2 = Program.Main(new[] {"1", "zx", "1"});
            //assert
            Assert.AreEqual(point2, result2);
        }

        [TestMethod]
        public void IsDoneIL()
        {
            //arrange
            var point3 = 3;
            //act
            var result3 = Program.Main(new[] {"31", "+", "31"});
            //assert
            Assert.AreEqual(point3, result3);
        }
        
        

        [TestMethod]
        public void ElementIsStringIL()
        {
            //arrange
            var str1 = "zxc";
            //act
            var result1 = ILzxc.Parser.IsInt(str1, out _);
            //assert
            Assert.IsFalse(result1);
        }
        
        [TestMethod]
        public void ElementIsIntegerIL()
        {
            //arrange
            var str2 = "32";
            //act
            var result2 = ILzxc.Parser.IsInt(str2, out var res1);
            //assert
            Assert.IsTrue(result2);
        }
        
        [TestMethod]
        public void IsElementConvertsRightIL()
        {
            //arrange
            var str3 = "31";
            //act
            var result3 = ILzxc.Parser.IsInt(str3, out var res2);
            //assert
            Assert.AreEqual(31,res2);
        }
        
        [TestMethod]
        public void IsOperationRight_PlusIL()
        {
            //arrange
            var symbolPlus = "+";
            //act
            var resultPlus = ILzxc.Parser.OperationDetector(symbolPlus);
            //assert
            Assert.AreEqual(ILzxc.Calculator.operations.Plus, resultPlus);
        }

        [TestMethod]
        public void IsOperationRight_MinusIL()
        {
            //arrange
            var symbolMinus = "-";
            //act
            var resultMinus = ILzxc.Parser.OperationDetector(symbolMinus);
            //assert
            Assert.AreEqual(ILzxc.Calculator.operations.Minus, resultMinus);
        }

        [TestMethod]
        public void IsOperationRight_DivideIL()
        {
            //arrange
            var symbolDivide = "/";
            //act
            var resultDivide = ILzxc.Parser.OperationDetector(symbolDivide);
            //assert
            Assert.AreEqual(ILzxc.Calculator.operations.Divide, resultDivide);
        }

        [TestMethod]
        public void IsOperationRight_MultIL()
        {
            //arrange
            var symbolMult = "*";
            //act
            var resultMult = ILzxc.Parser.OperationDetector(symbolMult);
            //assert
            Assert.AreEqual(ILzxc.Calculator.operations.Mult, resultMult);
        }
        
        //F# tests
        //F# tests
        //F# tests
        //F# tests
        
        [TestMethod]
        public void MinusFS()
        {
            //arrange
            var a = 10;
            var b = 2;
            var operation = FSLibrary.FSCalculator.operations.Minus;
            //act
            var result = FSLibrary.FSCalculator.Calculate(10, 2, operation);
            //assert
            Assert.AreEqual(8, result);
        }

        [TestMethod]
        public void MultFS()
        {
            //arrange
            var a = 10;
            var b = 11;
            var operation = FSLibrary.FSCalculator.operations.Mult;
            //act
            var result = FSLibrary.FSCalculator.Calculate(10, 11, operation);
            //assert
            Assert.AreEqual(110, result);
        }

        
        

        [TestMethod]
        public void PlusFS()
        {
            //Arrange
            var a = 10;
            var b = 5;
            var operation = FSLibrary.FSCalculator.operations.Plus;
            
            //Act
            var result = FSLibrary.FSCalculator.Calculate(10, 5, operation);
            
            //Assert
            Assert.AreEqual(15, result);
        }

        

        [TestMethod] 
        public void IsElementsEnoughFS()
        {
            //arrange
            var point0 = 0;
            
            //act
            var result0 = Home_Work_1.Program.Main(new[] {""});

            //assert
            Assert.AreEqual(point0, result0);
        }

        [TestMethod] 
        public void IsElementsIntegerFS()
        {
            //arrange
            var point1 = 1;
            //act
            var result1 = Program.Main(new[] {"z", "+", "q"});
            //assert
            Assert.AreEqual(point1, result1);
        }

        [TestMethod] 
        public void IsOperatorAvailableFS()
        {
            //arrange
            var point2 = 2;
            //act
            var result2 = Program.Main(new[] {"1", "zx", "1"});
            //assert
            Assert.AreEqual(point2, result2);
        }

        [TestMethod]
        public void IsDoneFS()
        {
            //arrange
            var point3 = 3;
            //act
            var result3 = Program.Main(new[] {"31", "+", "31"});
            //assert
            Assert.AreEqual(point3, result3);
        }
        
        

        [TestMethod]
        public void ElementIsStringFS()
        {
            //arrange
            var str1 = "zxc";
            //act
            var result1 = FSLibrary.FSParser.IsInt(str1, out _);
            //assert
            Assert.IsFalse(result1);
        }
        
        [TestMethod]
        public void ElementIsIntegerFS()
        {
            //arrange
            var str2 = "32";
            //act
            var result2 = FSLibrary.FSParser.IsInt(str2, out var res1);
            //assert
            Assert.IsTrue(result2);
        }
        
        [TestMethod]
        public void IsElementConvertsRightFS()
        {
            //arrange
            var str3 = "31";
            //act
            var result3 = FSLibrary.FSParser.IsInt(str3, out var res2);
            //assert
            Assert.AreEqual(31,res2);
        }
        
        [TestMethod]
        public void IsOperationRight_PlusFS()
        {
            //arrange
            var symbolPlus = "+";
            //act
            var resultPlus = FSLibrary.FSParser.OperationDetector(symbolPlus);
            //assert
            Assert.AreEqual(FSLibrary.FSCalculator.operations.Plus, resultPlus);
        }

        [TestMethod]
        public void IsOperationRight_MinusFS()
        {
            //arrange
            var symbolMinus = "-";
            //act
            var resultMinus =FSLibrary.FSParser.OperationDetector(symbolMinus);
            //assert
            Assert.AreEqual(FSLibrary.FSCalculator.operations.Minus, resultMinus);
        }

        [TestMethod]
        public void IsOperationRight_DivideFS()
        {
            //arrange
            var symbolDivide = "/";
            //act
            var resultDivide = FSLibrary.FSParser.OperationDetector(symbolDivide);
            //assert
            Assert.AreEqual(FSLibrary.FSCalculator.operations.Divide, resultDivide);
        }

        [TestMethod]
        public void IsOperationRight_MultFS()
        {
            //arrange
            var symbolMult = "*";
            //act
            var resultMult = FSLibrary.FSParser.OperationDetector(symbolMult);
            //assert
            Assert.AreEqual(FSLibrary.FSCalculator.operations.Mult, resultMult);
        }
        
    }
}