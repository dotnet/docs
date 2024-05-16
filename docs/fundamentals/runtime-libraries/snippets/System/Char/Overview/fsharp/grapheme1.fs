module grapheme1

// <Snippet1>
open System
open System.IO

let sw = new StreamWriter("chars1.txt")
let chars = [| '\u0061'; '\u0308' |]
let string = String chars
sw.WriteLine string
sw.Close()

// The example produces the following output:
//       ä
// </Snippet1>