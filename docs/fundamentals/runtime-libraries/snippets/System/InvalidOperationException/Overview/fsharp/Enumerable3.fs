module Enumerable3

// <Snippet8>
open System
open System.Linq

let dbQueryResults = [| 1; 2; 3; 4 |]

let firstNum = dbQueryResults.First(fun n -> n > 4)

printfn $"The first value greater than 4 is {firstNum}"

// The example displays the following output:
//    Unhandled Exception: System.InvalidOperationException:
//       Sequence contains no matching element
//       at System.Linq.Enumerable.First[TSource](IEnumerable`1 source, Func`2 predicate)
//       at <StartupCode$fs>.main()
// </Snippet8>