printfn "Even numbers and their squares."
let map1 = Map.ofList [for i in 1 .. 10 -> (i, i*i)]
           |> Map.filter (fun key _ -> key % 2 = 0)
           |> Map.iter (fun key value -> printf "(%d, %d) " key value)
printfn ""