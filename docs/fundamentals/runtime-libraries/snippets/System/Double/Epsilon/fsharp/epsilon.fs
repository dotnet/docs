module epsilon

// <Snippet5>
open System

let values = [| 0.; Double.Epsilon; Double.Epsilon * 0.5 |]

for i = 0 to values.Length - 2 do
    for i2 = i + 1 to values.Length - 1 do
        printfn $"{values[i]:r} = {values[i2]:r}: {values[i].Equals values[i2]}"
    printfn ""
// The example displays the following output:
//       0 = 4.94065645841247E-324: False
//       0 = 0: True
//
//       4.94065645841247E-324 = 0: False
// </Snippet5>