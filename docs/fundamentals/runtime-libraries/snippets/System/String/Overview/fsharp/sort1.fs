module sort1.fs
// <Snippet3>
open System
open System.Globalization
open System.Threading

let printIndexAndValues (myArray: string[]) =
    for i = myArray.GetLowerBound 0 to myArray.GetUpperBound 0 do
        printfn $"[{i}]: {myArray[i]}" 
    printfn ""

// Create and initialize a new array to store the strings.
let stringArray = [| "Apple"; "Æble"; "Zebra" |]

// Display the values of the array.
printfn "The original string array:"
printIndexAndValues stringArray

// Set the CurrentCulture to "en-US".
Thread.CurrentThread.CurrentCulture <- CultureInfo "en-US"
// Sort the values of the array.
Array.Sort stringArray

// Display the values of the array.
printfn "After sorting for the culture \"en-US\":"
printIndexAndValues stringArray

// Set the CurrentCulture to "da-DK".
Thread.CurrentThread.CurrentCulture <- CultureInfo "da-DK"
// Sort the values of the Array.
Array.Sort stringArray

// Display the values of the array.
printfn "After sorting for the culture \"da-DK\":"
printIndexAndValues stringArray
// The example displays the following output:
//       The original string array:
//       [0]: Apple
//       [1]: Æble
//       [2]: Zebra
//
//       After sorting for the "en-US" culture:
//       [0]: Æble
//       [1]: Apple
//       [2]: Zebra
//
//       After sorting for the culture "da-DK":
//       [0]: Apple
//       [1]: Zebra
//       [2]: Æble
// </Snippet3>
