module representation1

// <Snippet3>
let value = 0.2f
let result1 = value * 10f
let mutable result2 = 0f
for _ = 1 to 10 do
    result2 <- result2 + value

printfn $".2 * 10:           {result1:R}"
printfn $".2 Added 10 times: {result2:R}"
// The example displays the following output:
//       .2 * 10:           2
//       .2 Added 10 times: 2.00000024
// </Snippet3>