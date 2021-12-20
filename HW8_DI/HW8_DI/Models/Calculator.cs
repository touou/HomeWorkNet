using System;
using HW8_DI.Controllers;
using HW8_DI.Interfaces;

namespace HW8_DI.Models
{
    public class Calculator : ICalc
    {
        public decimal Calc(CalcArguments args)
        {
            var operation = args.Operation switch
            {
                "plus" => FSLibraryHW5.ParserHW5.getOperator("+"),
                "minus" => FSLibraryHW5.ParserHW5.getOperator("-"),
                "mult" =>FSLibraryHW5.ParserHW5.getOperator("*"),
                "divide" => FSLibraryHW5.ParserHW5.getOperator("/"),
                _ => FSLibraryHW5.ParserHW5.getOperator(default)
            };

            switch (operation)
            {
            }
            
            var result = FSLibraryHW5.CalculatorHW5.calculate(
                FSLibraryHW5.ParserHW5.decimalP(args.Value1),
                FSLibraryHW5.ParserHW5.decimalP(args.Value2),
                operation
                );
            return result.IsOk ? result.ResultValue :
                throw new Exception("can resolve the result");
        }

        
    }
}