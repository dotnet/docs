let seq1 = { 1 .. 10 }

// The following chunks the sequence into sub-sequences of size 2
printfn "%A" (Seq.chunkBySize 2 seq1)

// The following chunks the sequence into sub-sequences of size 3, with the last sequence being a single element
printfn "%A" (Seq.chunkBySize 3 seq1)
