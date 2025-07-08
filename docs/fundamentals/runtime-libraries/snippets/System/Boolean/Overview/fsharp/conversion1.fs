module conversion1

// <Snippet6>
open System

let byteValue = 12uy
printfn $"{Convert.ToBoolean byteValue}"
let byteValue2 = 0uy
printfn $"{Convert.ToBoolean byteValue2}"
let intValue = -16345
printfn $"{Convert.ToBoolean intValue}"
let longValue = 945L
printfn $"{Convert.ToBoolean longValue}"
let sbyteValue = -12y
printfn $"{Convert.ToBoolean sbyteValue}"
let dblValue = 0.0
printfn $"{Convert.ToBoolean dblValue}"
let sngValue = 0.0001f
printfn $"{Convert.ToBoolean sngValue}"

// The example displays the following output:
//       True
//       False
//       True
//       True
//       True
//       False
//       True
// </Snippet6>