module representation2

// <Snippet4>
open System

let value = 123.456f
let additional = Single.Epsilon * 1e15f
printfn $"{value} + {additional} = {value + additional}"
// The example displays the following output:
//    123.456 + 1.401298E-30 = 123.456
// </Snippet4>