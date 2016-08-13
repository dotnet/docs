
    let stringOpt1 = Some("Mirror Image")
    let stringOpt2 = None
    let reverse (string : System.String) =
        match string with
        | "" -> None
        | s -> Some(new System.String(string.ToCharArray() |> Array.rev))
        
    let result1 = Option.bind reverse stringOpt1
    printfn "%A" result1
    let result2 = Option.bind reverse stringOpt2
    printfn "%A" result2