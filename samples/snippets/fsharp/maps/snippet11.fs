let map1 = Map.ofList [ (1, "one"); (2, "two"); (3, "three") ]
let map2 = Map.ofList [ (-1, "negative one"); (2, "two"); (3, "three") ]
let allPositive = Map.forall (fun key value -> key > 0)
printfn "%b %b" (allPositive map1) (allPositive map2)