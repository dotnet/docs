module NonDecimal

// <Snippet2>
open System

let baseValues = [ 2; 8; 10; 16 ]
let value = Int16.MaxValue
for baseValue in baseValues do
    let s = Convert.ToString(value, baseValue)
    let value2 = Convert.ToInt16(s, baseValue)
    printfn $"{value} --> {s} (base {baseValue}) --> {value2}"

// The example displays the following output:
//     32767 --> 111111111111111 (base 2) --> 32767
//     32767 --> 77777 (base 8) --> 32767
//     32767 --> 32767 (base 10) --> 32767
//     32767 --> 7fff (base 16) --> 32767
// </Snippet2>