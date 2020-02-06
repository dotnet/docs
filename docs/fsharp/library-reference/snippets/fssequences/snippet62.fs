
    let valuesSeq = [ ("a", 1); ("b", 2); ("c", 3) ]

    let resultPick = Seq.pick (fun elem ->
                        match elem with
                        | (value, 2) -> Some value
                        | _ -> None) valuesSeq
    printfn "%A" resultPick