module Iterating2

// <Snippet2>
open System
open System.Collections.Generic

let numbers = ResizeArray [| 1; 2; 3; 4; 5 |]

let upperBound = numbers.Count - 1
for i = 0 to upperBound do
    let square = Math.Pow(numbers[i], 2) |> int
    printfn $"{numbers[i]}^{square}"
    printfn $"Adding {square} to the collection...\n"
    numbers.Add square

printfn "Elements now in the collection: "
for number in numbers do
    printf $"{number}    "
// The example displays the following output:
//    1^1
//    Adding 1 to the collection...
//
//    2^4
//    Adding 4 to the collection...
//
//    3^9
//    Adding 9 to the collection...
//
//    4^16
//    Adding 16 to the collection...
//
//    5^25
//    Adding 25 to the collection...
//
//    Elements now in the collection:
//    1    2    3    4    5    1    4    9    16    25
// </Snippet2>