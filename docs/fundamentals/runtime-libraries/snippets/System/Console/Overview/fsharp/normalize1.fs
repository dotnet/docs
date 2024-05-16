module normalize1

// <Snippet5>
open System

let chars = [| '\u0061'; '\u0308' |]

let combining = String chars
Console.WriteLine combining

let combining2 = combining.Normalize()
Console.WriteLine combining2


// The example displays the following output:
//       a"
//       ä
// </Snippet5>
