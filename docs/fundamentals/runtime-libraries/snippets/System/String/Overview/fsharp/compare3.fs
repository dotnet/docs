module compare3.fs
// <Snippet13>
open System

let findInString (s: string) (substring: string) (options: StringComparison) =
    let result = s.IndexOf(substring, options)
    if result <> -1 then
        printfn $"'{substring}' found in {s} at position {result}"
    else
        printfn $"'{substring}' not found in {s}"

// Search for "oe" and "œu" in "œufs" and "oeufs".
let s1 = "œufs"
let s2 = "oeufs"
findInString s1 "oe" StringComparison.CurrentCulture
findInString s1 "oe" StringComparison.Ordinal
findInString s2 "œu" StringComparison.CurrentCulture
findInString s2 "œu" StringComparison.Ordinal
printfn ""

let s3 = "co\u00ADoperative"
findInString s3 "\u00AD" StringComparison.CurrentCulture
findInString s3 "\u00AD" StringComparison.Ordinal

// The example displays the following output:
//       'oe' found in œufs at position 0
//       'oe' not found in œufs
//       'œu' found in oeufs at position 0
//       'œu' not found in oeufs
//
//       '­' found in co­operative at position 0
//       '­' found in co­operative at position 2
// </Snippet13>
