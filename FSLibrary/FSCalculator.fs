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
    
    let Sum (val1,val2) =
        val1+val2
     
    let Minus (val1,val2) =
        val1-val2
    
    let Mult(val1,val2)=
        val1*val2
    
    let Divide(val1,val2)=
        val1/val2
        
    
    
    let Calculate (val1:int) (val2:int) _Operation =
        match _Operation with
        | UnknownOperator -> failwith NotOperator
        | Plus -> Sum(val1,val2)
        | Minus -> Minus(val1,val2)
        | Mult -> Mult(val1,val2)
        | Divide ->
            try
                Divide(val1,val2)
            with
            | :? System.DivideByZeroException -> failwith DivByZ
        

