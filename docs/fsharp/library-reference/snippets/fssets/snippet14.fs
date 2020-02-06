
    let set1 = Set.ofList [ 2 .. 2 .. 8 ]
    let set2 = Set.ofList [ 1 .. 2 .. 9 ]
    let set3 = Set.union set1 set2
    printfn "%A union %A yields %A" set1 set2 set3