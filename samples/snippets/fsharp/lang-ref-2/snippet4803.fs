let printOption (data : int option) =
    match data with
    | Some var1  -> printfn "%d" var1
    | None -> ()