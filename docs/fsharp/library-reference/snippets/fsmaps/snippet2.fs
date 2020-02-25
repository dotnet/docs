    let map1 = Map.ofList [ (1, "one"); (2, "two") ]
    let map2 = map1.Add(0, "zero")
    let map3 = map2.Add(2, "twice")
    map3 |> Map.iter (fun key value -> printfn "key: %d value: %s" key value)