module compareto2

// <Snippet1>
let value1 = 6.185
let value2 = value1 * 0.1 / 0.1
printfn $"Comparing {value1} and {value2}: {value1.CompareTo value2}\n"
printfn $"Comparing {value1:R} and {value2:R}: {value1.CompareTo value2}"
// The example displays the following output:
//       Comparing 6.185 and 6.185: -1
//
//       Comparing 6.185 and 6.1850000000000005: -1
// </Snippet1>