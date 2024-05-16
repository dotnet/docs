module epsilon

// <Snippet5>
open System

let values = [ 0f; Single.Epsilon; Single.Epsilon * 0.5f ]

for i = 0 to values.Length - 2 do
    for i2 = i + 1 to values.Length - 1 do
        printfn $"{values[i]:r} = {values[i2]:r}: {values[i].Equals(values[i2])}"
    printfn ""
// The example displays the following output:
//       0 = 1.401298E-45: False
//       0 = 0: True
//       
//       1.401298E-45 = 0: False
// </Snippet5>