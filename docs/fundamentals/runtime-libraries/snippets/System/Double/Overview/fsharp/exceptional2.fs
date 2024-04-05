module exceptional2

// <Snippet2>
open System

let value1 = 4.565e153
let value2 = 6.9375e172
let result = value1 * value2
printfn $"PositiveInfinity: {Double.IsPositiveInfinity result}"
printfn $"NegativeInfinity: {Double.IsNegativeInfinity result}\n"

let value3 = - value1
let result2 = value2 * value3
printfn $"PositiveInfinity: {Double.IsPositiveInfinity result2}"
printfn $"NegativeInfinity: {Double.IsNegativeInfinity result2}"

// The example displays the following output:
//       PositiveInfinity: True
//       NegativeInfinity: False
//
//       PositiveInfinity: False
//       NegativeInfinity: True
// </Snippet2>