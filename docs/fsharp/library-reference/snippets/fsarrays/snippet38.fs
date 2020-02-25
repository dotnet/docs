
    let sortedArray2 = Array.sortBy (fun elem -> abs elem) [|1; 4; 8; -2; 5|]
    printfn "%A" sortedArray2