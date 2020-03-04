// <Snippet1>
module Example

open System

[<EntryPoint>]
let main argv =
    // Create a char List for the modern Cyrillic alphabet,
    // from U+0410 to U+044F.
    let chars =
        [ for codePoint in 0x0410 .. 0x044F do
            Convert.ToChar(codePoint) ]

    printfn "Current code page: %i\n" Console.OutputEncoding.CodePage
    // Display the characters.
    for ch in chars do
        printf "%c  " ch
        if (Console.CursorLeft) >= 70 then Console.WriteLine()

    0
// The example displays the following output:
//    Current code page: 437
//
//    ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?
//    ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?
//    ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?
// </Snippet1>