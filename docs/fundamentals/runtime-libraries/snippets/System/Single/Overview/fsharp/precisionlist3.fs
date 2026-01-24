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
    
// The example displays the following output on .NET:
//      The sum of the values (27.650002) does not equal the total (27.65).
// The example displays the following output on .NET Framework:
//      The sum of the values (27.65) does not equal the total (27.65).
// </Snippet6>
