let array1 = [| 1 .. 3 |]
let array2 = [| 1; 2; 4; |]

// Compare two arrays element by element.
let compareArrays = Array.compareWith (fun elem1 elem2 ->
    if elem1 > elem2 then 1
    elif elem1 < elem2 then -1
    else 0) 

// Prints Array1 is less than Array2
match compareArrays array1 array2 with
| 1 -> printfn "Array1 is greater than Array2."
| -1 -> printfn "Array1 is less than Array2."
| 0 -> printfn "Array1 is equal to Array2."
| _ -> failwith("Invalid comparison result.")

let array3 = [| 1; 44; 3; |]
let array4 = [| 1; 2; |]

// Prints 42
printfn "%A" (Array.compareWith (fun elem1 elem2 -> elem1 - elem2) array3 array4)