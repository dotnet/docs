module comparison4

// <Snippet12>
open System

let isApproximatelyEqual (value1: double) (value2: double) (epsilon: double) =
    // If they are equal anyway, just return True.
    if value1.Equals value2 then 
        true
    else
        // Handle NaN, Infinity.
        if Double.IsInfinity value1 || Double.IsNaN value1 then 
            value1.Equals value2
        elif Double.IsInfinity value2 || Double.IsNaN value2 then
            value1.Equals value2
        else
            // Handle zero to avoid division by zero
            let divisor = max value1 value2
            let divisor = 
                if divisor.Equals 0 then
                    min value1 value2
                else 
                    divisor
            abs ((value1 - value2) / divisor) <= epsilon

let one1 = 0.1 * 10.
let mutable one2 = 0.
for _ = 1 to 10 do
    one2 <- one2 + 0.1

printfn $"{one1:R} = {one2:R}: {one1.Equals one2}"
printfn $"{one1:R} is approximately equal to {one2:R}: {isApproximatelyEqual one1 one2 0.000000001}"

// The example displays the following output:
//       1 = 0.99999999999999989: False
//       1 is approximately equal to 0.99999999999999989: True
// </Snippet12>