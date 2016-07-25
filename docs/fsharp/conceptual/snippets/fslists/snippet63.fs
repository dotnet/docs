let list1 = [1; 2; 3]
let list2 = []
// The following line prints [2; 3].
printfn "%A" (List.tail list1)
// The following line throws System.ArgumentException.
printfn "%A" (List.tail list2)