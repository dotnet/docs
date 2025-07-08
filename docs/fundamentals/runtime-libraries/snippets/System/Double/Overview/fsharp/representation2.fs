module representation2

// <Snippet4>
open System

let value = 123456789012.34567
let additional = Double.Epsilon * 1e15
printfn $"{value} + {additional} = {value + additional}"
// The example displays the following output:
//    123456789012.346 + 4.94065645841247E-309 = 123456789012.346
// </Snippet4>