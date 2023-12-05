let sumList = List.map2 (fun x y -> x + y) list1 list2
printfn "%A" sumList

let newList2 = List.map3 (fun x y z -> x + y + z) list1 list2 newList
printfn "%A" newList2

let collectList = List.collect (fun x -> [ for i in 1..3 -> x * i ]) list1
printfn "%A" collectList

let newListAddIndex = List.mapi (fun i x -> x + i) list1
printfn "%A" newListAddIndex

let listAddTimesIndex = List.mapi2 (fun i x y -> (x + y) * i) list1 list2
printfn "%A" listAddTimesIndex