module Nullable2

// <Snippet5>
open System
open System.Linq

let queryResult = [| Nullable 1; Nullable 2; Nullable(); Nullable 4 |]
let numbers = queryResult.Select(fun nullableInt -> nullableInt.GetValueOrDefault())

// Display list using Nullable<int>.HasValue.
for number in numbers do
    printf $"{number} "
printfn ""

let numbers2 = queryResult.Select(fun nullableInt -> if nullableInt.HasValue then nullableInt.Value else -1)
// Display list using Nullable<int>.GetValueOrDefault.
for number in numbers2 do
    printf $"{number} "
printfn ""
// The example displays the following output:
//       1 2 0 4
//       1 2 -1 4
// </Snippet5>