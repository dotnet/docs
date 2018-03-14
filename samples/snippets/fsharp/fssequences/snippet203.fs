let secondItem = seq { yield "foo"; yield "bar"; yield "baz" } |> Seq.item 1
printfn "%s" secondItem