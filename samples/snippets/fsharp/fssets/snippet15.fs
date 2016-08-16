
    let seqOfSets =
        seq { for i in 2 .. 5 do yield Set.ofList [ i .. i .. 40 ] }  
    let setResult = Set.unionMany seqOfSets
    printfn "Numbers up to 40 that are multiples of numbers from 2 to 5:"
    Set.iter (fun elem -> printf "%d " elem) setResult
