
let printValue opt =
    match opt with
    | Some x -> printfn "%A" x
    | None -> printfn "No value."