namespace FSLibrary

    open System
    open FSCalculator
    
    module FSParser =
        
        let IsInt (str:string) (result:outref<int>) =
            if Int32.TryParse(str, &result)
                then true
            else
                Console.WriteLine($"value is not int. The value was {str}")
                
                false
                
        let OperationDetector op =
            match op with
            | "+" -> operations.Plus
            | "-" -> operations.Minus
            | "*" -> operations.Mult
            | "/" -> operations.Divide
            | _ -> operations.UnknownOperator
            
        

