let BasicConstruction() =

    let emptyA = [||]

    let smallNumsA = [|1; 2; 3|]

    let emptyA2: int array = Array.zeroCreate 5

    printfn "emptyA = %A" emptyA
    printfn "\nsmallNumsA = %A" smallNumsA
    printfn "\nemptyA2 = %A" emptyA2