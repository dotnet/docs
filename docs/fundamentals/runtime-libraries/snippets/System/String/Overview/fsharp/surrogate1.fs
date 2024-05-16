module surrogate1.fs
// <Snippet3>
open System

let surrogate = "\uD800\uDC03"
for i = 0 to surrogate.Length - 1 do
    printf $"U+{uint16 surrogate[i]:X2} "

printfn $"\n   Is Surrogate Pair: {Char.IsSurrogatePair(surrogate[0], surrogate[1])}"
// The example displays the following output:
//       U+D800 U+DC03
//          Is Surrogate Pair: True
// </Snippet3>
