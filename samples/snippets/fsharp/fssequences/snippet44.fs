
    let table1 = seq { for i in 1 ..10 do
                          for j in 1 .. 10 do
                              yield (i, j, i*j)
                     }
    Seq.length table1 |> printfn "Length: %d"