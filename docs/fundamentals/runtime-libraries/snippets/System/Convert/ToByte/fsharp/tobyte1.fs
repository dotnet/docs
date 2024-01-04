// <Snippet4>
open System

let numbers = [| Int32.MinValue; -1; 0; 121; 340; Int32.MaxValue |]

for number in numbers do
    try
        let result = Convert.ToByte number
        printfn $"Converted the {number.GetType().Name} value {number} to the {result.GetType().Name} value {result}."

    with :? OverflowException ->
        printfn $"The {number.GetType().Name} value {number} is outside the range of the Byte type."


// The example displays the following output:
//       The Int32 value -2147483648 is outside the range of the Byte type.
//       The Int32 value -1 is outside the range of the Byte type.
//       Converted the Int32 value 0 to the Byte value 0.
//       Converted the Int32 value 121 to the Byte value 121.
//       The Int32 value 340 is outside the range of the Byte type.
//       The Int32 value 2147483647 is outside the range of the Byte type.
// </Snippet4>
