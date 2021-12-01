module HW6Giraffe.CalcAdapter

open FSLibraryHW5

let calculate val1 val2 operation =
    let val1 = ParserHW5.decimalP val1
    let val2 = ParserHW5.decimalP val2
    let operation =
        match operation with
        | "sum" -> "+"
        | "minus" -> "-"
        | "div" -> "/"
        | "mult" -> "*"
        | _ -> ""
    let operation = ParserHW5.getOperator operation
    CalculatorHW5.calculate val1 val2 operation

