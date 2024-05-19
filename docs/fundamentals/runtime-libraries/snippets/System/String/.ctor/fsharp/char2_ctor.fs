module char2_ctor

// <Snippet3>
#nowarn "9"
open System
open FSharp.NativeInterop

let characters = 
    [| 'H'; 'e'; 'l'; 'l'; 'o'; ' '
       'w'; 'o'; 'r'; 'l'; 'd'; '!'; '\u0000' |]

[<EntryPoint>]
let main _ =
    use charPtr = fixed characters
    let mutable length = 0
    let mutable iterator = charPtr
    let mutable broken = false
    while not broken && NativePtr.read iterator <> '\u0000' do
        if NativePtr.read iterator = '!' || NativePtr.read iterator = '.' then
            broken <- true
        else
            iterator <- NativePtr.add iterator 1
            length <- length + 1
    String(charPtr, 0, length)
    |> printfn "%s"
    0
// The example displays the following output:
//      Hello World
// </Snippet3>