module tobyte1

open System

let convertBoolean () =
      // <Snippet1>
      let falseFlag = false
      let trueFlag = true

      printfn $"{falseFlag} converts to {Convert.ToByte falseFlag}."
      printfn $"{trueFlag} converts to {Convert.ToByte trueFlag}."
      // The example displays the following output:
      //       False converts to 0.
      //       True converts to 1.
      // </Snippet1>

let convertChar () =
    // <Snippet2>
    let chars = [| 'a'; 'z'; '\u0007'; '\u03FF' |]
    for ch in chars do
        try
            let result = Convert.ToByte ch
            printfn $"{ch} is converted to {result}."
        with :? OverflowException ->
            printfn $"Unable to convert u+{Convert.ToInt16 ch:X4} to a byte."
    // The example displays the following output:
    //       a is converted to 97.
    //       z is converted to 122.
    //        is converted to 7.
    //       Unable to convert u+03FF to a byte.
    // </Snippet2>

let convertInt16 () =
    // <Snippet3>
    let numbers = [| Int16.MinValue; -1s; 0s; 121s; 340s; Int16.MaxValue |]
    for number in numbers do
        try
            let result = Convert.ToByte number
            printfn $"Converted the {number.GetType().Name} value {number} to the {result.GetType().Name} value {result}."
        with :? OverflowException ->
            printfn $"The {number.GetType().Name} value {number} is outside the range of the Byte type."
    // The example displays the following output:
    //       The Int16 value -32768 is outside the range of the Byte type.
    //       The Int16 value -1 is outside the range of the Byte type.
    //       Converted the Int16 value 0 to the Byte value 0.
    //       Converted the Int16 value 121 to the Byte value 121.
    //       The Int16 value 340 is outside the range of the Byte type.
    //       The Int16 value 32767 is outside the range of the Byte type.
    // </Snippet3>

let convertInt32 () =
    // <Snippet4>
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

let convertInt64 () =
    // <Snippet5>
    let numbers = [| Int64.MinValue; -1L; 0L; 121L; 34L; Int64.MaxValue |]
    for number in numbers do
        try
            let result = Convert.ToByte number
            printfn $"Converted the {number.GetType().Name} value {number} to the {result.GetType().Name} value {result}."
        with :? OverflowException ->
            printfn $"The {number.GetType().Name} value {number} is outside the range of the Byte type."
    // The example displays the following output:
    //       The Int64 value -9223372036854775808 is outside the range of the Byte type.
    //       The Int64 value -1 is outside the range of the Byte type.
    //       Converted the Int64 value 0 to the Byte value 0.
    //       Converted the Int64 value 121 to the Byte value 121.
    //       The Int64 value 340 is outside the range of the Byte type.
    //       The Int64 value 9223372036854775807 is outside the range of the Byte type.
    // </Snippet5>

let convertObject () =
    // <Snippet6>
    let values: obj[] = 
        [| true; -12; 163; 935; 'x'; "104"; "103.0" 
           "-1"; "1.00e2"; "One"; 1.00e2 |]
    for value in values do
        try
            let result = Convert.ToByte value
            printfn $"Converted the {value.GetType().Name} value {value} to the {result.GetType().Name} value {result}."
        with
        | :? OverflowException ->
            printfn $"The {value.GetType().Name} value {value} is outside the range of the Byte type."
        | :? FormatException ->
            printfn $"The {value.GetType().Name} value {value} is not in a recognizable format."
        | :? InvalidCastException ->
            printfn $"No conversion to a Byte exists for the {value.GetType().Name} value {value}."
    // The example displays the following output:
    //       Converted the Boolean value True to the Byte value 1.
    //       The Int32 value -12 is outside the range of the Byte type.
    //       Converted the Int32 value 163 to the Byte value 163.
    //       The Int32 value 935 is outside the range of the Byte type.
    //       Converted the Char value x to the Byte value 120.
    //       Converted the String value 104 to the Byte value 104.
    //       The String value 103.0 is not in a recognizable format.
    //       The String value -1 is outside the range of the Byte type.
    //       The String value 1.00e2 is not in a recognizable format.
    //       The String value One is not in a recognizable format.
    //       Converted the Double value 100 to the Byte value 100.
    // </Snippet6>

let convertSByte () =
    // <Snippet7>
    let numbers = [| SByte.MinValue; -1y; 0y; 10y; SByte.MaxValue |]
    for number in numbers do
        try
            let result = Convert.ToByte number
            printfn $"Converted the {number.GetType().Name} value {number} to the {result.GetType().Name} value {result}."
        with :? OverflowException ->
            printfn $"The {number.GetType().Name} value {number} is outside the range of the Byte type."
    // The example displays the following output:
    //       The SByte value -128 is outside the range of the Byte type.
    //       The SByte value -1 is outside the range of the Byte type.
    //       Converted the SByte value 0 to the Byte value 0.
    //       Converted the SByte value 10 to the Byte value 10.
    //       Converted the SByte value 127 to the Byte value 127.
    // </Snippet7>

let convertUInt16 () =
    // <Snippet8>
    let numbers = [| UInt16.MinValue; 121us; 340us; UInt16.MaxValue |]
    for number in numbers do
        try
            let result = Convert.ToByte number
            printfn $"Converted the {number.GetType().Name} value {number} to the {result.GetType().Name} value {result}."
        with :? OverflowException ->
            printfn $"The {number.GetType().Name} value {number} is outside the range of the Byte type."
    // The example displays the following output:
    //       Converted the UInt16 value 0 to the Byte value 0.
    //       Converted the UInt16 value 121 to the Byte value 121.
    //       The UInt16 value 340 is outside the range of the Byte type.
    //       The UInt16 value 65535 is outside the range of the Byte type.
    // </Snippet8>

let convertUInt32 () =
    // <Snippet9>
    let numbers = [| UInt32.MinValue; 121u; 340u; UInt32.MaxValue |]
    for number in numbers do
        try
            let result = Convert.ToByte number
            printfn $"Converted the {number.GetType().Name} value {number} to the {result.GetType().Name} value {result}."
        with :? OverflowException ->
            printfn $"The {number.GetType().Name} value {number} is outside the range of the Byte type."
    // The example displays the following output:
    //       Converted the UInt32 value 0 to the Byte value 0.
    //       Converted the UInt32 value 121 to the Byte value 121.
    //       The UInt32 value 340 is outside the range of the Byte type.
    //       The UInt32 value 4294967295 is outside the range of the Byte type.
    // </Snippet9>

let convertUInt64 () =
    // <Snippet10>
    let numbers= [| UInt64.MinValue; 121uL; 340uL; UInt64.MaxValue |]
    for number in numbers do
        try
            let result = Convert.ToByte number
            printfn $"Converted the {number.GetType().Name} value {number} to the {result.GetType().Name} value {result}."
        with :? OverflowException ->
            printfn $"The {number.GetType().Name} value {number} is outside the range of the Byte type."
    // The example displays the following output:
    //       Converted the UInt64 value 0 to the Byte value 0.
    //       Converted the UInt64 value 121 to the Byte value 121.
    //       The UInt64 value 340 is outside the range of the Byte type.
    //       The UInt64 value 18446744073709551615 is outside the range of the Byte type.
    // </Snippet10>

convertBoolean ()
printfn "-----"
convertChar ()
printfn "-----"
convertInt16 ()
printfn "-----"
convertInt32 ()
printfn "-----"
convertInt64 ()
printfn "-----"
convertObject ()
printfn "-----"
convertSByte ()
printfn "-----"
convertUInt16 ()
printfn "-----"
convertUInt32 ()
printfn "-----"
convertUInt64 ()
