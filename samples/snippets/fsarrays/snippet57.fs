
    [| for x in -100 .. 100 -> x * x - 4 |]
    |> Array.min
    |> printfn "%A" 