
    let average1 = Array.average [| 1.0 .. 10.0 |]
    printfn "Average: %f" average1
    // To get the average of an array of integers, 
    // use Array.averageBy to convert to float.
    let average2 = Array.averageBy (fun elem -> float elem) [|1 .. 10 |]
    printfn "Average: %f" average2