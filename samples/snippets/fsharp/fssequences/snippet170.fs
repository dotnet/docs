let mySeq = seq { for i in 1 .. 10 -> i*i }
let printSeq seq1 = Seq.iter (printf "%A ") seq1; printfn ""
let mySeqLessThan10 = Seq.takeWhile (fun elem -> elem < 10) mySeq
mySeqLessThan10 |> printSeq