module precisionlist3

// <Snippet6>
let values = [| 10.01f; 2.88f; 2.88f; 2.88f; 9f |]
let result = 27.65f
let mutable total = 0f
for value in values do
    total <- total + value

if total.Equals result then
    printfn "The sum of the values equals the total."
else
    printfn "The sum of the values ({total}) does not equal the total ({result})."
// The example displays the following output:
//      The sum of the values (27.65) does not equal the total (27.65).   
//
// If the index items in the Console.WriteLine statement are changed to {0:R},
// the example displays the following output:
//       The sum of the values (27.6500015) does not equal the total (27.65).   
// </Snippet6>