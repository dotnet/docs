
    let map1 = Map.ofList [ (1, "one"); (2, "two"); (3, "three") ]
    // Sum the keys.
    let result1 = Map.fold (fun state key value -> state + key) 0 map1
    printfn "Result: %d" result1
    // Concatenate the values.
    let result2 = Map.fold (fun state key value -> state + value + " ") "" map1
    printfn "Result: %s" result2