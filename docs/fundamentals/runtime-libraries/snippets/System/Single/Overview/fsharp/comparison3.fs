module comparison3

// <Snippet11>
open System

let value1 = 0.3333333f
let value2 = 1f / 3f
let precision = 7
let value1r = Math.Round(float value1, precision) |> float32
let value2r = Math.Round(float value2, precision) |> float32
printfn $"{value1:R} = {value2:R}: {value1.Equals value2}"
// The example displays the following output:
//        0.3333333 = 0.3333333: True
// </Snippet11>