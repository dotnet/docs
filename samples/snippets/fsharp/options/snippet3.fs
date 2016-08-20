let isValue opt value =
    Option.exists (fun elem -> elem = value) opt
let testOpt1 = Some(10)
let testOpt2 = Some(11)
let testOpt3 = None
printfn "%b" <| isValue testOpt1 10
printfn "%b" <| isValue testOpt2 10
printfn "%b" <| isValue testOpt3 10