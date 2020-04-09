let array1 = [| 1; 2; 3 |]
let array2 = [| -1; -2; -3 |]
let array3 = [| "horse"; "dog"; "elephant" |]
let arrayZip3 = Array.zip3 array1 array2 array3
printfn "%A" arrayZip3