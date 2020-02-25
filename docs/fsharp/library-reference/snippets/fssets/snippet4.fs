
    let set1 = Set.ofList [ 1 .. 3 ]
    let set2 = Set.ofList [ 2 .. 6 ] 
    let setIntersect = Set.intersect set1 set2
    printfn "Set.intersect [1 .. 3] [2 .. 6] yields %A" setIntersect