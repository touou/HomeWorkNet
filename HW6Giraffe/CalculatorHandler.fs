module HW6Giraffe.CalculatorHandler

open Giraffe.Core
open Giraffe

[<CLIMutable>]
type Values=
    {
        Value1 : string
        Value2 : string
        Operation : string }

let CalculatorHttpHandler : HttpHandler =
    fun next ctx ->
        let values = ctx.TryBindQueryString<Values>()
        match values with
        | Ok v ->
            let res = CalcAdapter.calculate v.Value1 v.Value2 v.Operation
            match res with
            | Ok res -> (setStatusCode 200 >=> json res) next ctx
            | Error err -> (setStatusCode 450 >=> json err) next ctx
        | Error err ->
            (setStatusCode 400 >=> json err) next ctx

