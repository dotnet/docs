let opt1 = Some("test")
let opt2 = None
printfn "%A %A" (Option.count opt1) (Option.count opt2)

// Use Option.count to count the number of Some values in
// an array of options.
let getCount (array1 : int option array) =
    (0, array1)
    ||> Array.fold (fun state elem -> state + Option.count elem)

let testArray1 = [| Some(10); None; Some(1); None; None; Some(56) |]

let testArray2 = [| for i in 1 .. 10 -> if i % 2 = 0 then Some(i) else None |]

printfn "%d" <| getCount testArray1
printfn "%d" <| getCount testArray2