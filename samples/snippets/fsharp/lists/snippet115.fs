let list1 = [ 1 .. 100 ]
let printList alist =
    alist
    |> List.iter (printf "%A ")
    printfn ""
let listResult = List.countBy (fun elem ->
    if (elem % 2 = 0) then 0 else 1) list1

printList listResult