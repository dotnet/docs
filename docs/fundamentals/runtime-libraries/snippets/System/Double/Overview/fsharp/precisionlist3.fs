module precisionlist3

// <Snippet6>
let values = [ 10.0; 2.88; 2.88; 2.88; 9.0 ]
let result = 27.64
let total = List.sum values

if total.Equals result then
    printfn "The sum of the values equals the total."
else
    printfn $"The sum of the values ({total}) does not equal the total ({result})."
// The example displays the following output:
//      The sum of the values (36.64) does not equal the total (36.64).
//
// If the index items in the Console.WriteLine statement are changed to {0:R},
// the example displays the following output:
//       The sum of the values (27.639999999999997) does not equal the total (27.64).
// </Snippet6>