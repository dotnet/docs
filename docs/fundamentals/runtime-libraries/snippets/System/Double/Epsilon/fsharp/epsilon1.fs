module epsilon1

// <Snippet6>
open System

let getComponentParts (value: double) =
    let result = $"{value:R}: "
    let indent = result.Length

    // Convert the double to an 8-byte array.
    let bytes = BitConverter.GetBytes value
    // Get the sign bit (byte 7, bit 7).
    let result = result + $"""Sign: {if (bytes[7] &&& 0x80uy) = 0x80uy then "1 (-)" else "0 (+)"}\n"""

    // Get the exponent (byte 6 bits 4-7 to byte 7, bits 0-6)
    let exponent = (bytes[7] &&& 0x07Fuy) <<< 4
    let exponent = exponent ||| ((bytes[6] &&& 0xF0uy) >>> 4)
    let adjustment = if exponent <> 0uy then 1022 else 1023
    let result = result + $"{String(' ', indent)}Exponent: 0x{int exponent - adjustment:X4} ({int exponent - adjustment})\n"

    // Get the significand (bits 0-51)
    let significand = (bytes[6] &&& 0x0Fuy) <<< 48
    let significand = significand ||| byte (int64 bytes[5] <<< 40)
    let significand = significand ||| byte (int64 bytes[4] <<< 32)
    let significand = significand ||| byte (int64 bytes[3] <<< 24)
    let significand = significand ||| byte (int64 bytes[2] <<< 16)
    let significand = significand ||| byte (int64 bytes[1] <<< 8)
    let significand = significand ||| bytes[0]
    result + $"{String(' ', indent)}Mantissa: 0x{significand:X13}\n"

let values = [| 0.; Double.Epsilon |]
for value in values do
   printfn $"{getComponentParts value}"
   printfn ""


//       // The example displays the following output:
//       0: Sign: 0 (+)
//          Exponent: 0xFFFFFC02 (-1022)
//          Mantissa: 0x0000000000000
//
//
//       4.94065645841247E-324: Sign: 0 (+)
//                              Exponent: 0xFFFFFC02 (-1022)
//                              Mantissa: 0x0000000000001
// </Snippet6>