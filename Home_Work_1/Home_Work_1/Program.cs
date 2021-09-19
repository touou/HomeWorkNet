﻿using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Home_Work_1
{
    [ExcludeFromCodeCoverage]
    public class Program
    {
        static int IsArgumentsEnough(string[] arg)
        {
            if (arg.Length == 3)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }
        
        public static int NotEnoughArguments=0;
        public static int SomeOrAllArgsNotInteger = 1;
        public static int OperatorDoseNotExist = 2;
        public static int AllDone = 3;
        
        public static int Main(string[] args)
        {
            if (IsArgumentsEnough(args) != 3)
            {
                return 0;
            }
            if (!Parser.IsInt(args[2],out var num2)||!Parser.IsInt(args[0],out var num1))
            {
                return 1;
            }

            var operation = Parser.OperationDetector(args[1]);
            
            if (operation==Calculator.operations.UnknownOperation)
            {
                return 2;
            }

            var result=Calculator.Calculate(num1, num2, operation);
            
            Console.WriteLine($"{num1}{args[1]}{num2}={result}");
            
            return 3;

        }
    }
}