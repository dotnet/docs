
    let mySeq = seq { for i in 1 .. 10 -> i*i }
    let printSeq seq1 = Seq.iter (printf "%A ") seq1; printfn ""
    let mySeqSkipWhileLessThan10 = Seq.skipWhile (fun elem -> elem < 10) mySeq
    mySeqSkipWhileLessThan10 |> printSeq