module comparison4

// <Snippet12>
open System

let isApproximatelyEqual value1 value2 epsilon =
    // If they are equal anyway, just return True.
    if value1.Equals value2 then 
        true
    // Handle NaN, Infinity.
    elif Single.IsInfinity value1 || Single.IsNaN value1 then
        value1.Equals value2
    elif Single.IsInfinity value2 || Single.IsNaN value2 then
        value1.Equals value2
    else
        // Handle zero to avoid division by zero
        let divisor = max value1 value2
        let divisor = 
            if divisor.Equals 0 then
                min value1 value2
            else divisor
        abs (value1 - value2) / divisor <= epsilon           


let one1 = 0.1f * 10f
let mutable one2 = 0f
for _ = 1 to 10 do
   one2 <- one2 + 0.1f

printfn $"{one1:R} = {one2:R}: {one1.Equals one2}"
printfn $"{one1:R} is approximately equal to {one2:R}: {isApproximatelyEqual one1 one2 0.000001f}" 
// The example displays the following output:
//       1 = 1.00000012: False
//       1 is approximately equal to 1.00000012: True
// </Snippet12>