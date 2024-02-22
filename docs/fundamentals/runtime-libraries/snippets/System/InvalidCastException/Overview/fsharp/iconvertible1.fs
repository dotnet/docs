module iconvertible1

// <Snippet2>
open System

let flag = true
try
    let conv: IConvertible = flag
    let ch = conv.ToChar null
    printfn "Conversion succeeded."
with :? InvalidCastException ->
    printfn "Cannot convert a Boolean to a Char."

try
    let ch = Convert.ToChar flag
    printfn "Conversion succeeded."
with :? InvalidCastException ->
    printfn "Cannot convert a Boolean to a Char."

// The example displays the following output:
//       Cannot convert a Boolean to a Char.
//       Cannot convert a Boolean to a Char.
// </Snippet2>