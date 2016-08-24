let set1 = Set.ofList [ 1 .. 3 ]
let set2 = Set.ofList [ 2 .. 6 ]
let setDiff = Set.difference set2 set1
printfn "Set.difference [2 .. 6] [1 .. 3] yields %A" setDiff