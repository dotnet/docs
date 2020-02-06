let list1 = [1; 2; 3]
let list2 = [4; 5; 6]
let newList = List.map3 (fun x y z -> x + y + z) list1 list2 [2; 3; 4]
printfn "%A" newList