
    let makeMap (f : float -> float) min max step =
        seq { for x in min .. step .. max -> (x, f x) } |> Map.ofSeq
    let functions = [ sin; cos; tan ]
    let functionData = functions |> List.map (fun f -> makeMap f 0.0 (3.14159/2.0) 0.1)
    let map1 = List.zip functions functionData
    let positiveInRangeResults = List.map (fun (key, valueMap) -> Map.forall (fun key value -> value > 0.0) valueMap) map1
    printfn "%A" positiveInRangeResults