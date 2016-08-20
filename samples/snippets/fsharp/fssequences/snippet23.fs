let inputSequence = { -5 .. 10 }
let printSeq seq1 = Seq.iter (printf "%A ") seq1; printfn ""
printfn "Original sequence: "
printSeq inputSequence
printfn "\nSequence with distinct absolute values: "
let seqDistinctAbsoluteValue = Seq.distinctBy (fun elem -> abs elem) inputSequence
seqDistinctAbsoluteValue |> printSeq