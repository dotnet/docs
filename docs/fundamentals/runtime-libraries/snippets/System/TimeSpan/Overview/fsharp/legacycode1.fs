module legacycode1

open System

// <Snippet1>
let showFormattingCode () =
    let interval = TimeSpan(12, 30, 45)
    try
        $"{interval:r}"
    with :? FormatException ->
        "Invalid Format"
    |> printfn "%s"

let showParsingCode () =
    let value = "000000006"
    try
        let interval = TimeSpan.Parse value
        printfn $"{value} --> {interval}"
    with
    | :? FormatException ->
        printfn $"{value}: Bad Format"
    | :? OverflowException ->
        printfn $"{value}: Overflow"

showFormattingCode ()
// Output from .NET Framework 3.5 and earlier versions:
//       12:30:45
// Output from .NET Framework 4:
//       Invalid Format    

printfn "---"

showParsingCode ()
// Output:
//       000000006 --> 6.00:00:00

// </Snippet1>   