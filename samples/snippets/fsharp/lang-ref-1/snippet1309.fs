let list1 = [ 1; 2; 3 ]
let list2 = [ 4; 5; 6 ]
List.iter (fun x -> printfn "List.iter: element is %d" x) list1
List.iteri (fun i x -> printfn "List.iteri: element %d is %d" i x) list1
List.iter2 (fun x y -> printfn "List.iter2: elements are %d %d" x y) list1 list2

List.iteri2
    (fun i x y -> printfn "List.iteri2: element %d of list_1 is %d element %d of list2 is %d" i x i y)
    list1
    list2
