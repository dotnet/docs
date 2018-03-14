[| -10.0 .. 10.0 |]
|> Array.maxBy (fun x -> 1.0 - x * x)
|> printfn "%A"