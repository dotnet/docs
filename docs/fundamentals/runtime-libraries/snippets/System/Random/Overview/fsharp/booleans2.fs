module Booleans2

open System

// <Snippet20>
let rnd = Random()

let nextBool () =
    rnd.Next(0, 2) = 1

let mutable totalTrue, totalFalse = 0, 0

for _ = 1 to 1000000 do
    let value = nextBool ()
    if value then 
        totalTrue <- totalTrue + 1
    else 
        totalFalse <- totalFalse + 1

printfn $"Number of true values:  {totalTrue,7:N0} ({(double totalTrue) / double (totalTrue + totalFalse):P3})"
printfn $"Number of false values: {totalFalse,7:N0} ({(double totalFalse) / double (totalTrue + totalFalse):P3})"

// The example displays output like the following:
//       Number of true values:  499,777 (49.978 %)
//       Number of false values: 500,223 (50.022 %)
// </Snippet20>
