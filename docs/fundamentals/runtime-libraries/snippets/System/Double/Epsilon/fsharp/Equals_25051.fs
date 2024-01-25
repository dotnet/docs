module Equals_25051

let compareUsingEquals () =
    // <Snippet1>
    // Initialize two doubles with apparently identical values
    let double1 = 0.33333
    let double2 = double (1 / 3)
    // Compare them for equality
    printfn $"{double1.Equals double2}"    // displays false
    // </Snippet1>

let compareApproximateValues () =
    // <Snippet2>
    // Initialize two doubles with apparently identical values
    let double1 = 0.333333
    let double2 = double (1 / 3)
    // Define the tolerance for variation in their values
    let difference = abs (double1 * 0.00001)

    // Compare the values
    // The output to the console indicates that the two values are equal
    if abs (double1 - double2) <= difference then
        printfn "double1 and double2 are equal."
    else
        printfn "double1 and double2 are unequal."
    // </Snippet2>

let compareObjectsUsingEquals () =
    // <Snippet3>
    // Initialize two doubles with apparently identical values
    let double1 = 0.33333
    let double2 = double (1 / 3) |> box
    // Compare them for equality
    printfn $"{double1.Equals double2}"    // displays false
    // </Snippet3>

let compareApproximateObjectValues () =
    // <Snippet4>
    // Initialize two doubles with apparently identical values
    let double1 = 0.33333 
    let double2 = double (1 / 3) |> box
    // Define the tolerance for variation in their values
    let difference = abs (double1 * 0.0001)

    // Compare the values
    // The output to the console indicates that the two values are equal
    if abs(double1 - (double2 :?> double)) <= difference then
        printfn "double1 and double2 are equal."
    else
        printfn "double1 and double2 are unequal."
    // </Snippet4>

compareUsingEquals ()
printfn ""
compareApproximateValues ()
printfn ""
compareObjectsUsingEquals ()
printfn ""
compareApproximateObjectValues ()
