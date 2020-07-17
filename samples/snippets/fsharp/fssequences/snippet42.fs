let emptySeq = Seq.empty
let nonEmptySeq = seq { 1 .. 10 }
Seq.isEmpty emptySeq |> printfn "%b"
Seq.isEmpty nonEmptySeq |> printfn "%b"