// This computes 3 - 2 - 1, which evaluates to -6.
let subtractArray array1 = Array.fold (fun acc elem -> acc - elem) 0 array1
printfn "%d" (subtractArray [| 1; 2; 3 |])

// This computes 3 - (2 - (0 - 1)), which evaluates to 2.
let subtractArrayBack array1 = Array.foldBack (fun elem acc -> elem - acc) array1 0
printfn "%d" (subtractArrayBack [| 1; 2; 3 |])
