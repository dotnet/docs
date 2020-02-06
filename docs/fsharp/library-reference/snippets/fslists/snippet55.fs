[ for x in -100 .. 100 -> 4 - x * x ]
|> List.max
|> printfn "%A"