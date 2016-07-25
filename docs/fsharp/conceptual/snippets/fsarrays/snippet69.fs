
    [| 1 .. 10 |]
    |> Array.toSeq
    |> Seq.truncate 5
    |> Seq.iter (fun elem -> printf "%d " elem)
    printfn ""