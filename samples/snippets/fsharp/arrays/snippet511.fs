let array1 = [| 1 .. 10 |]
let array2 = Array.empty

//The following line prints true
printfn "%A" (Array.contains 5 array1)

//The following line prints false
printfn "%A" (Array.contains 5 array2)