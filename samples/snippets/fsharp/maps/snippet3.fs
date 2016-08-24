let map1 = Map.ofList [ (1, "one"); (2, "two"); (3, "three") ]
let findKeyAndPrint key map =
    if (Map.containsKey key map) then
        printfn "The specified map contains the key %d." key
    else
        printfn "The specified map does not contain the key %d." key
findKeyAndPrint 1 map1
findKeyAndPrint 0 map1