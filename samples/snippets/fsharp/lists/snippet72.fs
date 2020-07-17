let myList = [ for i in 1 .. 10 -> i*i ]
let truncatedList = List.truncate 5 myList
let takenList = List.take 5 myList

let truncatedList2 = List.truncate 20 myList

let printList list1 = List.iter (printf "%A ") list1; printfn ""

truncatedList |> printList
takenList |> printList
truncatedList2 |> printList

// The following line produces a run-time error
List.take 20 myList |> printList
