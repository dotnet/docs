module percisionlist1

// <Snippet5>
let value1 = 1. / 3.
let sValue2 = 1f / 3f
let value2 = double sValue2
printfn $"{value1:R} = {value2:R}: {value1.Equals value2}"

// The example displays the following output on .NET:
//     0.3333333333333333 = 0.3333333432674408: False
// </Snippet5>
