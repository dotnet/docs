module Enumerable6

// <Snippet11>
open System
open System.Linq

let dbQueryResults = [| 1; 2; 3; 4 |]

let singleObject = dbQueryResults.SingleOrDefault(fun value -> value > 2)

if singleObject <> 0 then
    printfn $"{singleObject} is the only value greater than 2"
else
    // Handle an empty collection.
    printfn "No value is greater than 2"
    
// The example displays the following output:
//    Unhandled Exception: System.InvalidOperationException:
//       Sequence contains more than one matching element
//       at System.Linq.Enumerable.SingleOrDefault[TSource](IEnumerable`1 source, Func`2 predicate)
//       at <StartupCode$fs>.main()
// </Snippet11>