let myEmptyArray = Array.empty
printfn "Length of empty array: %d" myEmptyArray.Length



printfn "Array of floats set to 5.0: %A" (Array.create 10 5.0)


printfn "Array of squares: %A" (Array.init 10 (fun index -> index * index))

let (myZeroArray : float array) = Array.zeroCreate 10