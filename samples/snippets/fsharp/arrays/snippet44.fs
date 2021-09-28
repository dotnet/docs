// Specify the type by using a type argument.
let array1 = Array.empty<int>
// Specify the type by using a type annotation.
let array2 : int array = Array.empty

// Even though array3 has a generic type,
// you can still use methods such as Length on it.
let array3 = Array.empty
printfn "Length of empty array: %d" array3.Length