
    let seq1 = [1; 2; 3]
    let seq2 = [4; 5; 6]
    let sumSeq = Seq.map2 (fun x y -> x + y) seq1 seq2
    printfn "%A" sumSeq