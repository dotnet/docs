
    let array1 = [|1; 4; 8; -2; 5|]
    Array.sortInPlaceBy (fun elem -> abs elem) array1
    printfn "%A" array1