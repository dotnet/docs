
    let seq1 = seq { for i in 1..2..5 do for j in 1..2..5 do yield i*j }
    printfn "%A" seq1
    let myset = set seq1
    printfn "%A" myset