let consOption list opt =
    Option.foldBack (fun value state -> value :: state) list opt
printfn "%A" <| consOption None [ 1 .. 10 ]
printfn "%A" <| consOption (Some(0)) [1 .. 10]