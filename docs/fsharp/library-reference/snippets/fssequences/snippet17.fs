
    // takeWhile
    let mySeqLessThan10 = Seq.takeWhile (fun elem -> elem < 10) mySeq
    mySeqLessThan10 |> printSeq

    // skip
    let mySeqSkipFirst5 = Seq.skip 5 mySeq
    mySeqSkipFirst5 |> printSeq

    // skipWhile
    let mySeqSkipWhileLessThan10 = Seq.skipWhile (fun elem -> elem < 10) mySeq
    mySeqSkipWhileLessThan10 |> printSeq