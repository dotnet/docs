let list1 = [ 1 .. 10 ]
let listEven, listOdd = List.partition (fun elem -> elem % 2 = 0) list1
printfn "Evens: %A\nOdds: %A" listEven listOdd