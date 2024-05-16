module Extensions

//<snippet18>
open System
open System.Runtime.CompilerServices
// Define an enumeration to represent student grades.
type Grades =
    | F = 0
    | D = 1
    | C = 2
    | B = 3
    | A = 4

let mutable minPassing = Grades.D

// Define an extension method for the Grades enumeration.
[<Extension>]
type Extensions =
    [<Extension>]
    static member Passing(grade) = grade >= minPassing

let g1 = Grades.D
let g2 = Grades.F
printfn $"""{g1} {if g1.Passing() then "is" else "is not"} a passing grade."""
printfn $"""{g2} {if g2.Passing() then "is" else "is not"} a passing grade."""

minPassing <- Grades.C
printfn "\nRaising the bar!\n"
printfn $"""{g1} {if g1.Passing() then "is" else "is not"} a passing grade."""
printfn $"""{g2} {if g2.Passing() then "is" else "is not"} a passing grade."""
// The exmaple displays the following output:
//       D is a passing grade.
//       F is not a passing grade.
//
//       Raising the bar!
//
//       D is not a passing grade.
//       F is not a passing grade.
//</snippet18>