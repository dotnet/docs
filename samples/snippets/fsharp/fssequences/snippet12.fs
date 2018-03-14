open System
let mutable arrayList1 = new System.Collections.ArrayList(10)
for i in 1 .. 10 do arrayList1.Add(10) |> ignore
let seqCast : seq<int> = Seq.cast arrayList1