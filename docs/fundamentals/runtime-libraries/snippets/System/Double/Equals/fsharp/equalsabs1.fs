module equalsabs

// <Snippet1>
open System

let hasMinimalDifference (value1: double) (value2: double) (units: int) =
    let lValue1 = BitConverter.DoubleToInt64Bits value1
    let lValue2 = BitConverter.DoubleToInt64Bits value2

    // If the signs are different, return false except for +0 and -0.
    if (lValue1 >>> 63) <> (lValue2 >>> 63) then
        value1 = value2
    else
        let diff = abs (lValue1 - lValue2)

        diff <= int64 units

let value1 = 0.1 * 10.
let mutable value2 = 0.
for _ = 0 to 9 do
    value2 <- value2 + 0.1

printfn $"{value1:R} = {value2:R}: {hasMinimalDifference value1 value2 1}"
                

// The example displays the following output:
//        1 = 0.99999999999999989: True
// </Snippet1>