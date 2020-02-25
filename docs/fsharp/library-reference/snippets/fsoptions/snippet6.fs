
    let isEven opt =
        Option.forall (fun elem -> elem % 2 = 0) opt
    printfn "%b" <| isEven (Some(2))
    printfn "%b" <| isEven None
    printfn "%b" <| isEven (Some(1))

    // Use this function with an array of int options.
    let forAllOptions function1 = List.forall (fun opt -> Option.forall function1 opt)
    let list1 = [ for i in 1 .. 10 do yield Some(i) ]
    let list2 = [ for i in 1 .. 10 do yield if (i % 2) = 0 then Some(i) else None ]
    let list3 = [ for i in 1 .. 10 do yield if (i % 2) = 1 then Some(i) else None ]
    let evalList list = printfn "%b" <| forAllOptions (fun value -> value % 2 = 0) list
    let lists = [ list1; list2; list3 ]
    List.iter evalList lists