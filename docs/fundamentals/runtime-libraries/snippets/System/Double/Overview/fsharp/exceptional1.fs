module exceptional1

// <Snippet1>
let value1 = 1.1632875981534209e-225
let value2 = 9.1642346778e-175
let result = value1 * value2
printfn $"{value1} * {value2} = {result}"
printfn $"{result} = 0: {result.Equals 0.0}"
// The example displays the following output:
//       1.16328759815342E-225 * 9.1642346778E-175 = 0
//       0 = 0: True
// </Snippet1>