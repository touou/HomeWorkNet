namespace FSLibraryHW5

type ResultBuilder(errorMessage: string) =
    new() = ResultBuilder("error")
    member v1.Zero() = Error errorMessage

    member v1.Bind(x, f) =
        match x with
        | Ok x -> f x
        | Error _ -> x

    member v1.Return x = Ok x
    member v1.Combine(x, f) = f x

module CalculatorHW5 =
    
    type Operation =
        | Plus
        | Minus
        | Divide
        | Mult
        
    let private defaultResult = ResultBuilder("unknown error")
    let devByZero = "you can't dived by zero"

    let inline calculate
        (a1: Result<'T, string> when 'T: (static member (+) : 'T * 'T -> 'T) and 'T: (static member (/) :
                   'T * 'T -> 'T) and 'T: (static member (*) : 'T * 'T -> 'T) and 'A: (static member (-) : 'T * 'T -> 'T))
        (a2: Result<'T, string>)
        (operation: Result<Operation, string>)=
        match operation with
        | Ok operation ->
            ResultBuilder(devByZero) {
                let! val1 = a1
                let! val2 = a2
                match operation with
                | Plus -> return val1 + val2
                | Divide ->
                    if val2 <> new 'T() then
                        return val1 / val2
                | Minus -> return val1 - val2
                | Mult -> return val1 * val2
            }
        | Error operationError -> Error operationError