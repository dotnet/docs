let array1 = [| 1; 2; 3 |]
let newArray = Array.mapi (fun i x -> (i, x)) array1
printfn "%A" newArray