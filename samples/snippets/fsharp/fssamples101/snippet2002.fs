let data = "The quick brown fox jumps over the lazy dog"
let histogram =
    data.ToCharArray()
    |> Seq.groupBy (fun c -> c)
    |> Map.ofSeq
    |> Map.map (fun k v -> Seq.length v)
for (KeyValue(c,n)) in histogram do
    printfn "Number of '%c' characters = %d" c n