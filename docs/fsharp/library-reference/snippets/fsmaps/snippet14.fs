
    let map1 = [ for i in 1 .. 100 -> (i, 100 - i) ] |> Map.ofList
    let result = Map.pick (fun key value -> if key = value then Some(key) else None) map1
    printfn "Result where key and value are the same: %d" result