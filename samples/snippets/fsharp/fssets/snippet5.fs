let seqOfSets =
    seq { for i in 1 .. 9 do yield Set.ofList [ i .. i .. 10000 ] }
let setResult = Set.intersectMany seqOfSets
printfn "Numbers between 1 and 10,000 that are divisible by "
printfn "all the numbers from 1 to 9:"
printfn "%A" setResult