
    [| for x in -100 .. 100 -> 4 - x * x |]
    |> Array.max
    |> printfn "%A"