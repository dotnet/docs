module Iterating1

// <Snippet1>
open System

let numbers = ResizeArray [| 1; 2; 3; 4; 5 |]
for number in numbers do
    let square = Math.Pow(number, 2) |> int
    printfn $"{number}^{square}"
    printfn $"Adding {square} to the collection...\n"
    numbers.Add square

// The example displays the following output:
//    1^1
//    Adding 1 to the collection...
//
//
//    Unhandled Exception: System.InvalidOperationException: Collection was modified
//       enumeration operation may not execute.
//       at System.ThrowHelper.ThrowInvalidOperationException(ExceptionResource resource)
//       at System.Collections.Generic.List`1.Enumerator.MoveNextRare()
//       at <StartupCode$fs>.main()
// </Snippet1>