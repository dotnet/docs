let array1 = [| 1; 2; 3 |]
let array2 = [| 4; 5; 6 |]
let arrayOfSums = Array.map2 (fun x y -> x + y) array1 array2
printfn "%A" arrayOfSums