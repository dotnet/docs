module index3.fs
// <Snippet6>
open System
open System.Globalization

// First sentence of The Mystery of the Yellow Room, by Leroux.
let opening = "Ce n'est pas sans une certaine émotion que je commence à raconter ici les aventures extraordinaires de Joseph Rouletabille."
// Character counters.
let mutable nChars = 0
// Objects to store word count.
let chars = ResizeArray<int>()
let elements = ResizeArray<int>()

for ch in opening do
    // Skip the ' character.
    if ch <> '\u0027' then
        if Char.IsWhiteSpace ch || Char.IsPunctuation ch then
            chars.Add nChars
            nChars <- 0
        else
            nChars <- nChars + 1

let te = StringInfo.GetTextElementEnumerator opening
while te.MoveNext() do
    let s = te.GetTextElement()
    // Skip the ' character.
    if s <> "\u0027" then
        if String.IsNullOrEmpty(s.Trim()) || (s.Length = 1 && Char.IsPunctuation(Convert.ToChar s)) then
            elements.Add nChars
            nChars <- 0
        else
            nChars <- nChars + 1

// Display character counts.
printfn "%6s %20s %20s" "Word #" "Char Objects " "Characters"
for i = 0 to chars.Count - 1 do
    printfn "%6d %20d %20d" i chars[i] elements[i]
// The example displays the following output:
//       Word #         Char Objects           Characters
//            0                    2                    2
//            1                    4                    4
//            2                    3                    3
//            3                    4                    4
//            4                    3                    3
//            5                    8                    8
//            6                    8                    7
//            7                    3                    3
//            8                    2                    2
//            9                    8                    8
//           10                    2                    1
//           11                    8                    8
//           12                    3                    3
//           13                    3                    3
//           14                    9                    9
//           15                   15                   15
//           16                    2                    2
//           17                    6                    6
//           18                   12                   12
// </Snippet6>
