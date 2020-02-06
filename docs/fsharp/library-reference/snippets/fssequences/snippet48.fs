
    [| for x in -100 .. 100 -> 4 - x * x |]
    |> Seq.max
    |> printfn "%A"