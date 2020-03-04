let data = Some(1,3)
printfn "data = %A" data;
printfn "data.IsSome = %b" data.IsSome
printfn "data.IsNone = %b" data.IsNone
printfn "data.Value = %A" data.Value

let data2 = None
printfn "data2.IsSome = %b" data2.IsSome
printfn "data2.IsNone = %b" data2.IsNone