module parsefailure1

// <Snippet3>
open System

let values = [| "000000006"; "12.12:12:12.12345678" |]
for value in values do
    try
        let interval = TimeSpan.Parse value
        printfn $"{value} --> {interval}"   
    with
    | :? FormatException ->
        printfn $"{value}: Bad Format"
    | :? OverflowException ->
        printfn $"{value}: Overflow"

// Output from .NET Framework 3.5 and earlier versions:
//       000000006 --> 6.00:00:00
//       12.12:12:12.12345678: Bad Format      
// Output from .NET Framework 4 and later versions or .NET Core:
//       000000006: Overflow
//       12.12:12:12.12345678: Overflow
// </Snippet3>