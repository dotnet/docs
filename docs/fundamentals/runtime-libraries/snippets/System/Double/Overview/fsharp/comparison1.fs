module comparison1

// <Snippet9>
open System

let value1 = 0.333333333333333
let value2 = 1. / 3.
printfn $"{value1:R} = {value2:R}: {value1.Equals value2}"
// The example displays the following output:
//        0.333333333333333 = 0.33333333333333331: False
// </Snippet9>