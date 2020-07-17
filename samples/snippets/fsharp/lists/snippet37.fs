let list1 = [1; 2; 3]
let list2 = [4; 5; 6]
let listAddTimesIndex = List.mapi2 (fun i x y -> (x + y) * i) list1 list2
printfn "%A" listAddTimesIndex