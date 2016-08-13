let seq1 = seq { 1..10 }
let seq2 = Seq.empty

//The following line prints true
printfn "%A" (Seq.contains 5 seq1)

//The following line prints false
printfn "%A" (Seq.contains 5 seq2)