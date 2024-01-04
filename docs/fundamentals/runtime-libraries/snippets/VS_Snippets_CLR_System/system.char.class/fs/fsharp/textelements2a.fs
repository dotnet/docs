module textelements2a

// <Snippet4>
open System
open System.Globalization

let result =
    [ for i in 0x10107..0x10110 do  // Range of Aegean numbers.
        Char.ConvertFromUtf32 i ]
    |> String.concat ""


let si = StringInfo result
printfn $"The string contains {si.LengthInTextElements} characters."

// The example displays the following output:
//       The string contains 10 characters.
// </Snippet4>