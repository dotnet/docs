
    let values = [| ("a", 1); ("b", 2); ("c", 3) |]

    let resultPick = Array.pick (fun elem ->
                        match elem with
                        | (value, 2) -> Some value
                        | _ -> None) values
    printfn "%A" resultPick