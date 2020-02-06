
    let printOption opt =
        if (Option.isSome opt) then
            printfn "%A" <| Option.get opt
        else ()
    printOption (Some(1))
    printOption (Some("xyz"))
    printOption (None)
    printOption (Some(1.0))