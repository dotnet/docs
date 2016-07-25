
    let findAndPrint key map =
        printfn "With key %d, found value %A." key (Map.find key map)
    let map1 = Map.ofList [ (1, "one"); (2, "two"); (3, "three") ]
    let map2 = Map.ofList [ for i in 1 .. 10 -> (i, i*i) ]
    try
        findAndPrint 1 map1
        findAndPrint 2 map1
        findAndPrint 3 map2
        findAndPrint 5 map2
        // The key is not in the map, so this throws an exception.
        findAndPrint 0 map2
    with
         :? System.Collections.Generic.KeyNotFoundException as e -> printfn "%s" e.Message