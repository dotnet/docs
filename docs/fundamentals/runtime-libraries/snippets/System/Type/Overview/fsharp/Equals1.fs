module Equals1

open System

// <Snippet3>
let number1 = 1635429L
let number2 = 16203
let number3 = 1639.41
let number4 = 193685412L

// Get the type of number1.
let t = number1.GetType()

// Compare types of all objects with number1.
printfn $"Type of number1 and number2 are equal: {Object.ReferenceEquals(t, number2.GetType())}"
printfn $"Type of number1 and number3 are equal: {Object.ReferenceEquals(t, number3.GetType())}"
printfn $"Type of number1 and number4 are equal: {Object.ReferenceEquals(t, number4.GetType())}"

// The example displays the following output:
//       Type of number1 and number2 are equal: False
//       Type of number1 and number3 are equal: False
//       Type of number1 and number4 are equal: True
// </Snippet3>