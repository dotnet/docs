module flags

//<Snippet1>
open System

// Define an Enum without FlagsAttribute.
type SingleHue =
    | None = 0
    | Black = 1
    | Red = 2
    | Green = 4
    | Blue = 8

// Define an Enum with FlagsAttribute.
[<Flags>]
type MultiHue =
    | None = 0
    | Black = 1
    | Red = 2
    | Green = 4
    | Blue = 8

// Display all possible combinations of values.
printfn "All possible combinations of values without FlagsAttribute:"
for i = 0 to 16 do
    printfn $"{i,3} - {enum<SingleHue> i:G}"

// Display all combinations of values, and invalid values.
printfn "\nAll possible combinations of values with FlagsAttribute:"
for i = 0 to 16 do
    printfn $"{i,3} - {enum<MultiHue> i:G}"

// The example displays the following output:
//       All possible combinations of values without FlagsAttribute:
//         0 - None
//         1 - Black
//         2 - Red
//         3 - 3
//         4 - Green
//         5 - 5
//         6 - 6
//         7 - 7
//         8 - Blue
//         9 - 9
//        10 - 10
//        11 - 11
//        12 - 12
//        13 - 13
//        14 - 14
//        15 - 15
//        16 - 16
//
//       All possible combinations of values with FlagsAttribute:
//         0 - None
//         1 - Black
//         2 - Red
//         3 - Black, Red
//         4 - Green
//         5 - Black, Green
//         6 - Red, Green
//         7 - Black, Red, Green
//         8 - Blue
//         9 - Black, Blue
//        10 - Red, Blue
//        11 - Black, Red, Blue
//        12 - Green, Blue
//        13 - Black, Green, Blue
//        14 - Red, Green, Blue
//        15 - Black, Red, Green, Blue
//        16 - 16
//</Snippet1>