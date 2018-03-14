let map1 = [ for i in 1..10 -> (i, i*i)] |> Map.ofList
let (mapEven, mapOdd) = Map.partition (fun key value -> key % 2 = 0) map1
printfn "Evens: %A" mapEven
printfn "Odds: %A" mapOdd