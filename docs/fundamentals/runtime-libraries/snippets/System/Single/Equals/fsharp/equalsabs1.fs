module equalsabs1 

// <Snippet1>
open System

let hasMinimalDifference (value1: float32) (value2: float32) units =
    let bytes = BitConverter.GetBytes value1
    let iValue1 = BitConverter.ToInt32(bytes, 0)
    let bytes = BitConverter.GetBytes(value2)
    let iValue2 = BitConverter.ToInt32(bytes, 0)
    
    // If the signs are different, return false except for +0 and -0.
    if (iValue1 >>> 31) <> (iValue2 >>> 31) then
        value1 = value2
    else
        let diff = abs (iValue1 - iValue2)
        diff <= units

let value1 = 0.1f * 10f
let value2 =
    List.replicate 10 0.1f
    |> List.sum
    
printfn $"{value1:R} = {value2:R}: {hasMinimalDifference value1 value2 1}"
// The example displays the following output:
//        1 = 1.0000001: True
// </Snippet1>
