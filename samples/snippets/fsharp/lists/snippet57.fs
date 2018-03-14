[ for x in -100 .. 100 -> x * x - 4 ]
|> List.min
|> printfn "%A"