module textelements2

// <Snippet3>
open System

let result =
    [ for i in 0x10107..0x10110 do  // Range of Aegean numbers.
        Char.ConvertFromUtf32 i ]
    |> String.concat ""

printfn $"The string contains {result.Length} characters."


// The example displays the following output:
//     The string contains 20 characters.
// </Snippet3>