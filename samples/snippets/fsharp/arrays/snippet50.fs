
    Array.length [| 1 .. 100 |] |> printfn "Length: %d"
    Array.length [| |] |> printfn "Length: %d"
    Array.length [| 1 .. 2 .. 100 |] |> printfn "Length: %d"