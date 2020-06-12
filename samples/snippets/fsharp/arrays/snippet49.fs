let array1 = [| 1; 2; 3 |]
let array2 = [| 4; 5; 6 |]
Array.iter (fun x -> printfn "Array.iter: element is %d" x) array1
Array.iteri(fun i x -> printfn "Array.iteri: element %d is %d" i x) array1
Array.iter2 (fun x y -> printfn "Array.iter2: elements are %d %d" x y) array1 array2
Array.iteri2 (fun i x y ->
               printfn "Array.iteri2: element %d of array1 is %d element %d of array2 is %d"
                 i x i y)
            array1 array2