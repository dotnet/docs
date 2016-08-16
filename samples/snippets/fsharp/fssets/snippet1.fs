
    let set1 = Set.ofList [ 1 .. 3 ]
    let set2 = Set.ofList [ 4 .. 6 ]

    let set3 = set1 + set2
    let set4 = set3 - set1
    let set5 = set3 - set2

    printfn "set1: %A" set1
    printfn "set2: %A" set2
    printfn "set3 = set1 + set2: %A" set3
    printfn "set3 - set1: %A" set4
    printfn "set3 - set2: %A" set5