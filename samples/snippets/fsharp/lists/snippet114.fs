let list1 = [ 1 .. 3 ]
let list2 = [ 1; 2; 4; ]

// Compare two lists element by element.
let compareLists = List.compareWith (fun elem1 elem2 ->
    if elem1 > elem2 then 1
    elif elem1 < elem2 then -1
    else 0)

// Prints List1 is less than List2
match compareLists list1 list2 with
| 1 -> printfn "List1 is greater than List2."
| -1 -> printfn "List1 is less than List2."
| 0 -> printfn "List1 is equal to List2."
| _ -> failwith("Invalid comparison result.")

let list3 = [ 1; 44; 3; ]
let list4 = [ 1; 2; ]

// Prints 42
printfn "%A" (List.compareWith (fun elem1 elem2 -> elem1 - elem2) list3 list4)