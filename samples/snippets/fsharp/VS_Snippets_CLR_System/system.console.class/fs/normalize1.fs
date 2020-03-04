// <Snippet5>
module Example

open System;

[<EntryPoint>]
let main argv =
   let chars = [| '\u0061'; '\u0308' |]

   let combining = String(chars)
   Console.WriteLine(combining)
   
   let combining = combining.Normalize()
   Console.WriteLine(combining)
   0

// The example displays the following output:
//       a"
//       ä
// </Snippet5>
