
    let findKeyFromValue findValue map =
        printfn "With value %A, found key %A." findValue (Map.findKey (fun key value -> value = findValue) map)
    let map1 = Map.ofList [ (1, "one"); (2, "two"); (3, "three") ]
    let map2 = Map.ofList [ for i in 1 .. 10 -> (i, i*i) ]
    try
        findKeyFromValue "one" map1
        findKeyFromValue "two" map1
        findKeyFromValue 9 map2
        findKeyFromValue 25 map2
        // The key is not in the map, so the following line throws an exception.
        findKeyFromValue 0 map2
    with
         :? System.Collections.Generic.KeyNotFoundException as e -> printfn "%s" e.Message