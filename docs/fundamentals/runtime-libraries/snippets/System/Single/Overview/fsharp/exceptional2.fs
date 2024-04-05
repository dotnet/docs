module exceptional2

// <Snippet2>
open System

let value1 = 3.065e35f
let value2 = 6.9375e32f
let result = value1 * value2
printfn $"PositiveInfinity: {Single.IsPositiveInfinity result}" 
printfn $"NegativeInfinity: {Single.IsNegativeInfinity result}\n"

let value3 = -value1
let result2 = value3 * value2
printfn $"PositiveInfinity: {Single.IsPositiveInfinity result}" 
printfn $"NegativeInfinity: {Single.IsNegativeInfinity result}" 

// The example displays the following output:
//       PositiveInfinity: True
//       NegativeInfinity: False
//       
//       PositiveInfinity: False
//       NegativeInfinity: True
// </Snippet2>