let inputArray = [| -5 .. 10 |]
let printArray array1 = Array.iter (printf "%A ") array1; printfn ""
printfn "Original array: "
printArray inputArray
printfn "\nArray with distinct absolute values: "
let arrayDistinctAbsoluteValue = Array.distinctBy (fun elem -> abs elem) inputArray
arrayDistinctAbsoluteValue |> printArray
