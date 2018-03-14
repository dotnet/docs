let map1 = Map.ofList [ (1, "One"); (2, "Two"); (3, "Three") ]
let map2 = map1 |> Map.map (fun key value -> value.ToUpper())
let map3 = map1 |> Map.map (fun key value -> value.ToLower())
printfn "%A" map1
printfn "%A" map2
printfn "%A" map3