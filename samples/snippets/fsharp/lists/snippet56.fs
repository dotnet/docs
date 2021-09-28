[ -10.0 .. 10.0 ]
|> List.maxBy (fun x -> 1.0 - x * x)
|> printfn "%A"