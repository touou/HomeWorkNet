using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Home_Work_1
{
    
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

        enum Exceptions
        {
            NotEnoughArguments=0,
            SomeOrAllArgsNotInteger=1,
            OperatorDoseNotExist=2,
            AllDone=3,
        }
        
        public static int Main(string[] args)
        {
            if (IsArgumentsEnough(args)==2)
            {
                return 0;
            }
            
            if (!FSLibrary.FSParser.IsInt(args[2],out var num2)||!FSLibrary.FSParser.IsInt(args[0],out var num1))
            {
                return 1;
            }

            var operation = FSLibrary.FSParser.OperationDetector(args[1]);
            
            if (operation==FSLibrary.FSCalculator.operations.UnknownOperator)
            {
                return 2;
            }

            var result=FSLibrary.FSCalculator.Calculate(num1, num2, operation);
            
            Console.WriteLine($"{num1}{args[1]}{num2}={result}");
            
            return 3;

        }
    }
}