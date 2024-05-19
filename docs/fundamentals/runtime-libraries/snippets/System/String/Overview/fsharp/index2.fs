module index2.fs
open System

// <Snippet5>
let s1 = "This string consists of a single short sentence."
let mutable nWords = 0

for ch in s1 do
    if Char.IsPunctuation ch || Char.IsWhiteSpace ch then
        nWords <- nWords + 1
printfn $"The sentence\n   {s1}\nhas {nWords} words."
// The example displays the following output:
//       The sentence
//          This string consists of a single short sentence.
//       has 8 words.
// </Snippet5>
