using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Home_Work_1;

namespace Home_Work_1_Tests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void Minus()
        {
            Assert.AreEqual(32 - 21, Calculator.Calculate(32, 21, Calculator.operations.Minus));
            Assert.AreEqual(140 - 232, Calculator.Calculate(140, 232, Calculator.operations.Minus));
            Assert.AreEqual(656 - 212, Calculator.Calculate(656, 212, Calculator.operations.Minus));
            Assert.AreEqual(10002 - 3232, Calculator.Calculate(10002, 3232, Calculator.operations.Minus));
        }

        [TestMethod]
        public void Mult()
        {
            Assert.AreEqual(32 * 21, Calculator.Calculate(32, 21, Calculator.operations.Mult));
            Assert.AreEqual(140 * 232, Calculator.Calculate(140, 232, Calculator.operations.Mult));
            Assert.AreEqual(656 * 212, Calculator.Calculate(656, 212, Calculator.operations.Mult));
            Assert.AreEqual(1002 * 322, Calculator.Calculate(1002, 322, Calculator.operations.Mult));
        }

        [ExcludeFromCodeCoverage]
        [TestMethod]
        public void Divide()
        {
            try
            {
                Calculator.Calculate(6, 0, Calculator.operations.Divide);
            }
            
            catch (Exception e)
            {
                Assert.AreEqual(e,Calculator.DivideZero);
            }
            
            Assert.AreEqual(5/2,Calculator.Calculate(5,2,Calculator.operations.Divide));
            Assert.AreEqual(9/3,Calculator.Calculate(9,3,Calculator.operations.Divide));
            Assert.AreEqual(2/3,Calculator.Calculate(2,3,Calculator.operations.Divide));
        }

        [TestMethod]
        public void Plus()
        {
            Assert.AreEqual(3232+2,Calculator.Calculate(3232,2,Calculator.operations.Plus));
            Assert.AreEqual(32+2,Calculator.Calculate(32,2,Calculator.operations.Plus));
            Assert.AreEqual(555+313,Calculator.Calculate(555,313,Calculator.operations.Plus));
            Assert.AreEqual(4+567,Calculator.Calculate(4,567,Calculator.operations.Plus));
            Assert.AreEqual(11111+5631,Calculator.Calculate(11111,5631,Calculator.operations.Plus));
        }

        [ExcludeFromCodeCoverage]
        [TestMethod]
        public void IsOperatorRight()
        {
            try
            {
                Calculator.Calculate(3232, 3232, (Calculator.operations) 10);
            }
            catch (Exception e)
            {
                Assert.AreEqual(Calculator.OutOfRangeExcep,e);
            }
            
            
            try
            {
                Calculator.Calculate(3232, 3232, default);
            }
            catch (Exception e)
            {
                Assert.AreEqual(Calculator.WrongOperator, e);
            }
            
        }

        [TestMethod]
        public void CoreProcess()
        {
            
            Assert.AreEqual(0, Home_Work_1.Program.Main(new [] {""}));
            Assert.AreEqual(1, Program.Main(new [] {"z","+","q"}));
            Assert.AreEqual(2, Program.Main(new [] {"1","zx","1"}));
            Assert.AreEqual(3, Program.Main(new [] {"31","+","31"}));
        }
        
        [TestMethod]
        public void Parser()
        {
            Assert.AreEqual(false, Home_Work_1.Parser.IsInt("zxc", out _));
            
            Assert.AreEqual(true, Home_Work_1.Parser.IsInt("32", out var res));
            Assert.AreEqual(32, res);
            
            Assert.AreEqual(Calculator.operations.Mult, Home_Work_1.Parser.OperationDetector("*"));
            Assert.AreEqual(Calculator.operations.Divide, Home_Work_1.Parser.OperationDetector("/"));
            Assert.AreEqual(Calculator.operations.Minus,Home_Work_1.Parser.OperationDetector("-"));
            
        }

    }
}