module tostring2

// <Snippet4>
let raining = false
let busLate = true

printfn $"""It is raining: %s{if raining then "Yes" else "No"}"""
printfn $"""The bus is late: %s{if busLate then "Yes" else "No"}"""

// The example displays the following output:
//       It is raining: No
//       The bus is late: Yes
// </Snippet4>