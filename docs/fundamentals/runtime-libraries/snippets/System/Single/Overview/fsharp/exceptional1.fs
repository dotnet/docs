module exceptional1

// <Snippet1>
let value1 = 1.163287e-36f
let value2 = 9.164234e-25f
let result = value1 * value2
printfn $"{value1} * {value2} = {result}"
printfn $"{result} = 0: {result.Equals(0f)}"
// The example displays the following output:
//       1.163287E-36 * 9.164234E-25 = 0
//       0 = 0: True
// </Snippet1>