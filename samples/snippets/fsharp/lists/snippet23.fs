let collectList = List.collect (fun x -> [for i in 1..3 -> x * i]) list1
printfn "%A" collectList