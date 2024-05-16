module Enumerable1

// <Snippet6>
open System
open System.Linq

let data = [| 1; 2; 3; 4 |]
let average = 
   data.Where(fun num -> num > 4).Average();
printfn $"The average of numbers greater than 4 is {average}"
// The example displays the following output:
//    Unhandled Exception: System.InvalidOperationException: Sequence contains no elements
//       at System.Linq.Enumerable.Average(IEnumerable`1 source)
//       at <StartupCode$fs>.main()
// </Snippet6>