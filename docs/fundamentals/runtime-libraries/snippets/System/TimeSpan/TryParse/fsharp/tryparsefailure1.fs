module tryparsefailure

open System

// <Snippet3>
let value = "000000006"
match TimeSpan.TryParse value with
| true, interval ->
    printfn $"{value} --> {interval}"
| _ ->
    printfn $"Unable to parse '{value}'"
    
// Output from .NET Framework 3.5 and earlier versions:
//       000000006 --> 6.00:00:00
// Output from .NET Framework 4:
//       Unable to parse //000000006//
// </Snippet3>