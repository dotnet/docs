module Booleans1

// <Snippet8>
open System

type BooleanGenerator() =
    let rnd = Random()

    member _.NextBoolean() =
        rnd.Next(0, 2) = 1

let boolGen = BooleanGenerator()
let mutable totalTrue, totalFalse = 0, 0

for _ = 1 to 1000000 do
    let value = boolGen.NextBoolean()
    if value then 
        totalTrue <- totalTrue + 1
    else 
        totalFalse <- totalFalse + 1

printfn $"Number of true values:  {totalTrue,7:N0} ({(double totalTrue) / double (totalTrue + totalFalse):P3})"
printfn $"Number of false values: {totalFalse,7:N0} ({(double totalFalse) / double (totalTrue + totalFalse):P3})"

// The example displays output like the following:
//       Number of true values:  500,004 (50.000 %)
//       Number of false values: 499,996 (50.000 %)
// </Snippet8>
