// <Snippet1>
module Example

open System
open System.IO

[<EntryPoint>]
let main argv =
    use sw = new StreamWriter("chars1.txt")
    let chars = [| '\u0061'; '\u0308' |]
    let strng = String(chars)
    sw.WriteLine(strng)
    sw.Close()
    0
// The example produces the following output:
//       ä
// </Snippet1>

