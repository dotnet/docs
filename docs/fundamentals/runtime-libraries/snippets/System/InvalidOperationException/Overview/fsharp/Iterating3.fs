module Iterating3

// <Snippet3>
open System
open System.Collections.Generic

let numbers = ResizeArray [| 1; 2; 3; 4; 5 |]
let temp = ResizeArray()

// Square each number and store it in a temporary collection.
for number in numbers do
    let square = Math.Pow(number, 2) |> int
    temp.Add square

// Combine the numbers into a single array.
let combined = Array.zeroCreate<int> (numbers.Count + temp.Count)
Array.Copy(numbers.ToArray(), 0, combined, 0, numbers.Count)
Array.Copy(temp.ToArray(), 0, combined, numbers.Count, temp.Count)

// Iterate the array.
for value in combined do
    printf $"{value}    "
// The example displays the following output:
//       1    2    3    4    5    1    4    9    16    25
// </Snippet3>