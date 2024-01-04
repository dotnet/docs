module Example6

// <Snippet6>
open System
open System.Reflection

[<assembly: AssemblyVersion("2.0.0.0")>]
do ()

module StringLibrary =
    let substringStartsAt (fullString: string) (substr: string) =
        fullString.IndexOf(substr, StringComparison.CurrentCulture)

// </Snippet6>

// <Snippet7>
let value = "The archaeologist"
let substring = "archæ"

let position =
    StringLibrary.substringStartsAt value substring

if position >= 0 then
    printfn $"'{substring}' found in '{value}' starting at position {position}"
else
    printfn $"'{substring}' not found in '{value}'"

// The example displays the following output:
//       'archæ' found in 'The archaeologist' starting at position 4
// </Snippet7>