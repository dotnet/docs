
    let sumArray array = Array.fold (fun acc elem -> acc + elem) 0 array
    printfn "Sum of the elements of array %A is %d." [ 1 .. 3 ] (sumArray [| 1 .. 3 |])

    // The following example computes the average of a array.
    let averageArray array = (Array.fold (fun acc elem -> acc + float elem) 0.0 array / float array.Length)

    // The following example computes the standard deviation of a array.
    // The standard deviation is computed by taking the square root of the
    // sum of the variances, which are the differences between each value
    // and the average.
    let stdDevArray array =
        let avg = averageArray array
        sqrt (Array.fold (fun acc elem -> acc + (float elem - avg) ** 2.0 ) 0.0 array / float array.Length)

    let testArray arrayTest =
        printfn "Array %A average: %f stddev: %f" arrayTest (averageArray arrayTest) (stdDevArray arrayTest)

    testArray [|1; 1; 1|]
    testArray [|1; 2; 1|]
    testArray [|1; 2; 3|]

    // Array.fold is the same as to Array.iter when the accumulator is not used.
    let printArray array = Array.fold (fun acc elem -> printfn "%A" elem) () array
    printArray [|0.0; 1.0; 2.5; 5.1 |]