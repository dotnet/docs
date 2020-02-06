
    let aoList2 = [ for i in 1..5 -> i*i ]
    let add acc item = acc + item       // accumulator function 
    let sum = List.reduce add aoList2
    printfn "sum = %d" sum