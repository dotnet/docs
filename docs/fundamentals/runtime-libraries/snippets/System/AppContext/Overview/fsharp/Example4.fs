module Example4

// <Snippet4>
open System
open System.Reflection

[<assembly: AssemblyVersion("1.0.0.0")>]
do ()

module StringLibrary =
    let substringStartsAt (fullString: string) (substr: string) =
        fullString.IndexOf(substr, StringComparison.Ordinal)

// </Snippet4>

// <Snippet5>
let value = "The archaeologist"
let substring = "archæ"

let position =
    StringLibrary.substringStartsAt value substring

if position >= 0 then
    printfn $"'{substring}' found in '{value}' starting at position {position}"
else
    printfn $"'{substring}' not found in '{value}'"

// The example displays the following output:
//       'archæ' not found in 'The archaeologist'
// </Snippet5>
