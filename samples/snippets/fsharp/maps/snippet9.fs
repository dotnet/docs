let map1 = Map.ofList [ (1, "one"); (2, "two"); (3, "three") ]
// Sum the keys.
let result1 = Map.foldBack (fun key value state -> state + key) map1 0
printfn "Result: %d" result1
// Concatenate the values.
let result2 = Map.foldBack (fun key value state -> state + value + " ") map1 ""
printfn "Result: %s" result2