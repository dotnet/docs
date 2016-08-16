
    let mySeq = seq { for i in 1 .. 10 -> i*i }
    let printSeq seq1 = Seq.iter (printf "%A ") seq1; printfn ""
    let mySeqSkipFirst5 = Seq.skip 5 mySeq
    mySeqSkipFirst5 |> printSeq