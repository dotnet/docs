
    let seq1 = [1; 2; 3]
    let seq2 = [4; 5; 6]
    Seq.iter (fun x -> printfn "Seq.iter: element is %d" x) seq1
    Seq.iteri(fun i x -> printfn "Seq.iteri: element %d is %d" i x) seq1
    Seq.iter2 (fun x y -> printfn "Seq.iter2: elements are %d %d" x y) seq1 seq2