module epsilon1

// <Snippet6>
open System

let getComponentParts (value: float32) =
    let result = $"{value:R}: "
    let indent = result.Length

    // Convert the single to a 4-byte array.
    let bytes = BitConverter.GetBytes value
    let formattedSingle = BitConverter.ToInt32(bytes, 0)
    
    // Get the sign bit (byte 3, bit 7).
    let result = result + $"""Sign: {if formattedSingle >>> 31 <> 0 then "1 (-)" else "0 (+)"}\n""" 

    // Get the exponent (byte 2 bit 7 to byte 3, bits 6)
    let exponent =  (formattedSingle >>> 23) &&& 0x000000FF
    let adjustment = if exponent <> 0 then 127 else 126
    let result = result + $"{String(' ', indent)}Exponent: 0x{1:X4} ({exponent - adjustment})\n"

    // Get the significand (bits 0-22)
    let significand = 
        if exponent <> 0 then 
            (formattedSingle &&& 0x007FFFFF) ||| 0x800000
        else 
            formattedSingle &&& 0x007FFFFF
             
    result + $"{String(' ', indent)}Mantissa: 0x{significand:X13}\n"


let values = [ 0f; Single.Epsilon ]
for value in values do
    printfn $"{getComponentParts value}\n"
//       // The example displays the following output:
//       0: Sign: 0 (+)
//          Exponent: 0xFFFFFF82 (-126)
//          Mantissa: 0x0000000000000
//       
//       
//       1.401298E-45: Sign: 0 (+)
//                     Exponent: 0xFFFFFF82 (-126)
//                     Mantissa: 0x0000000000001
// </Snippet6>                     