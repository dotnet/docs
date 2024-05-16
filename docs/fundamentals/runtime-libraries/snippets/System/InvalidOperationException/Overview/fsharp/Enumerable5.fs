module Enumerable5

// <Snippet10>
open System
open System.Linq

let dbQueryResults = [| 1; 2; 3; 4 |]

let singleObject = dbQueryResults.Single(fun value -> value > 4)

// Display results.
printfn $"{singleObject} is the only value greater than 4"

// The example displays the following output:
//    Unhandled Exception: System.InvalidOperationException:
//       Sequence contains no matching element
//       at System.Linq.Enumerable.Single[TSource](IEnumerable`1 source, Func`2 predicate)
//       at <StartupCode$fs>.main()
// </Snippet10>