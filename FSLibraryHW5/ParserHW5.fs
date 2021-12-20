namespace FSLibraryHW5

open System
open FSLibraryHW5
open FSLibraryHW5.CalculatorHW5

module ParserHW5 = 
    let eMessage = "the value wasn't int"
    let notOperation = "this operation doesn't exist"
    let private resultNumber = ResultBuilder(eMessage)
    
    
    
    let getOperator operator =
        ResultBuilder(notOperation) {
            if (operator="+" || operator="/" || operator="-" || operator="*") then
                match operator with
                | "+" -> return Operation.Plus
                | "-" -> return Operation.Minus
                | "*" -> return Operation.Mult
                | _ -> return Operation.Divide
        }

    let intP (str: string) =
        resultNumber {
            let success, result = Int32.TryParse str
            if success then return result
        }
        
    let decimalP (str: string) =
        resultNumber {
            let success, result = Decimal.TryParse str
            if success then return result
        }

    let doubleP (str: string) =
        resultNumber {
            let success, result = Double.TryParse str
            if success then return result
        }

    let floatP (str: string) =
        resultNumber {
            let success, result = Single.TryParse str
            if success then return result
        }

    