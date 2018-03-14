let sequence = seq { 1 .. 100 }
let printSeq seq1 = Seq.iter (printf "%A ") seq1; printfn ""
let sequences3 = Seq.groupBy (fun index ->
                                if (index % 3 = 0) then 0
                                  elif (index % 3 = 1) then 1
                                  else 2) sequence
sequences3 |> printSeq