
    // Using Seq.append to append an array to a list.
    let seq1to10 = Seq.append [1; 2; 3] [| 4; 5; 6; 7; 8; 9; 10 |]
    // Using Seq.concat to concatenate a list of arrays.
    let seqResult = Seq.concat [ [| 1; 2; 3 |]; [| 4; 5; 6 |]; [|7; 8; 9|] ]
    Seq.iter (fun elem -> printf "%d " elem) seq1to10
    printfn ""
    Seq.iter (fun elem -> printf "%d " elem) seqResult