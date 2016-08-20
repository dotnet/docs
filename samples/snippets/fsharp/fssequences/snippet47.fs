let seq1 = [1; 2; 3]
let newSeq = Seq.mapi (fun i x -> (i, x)) seq1
printfn "%A" newSeq