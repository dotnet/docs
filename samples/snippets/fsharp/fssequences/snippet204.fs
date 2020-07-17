let seq1 = seq { 1..10 }
let seq2 = Seq.empty

//The following line prints seq [2; 3; 4; 5; ...]
printfn "%A" (Seq.tail seq1)

//The following line prints this error message:
//Error: The input sequence has an insufficient number of elements.
//Parameter name: source
printfn "%A" (Seq.tail seq2)