[| -10.0 .. 10.0 |]
|> Array.minBy (fun x -> x * x - 1.0)
|> printfn "%A"