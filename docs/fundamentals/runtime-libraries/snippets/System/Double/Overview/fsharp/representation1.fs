module representation1

// <Snippet3>
let value = 0.1
let result1 = value * 10.
let mutable result2 = 0.
for i = 1 to 10 do
    result2 <- result2 + value

printfn $".1 * 10:           {result1:R}"
printfn $".1 Added 10 times: {result2:R}"
// The example displays the following output:
//       .1 * 10:           1
//       .1 Added 10 times: 0.99999999999999989
// </Snippet3>