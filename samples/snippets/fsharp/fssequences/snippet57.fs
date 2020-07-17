[| for x in -100 .. 100 -> x * x - 4 |]
|> Seq.min
|> printfn "%A"