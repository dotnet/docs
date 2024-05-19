module comparison3

// <Snippet11>
open System

let v1 = 0.333333333333333
let v2 = 1. / 3.
let precision = 7
let value1 = Math.Round(v1, precision)
let value2 = Math.Round(v2, precision)
printfn $"{value1:R} = {value2:R}: {value1.Equals value2}"
// The example displays the following output:
//        0.3333333 = 0.3333333: True
// </Snippet11>