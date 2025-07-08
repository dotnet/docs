module qa27

open System

// <Snippet27>
let value = 16309.5436m
String.Format("{0,12:#.00000} {0,12:0,000.00} {0,12:000.00#}", value)
|> printfn "%s"
// The example displays the following output:
//        16309.54360    16,309.54    16309.544
// </Snippet27>