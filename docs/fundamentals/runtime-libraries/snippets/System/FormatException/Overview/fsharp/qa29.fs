module qa29

// <Snippet29>
open System

let value = 1326
String.Format("{0,10:D6} {0,10:X8}", value)
|> printfn "%s"
// The example displays the following output:
//     001326   0000052E
// </Snippet29>