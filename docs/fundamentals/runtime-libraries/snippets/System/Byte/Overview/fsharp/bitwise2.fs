module bitwise2

// <Snippet2>
open System
open System.Collections.Generic
open System.Globalization

[<Struct>]
type ByteString =
    { Sign: int
      Value: string }

let createArray values =
    [ for value in values do
        let sign = sign value
        { Sign = sign
         // Change two's complement to magnitude-only representation.
          Value = Convert.ToString(value * sign, 16)} ]


let values = createArray [ -15; 123; 245 ]

let mask = 0x14uy        // Mask all bits but 2 and 4.

for strValue in values do
    let byteValue = Byte.Parse(strValue.Value, NumberStyles.AllowHexSpecifier)
    printfn $"{strValue.Sign * int byteValue} ({Convert.ToString(byteValue, 2)}) And {mask} ({Convert.ToString(mask, 2)}) = {(strValue.Sign &&& (int mask |> sign)) * int (byteValue &&& mask)} ({Convert.ToString(byteValue &&& mask, 2)})"

// The example displays the following output:
//       -15 (1111) And 20 (10100) = 4 (100)
//       123 (1111011) And 20 (10100) = 16 (10000)
//       245 (11110101) And 20 (10100) = 20 (10100)
// </Snippet2>