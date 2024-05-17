module converter

open System

// <Snippet1>
let dNumber = 23.15

try
    // Returns 23
    Convert.ToInt32 dNumber
    |> ignore
with :? OverflowException ->
    printfn "Overflow in double to int conversion."
// Returns True
let bNumber = System.Convert.ToBoolean dNumber

// Returns "23.15"
let strNumber = System.Convert.ToString dNumber

try
    // Returns '2'
    System.Convert.ToChar strNumber[0]
    |> ignore
with
| :? ArgumentNullException ->
    printfn "String is null"
| :? FormatException ->
    printfn "String length is greater than 1."

// System.Console.ReadLine() returns a string and it
// must be converted.
let newInteger =
    try
        printfn "Enter an integer:"
        System.Convert.ToInt32(Console.ReadLine())
    with
    | :? ArgumentNullException ->
        printfn "String is null."
        0
    | :? FormatException ->
        printfn "String does not consist of an optional sign followed by a series of digits."
        0
    | :? OverflowException ->
        printfn "Overflow in string to int conversion."
        0

printfn $"Your integer as a double is {System.Convert.ToDouble newInteger}"
//</Snippet1>