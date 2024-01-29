module ctor2

// <Snippet2>
#nowarn "9"
open System

let characters = 
    [| 'H'; 'e'; 'l'; 'l'; 'o'; ' ' 
       'w'; 'o'; 'r'; 'l'; 'd'; '!'; '\u0000' |]

let value =
    use charPtr = fixed characters
    String charPtr

printfn $"{value}"
// The example displays the following output:
//        Hello world!
// </Snippet2>