namespace FSLibrary

module FSCalculator =
    let DivByZ = "you try to divide by zero"
        
    let NotOperator ="this operation does not exist"
        
    type operations =
    | Plus
    | Minus
    | Divide
    | Mult
    | UnknownOperator
    
    let Calculate (val1:int) (val2:int) _Operation =
        match _Operation with
        | UnknownOperator -> failwith NotOperator
        | Plus -> val1 + val2
        | Minus -> val1 - val2
        | Mult -> val1 * val2
        | Divide ->
            try
                val1 / val2
            with
            | :? System.DivideByZeroException -> failwith DivByZ
        

