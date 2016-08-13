
    let map1 = [ for i in 1 .. 100 -> (i, i*i) ] |> Map.ofList
    let result = Map.tryFindKey (fun key value -> key = value) map1
    match result with
    | Some key -> printfn "Found element with key %d." key
    | None -> printfn "Did not find any element that matches the condition."