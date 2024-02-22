module compareto3

// <Snippet2>
let value1 = 16.5457f
let operand = 3.8899982f
let value2 = box (value1 * operand / operand)
printfn $"Comparing {value1} and {value2}: {value1.CompareTo value2}\n"
printfn $"Comparing {value1:R} and {value2:R}: {value1.CompareTo value2}"
// The example displays the following output:
//       Comparing 16.5457 and 16.5457: -1
//       
//       Comparing 16.5457 and 16.545702: -1
// </Snippet2>