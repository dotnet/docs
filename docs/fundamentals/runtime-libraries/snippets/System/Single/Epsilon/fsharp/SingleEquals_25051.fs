module SingleEquals_25021

open System

let compareUsingEquals () =
    // <Snippet1>
    // Initialize two floats with apparently identical values
    let float1 = 0.33333f
    let float2 = 1f / 3f
    // Compare them for equality
    printfn $"{float1.Equals float2}"    // displays false
    // </Snippet1>   

let compareApproximateValues () =
    // <Snippet2> 
    // Initialize two floats with apparently identical values
    let float1 = 0.33333f
    let float2 = 1f / 3f
    // Define the tolerance for variation in their values
    let difference = abs (float1 * 0.0001f)

    // Compare the values
    // The output to the console indicates that the two values are equal
    if abs (float1 - float2) <= difference then
        printfn "float1 and float2 are equal."
    else
        printfn "float1 and float2 are unequal."
    // </Snippet2>

let compareObjectsUsingEquals () =
    // <Snippet3>
    // Initialize two floats with apparently identical values
    let float1 = 0.33333f
    let float2 = box (1f / 3f)
    // Compare them for equality
    printfn $"{float1.Equals float2}"    // displays false
    // </Snippet3>   

let compareApproximateObjectValues () =
    // <Snippet4> 
    // Initialize two floats with apparently identical values
    let float1 = 0.33333f
    let float2 = box (1f / 3f)
    // Define the tolerance for variation in their values
    let difference = abs (float1 * 0.0001f)

    // Compare the values
    // The output to the console indicates that the two values are equal
    if abs (float1 - (float2 :?> float32)) <= difference then
        printfn "float1 and float2 are equal."
    else
        printfn "float1 and float2 are unequal."
    // </Snippet4>

compareUsingEquals ()
printfn ""
compareApproximateValues ()
printfn ""
compareObjectsUsingEquals ()
printfn ""
compareApproximateObjectValues ()
printfn ""