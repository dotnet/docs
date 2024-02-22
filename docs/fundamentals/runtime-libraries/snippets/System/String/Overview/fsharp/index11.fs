module index11.fs
open System

// <Snippet4>
let s1 = "This string consists of a single short sentence."
let mutable nWords = 0

for i = 0 to s1.Length - 1 do
    if Char.IsPunctuation s1[i] || Char.IsWhiteSpace s1[i] then
        nWords <- nWords + 1
printfn $"The sentence\n   {s1}\nhas {nWords} words."
// The example displays the following output:
//       The sentence
//          This string consists of a single short sentence.
//       has 8 words.
// </Snippet4>
