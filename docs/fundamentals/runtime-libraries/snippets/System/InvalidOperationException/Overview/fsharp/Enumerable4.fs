module Enumerable4

// <Snippet9>
open System
open System.Linq

let dbQueryResults = [| 1; 2; 3; 4 |]

let firstNum = dbQueryResults.FirstOrDefault(fun n -> n > 4)

if firstNum = 0 then
    printfn "No value is greater than 4."
else
    printfn $"The first value greater than 4 is {firstNum}"

// The example displays the following output:
//       No value is greater than 4.
// </Snippet9>