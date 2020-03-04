let list1 = [ 1 .. 10 ]
let list2 = List.empty

//The following line prints true
printfn "%A" (List.contains 5 list1)

//The following line prints false
printfn "%A" (List.contains 5 list2)