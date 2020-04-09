let list1 = [1; 2; 3]
let newList = List.mapi (fun i x -> (i, x)) list1
printfn "%A" newList