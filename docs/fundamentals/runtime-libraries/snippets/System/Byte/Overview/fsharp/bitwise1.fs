module bitwise1

// <Snippet1>
open System
open System.Globalization

let values = 
    [ Convert.ToString(12, 16)
      Convert.ToString(123, 16)
      Convert.ToString(245, 16) ]

let mask = 0xFEuy
for value in values do
    let byteValue = Byte.Parse(value, NumberStyles.AllowHexSpecifier)
    printfn $"{byteValue} And {mask} = {byteValue &&& mask}"
                    

// The example displays the following output:
//       12 And 254 = 12
//       123 And 254 = 122
//       245 And 254 = 244
// </Snippet1>