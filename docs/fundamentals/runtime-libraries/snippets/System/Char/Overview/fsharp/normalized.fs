module normalized

// <Snippet5>
open System

let showString (s: string) =
    printf $"Length of string: {s.Length} ("
    for i = 0 to s.Length - 1 do
        printf $"U+{Convert.ToUInt16 s[i]:X4}"
        if i <> s.Length - 1 then printf " "
    printfn ")\n"

let combining = "\u0061\u0308"
showString combining

let normalized = combining.Normalize()
showString normalized

// The example displays the following output:
//       Length of string: 2 (U+0061 U+0308)
//
//       Length of string: 1 (U+00E4)
// </Snippet5>