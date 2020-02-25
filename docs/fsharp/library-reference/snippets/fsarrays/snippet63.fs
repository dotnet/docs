
    // Computes ((1 - 2) - 3) - 4 = -8
    Array.reduce (fun elem acc -> elem - acc) [| 1; 2; 3; 4 |]
    |> printfn "%A"
    // Computes 1 - (2 - (3 - 4)) = -2
    Array.reduceBack (fun elem acc -> elem - acc) [| 1; 2; 3; 4 |]
    |> printfn "%A"