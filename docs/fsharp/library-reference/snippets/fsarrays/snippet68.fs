
    [| 1 .. 10 |]
    |> Array.toList
    |> List.rev
    |> List.iter (fun elem -> printf "%d " elem)
    printfn ""