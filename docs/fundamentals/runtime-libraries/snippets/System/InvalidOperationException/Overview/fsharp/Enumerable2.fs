module Enumerable2

// <Snippet7>
open System
open System.Linq

let dbQueryResults = [| 1; 2; 3; 4 |]
let moreThan4 = 
    dbQueryResults.Where(fun num -> num > 4)

if moreThan4.Any() then
    printfn $"Average value of numbers greater than 4: {moreThan4.Average()}:"
else
    // handle empty collection
    printfn "The dataset has no values greater than 4."

// The example displays the following output:
//       The dataset has no values greater than 4.
// </Snippet7>