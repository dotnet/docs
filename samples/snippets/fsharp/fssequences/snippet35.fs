
    let random = new System.Random()
    Seq.initInfinite (fun _ -> random.Next())
    |> Seq.filter (fun x -> x % 2 = 0)
    |> Seq.take 5
    |> Seq.iter (fun elem -> printf "%d " elem)
    printfn ""