module surrogate1

// <Snippet2>
open System
open System.IO

let showCodePoints (value: char seq) =
    let str =
        value
        |> Seq.map (fun ch -> $"U+{Convert.ToUInt16 ch:X4}")
        |> String.concat ""
    str.Trim()

let sw = new StreamWriter(@".\chars2.txt")
let utf32 = 0x1D160
let surrogate = Char.ConvertFromUtf32 utf32
sw.WriteLine $"U+{utf32:X6} UTF-32 = {surrogate} ({showCodePoints surrogate}) UTF-16"
sw.Close()

// The example produces the following output:
//       U+01D160 UTF-32 = ð (U+D834 U+DD60) UTF-16
// </Snippet2>