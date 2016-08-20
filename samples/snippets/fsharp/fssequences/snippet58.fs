[| -10.0 .. 10.0 |]
|> Seq.minBy (fun x -> x * x - 1.0)
|> printfn "%A"