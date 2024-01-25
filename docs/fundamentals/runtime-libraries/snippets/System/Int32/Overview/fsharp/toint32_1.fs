open System

// <Snippet4>
let values = 
    [| Decimal.MinValue; -1034.23M; -12m; 0M; 147M
       199.55M; 9214.16M; Decimal.MaxValue |]

for value in values do
    try
        let result = Convert.ToInt32 value
        printfn $"Converted the {value.GetType().Name} value '{value}' to the {result.GetType().Name} value {result}."
        
    with :? OverflowException ->
        printfn $"{value} is outside the range of the Int32 type."
   
// The example displays the following output:
//    -79228162514264337593543950335 is outside the range of the Int32 type.
//    Converted the Decimal value '-1034.23' to the Int32 value -1034.
//    Converted the Decimal value '-12' to the Int32 value -12.
//    Converted the Decimal value '0' to the Int32 value 0.
//    Converted the Decimal value '147' to the Int32 value 147.
//    Converted the Decimal value '199.55' to the Int32 value 200.
//    Converted the Decimal value '9214.16' to the Int32 value 9214.
//    79228162514264337593543950335 is outside the range of the Int32 type.
// </Snippet4>