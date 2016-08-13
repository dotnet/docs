
    let data = ["Cats";"Dogs";"Mice";"Elephants"]
    data |> List.iteri (fun i x -> printfn "item %d: %s" i x)