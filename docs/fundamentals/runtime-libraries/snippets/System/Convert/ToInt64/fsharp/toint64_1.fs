open System

let convertBoolean () =
    // <Snippet1>
    let falseFlag = false
    let trueFlag = true

    printfn $"{falseFlag} converts to {Convert.ToInt64 falseFlag}."
    printfn $"{trueFlag} converts to {Convert.ToInt64 trueFlag}."

    // The example displays the following output:
    //       False converts to 0.
    //       True converts to 1.
    // </Snippet1>

let convertByte () =
    // <Snippet2>
    let bytes = [| Byte.MinValue; 14uy; 122uy; Byte.MaxValue |]

    for byteValue in bytes do
        let result = Convert.ToInt64 byteValue
        printfn $"Converted the {byteValue.GetType().Name} value {byteValue} to the {result.GetType().Name} value {result}."
    
    // The example displays the following output:
    //       Converted the Byte value 0 to the Int64 value 0.
    //       Converted the Byte value 14 to the Int64 value 14.
    //       Converted the Byte value 122 to the Int64 value 122.
    //       Converted the Byte value 255 to the Int64 value 255.
    // </Snippet2>

let convertChar () =
    // <Snippet3>
    let chars = [| 'a'; 'z'; '\u0007'; '\u03FF'; '\u7FFF'; '\uFFFE' |]

    for ch in chars do
        let result = Convert.ToInt64 ch
        printfn $"Converted the {ch.GetType().Name} value '{ch}' to the {result.GetType().Name} value {result}."
                        

    // The example displays the following output:
    //       Converted the Char value 'a' to the Int64 value 97.
    //       Converted the Char value 'z' to the Int64 value 122.
    //       Converted the Char value '' to the Int64 value 7.
    //       Converted the Char value 'Ͽ' to the Int64 value 1023.
    //       Converted the Char value '翿' to the Int64 value 32767.
    //       Converted the Char value '￾' to the Int64 value 65534.
    // </Snippet3>

let convertDecimal () =
    // <Snippet4>
    let values= 
        [| Decimal.MinValue; -1034.23M; -12M; 0M; 147M
           199.55M; 9214.16M; Decimal.MaxValue |]

    for value in values do
        try
            let result = Convert.ToInt64 value
            printfn $"Converted the {value.GetType().Name} value '{value}' to the {result.GetType().Name} value {result}." 
        with :? OverflowException ->
            printfn $"{value} is outside the range of the Int64 type."
        
    // The example displays the following output:
    //    -79228162514264337593543950335 is outside the range of the Int64 type.
    //    Converted the Decimal value '-1034.23' to the Int64 value -1034.
    //    Converted the Decimal value '-12' to the Int64 value -12.
    //    Converted the Decimal value '0' to the Int64 value 0.
    //    Converted the Decimal value '147' to the Int64 value 147.
    //    Converted the Decimal value '199.55' to the Int64 value 200.
    //    Converted the Decimal value '9214.16' to the Int64 value 9214.
    //    79228162514264337593543950335 is outside the range of the Int64 type.
    // </Snippet4>
   

let convertDouble () =
    // <Snippet5>
    let values= [| Double.MinValue; -1.38e10; -1023.299; -12.98
                   0; 9.113e-16; 103.919; 17834.191; Double.MaxValue |]

    for value in values do
        try
            let result = Convert.ToInt64 value
            printfn $"Converted the {value.GetType().Name} value '{value}' to the {result.GetType().Name} value {result}."
        with :? OverflowException ->
            printfn $"{value} is outside the range of the Int64 type."
        
    //    -1.7976931348623157E+308 is outside the range of the Int64 type.
    //    Converted the Double value '-13800000000' to the Int64 value -13800000000.
    //    Converted the Double value '-1023.299' to the Int64 value -1023.
    //    Converted the Double value '-12.98' to the Int64 value -13.
    //    Converted the Double value '0' to the Int64 value 0.
    //    Converted the Double value '9.113E-16' to the Int64 value 0.
    //    Converted the Double value '103.919' to the Int64 value 104.
    //    Converted the Double value '17834.191' to the Int64 value 17834.
    //    1.7976931348623157E+308 is outside the range of the Int64 type.
    // </Snippet5>

let convertInt16 () =
    // <Snippet6>
    let numbers = [| Int16.MinValue; -1s; 0s; 121s; 340s; Int16.MaxValue |]

    for number in numbers do
        let result = Convert.ToInt64 number
        printfn $"Converted the {number.GetType().Name} value {number} to a {result.GetType().Name} value {result}."

    // The example displays the following output:
    //    Converted the Int16 value -32768 to a Int32 value -32768.
    //    Converted the Int16 value -1 to a Int32 value -1.
    //    Converted the Int16 value 0 to a Int32 value 0.
    //    Converted the Int16 value 121 to a Int32 value 121.
    //    Converted the Int16 value 340 to a Int32 value 340.
    //    Converted the Int16 value 32767 to a Int32 value 32767.
    // </Snippet6>

let convertInt32 () =
    // <Snippet7>
    let numbers = [| Int32.MinValue; -1; 0; 121; 340; Int32.MaxValue |]
    
    for number in numbers do
        let result = Convert.ToInt64 number
        printfn $"Converted the {number.GetType().Name} value {number} to the {result.GetType().Name} value {result}."

    // The example displays the following output:
    //    Converted the Int32 value -2147483648 to the Int64 value -2147483648.
    //    Converted the Int32 value -1 to the Int64 value -1.
    //    Converted the Int32 value 0 to the Int64 value 0.
    //    Converted the Int32 value 121 to the Int64 value 121.
    //    Converted the Int32 value 340 to the Int64 value 340.
    //    Converted the Int32 value 2147483647 to the Int64 value 2147483647.
    // </Snippet7>

let convertObject () =
    // <Snippet8>
    let values: obj [] = 
        [| true; -12; 163; 935; 'x'; DateTime(2009, 5, 12); "104"
           "103.0"; "-1"; "1.00e2"; "One"; 1.00e2; 16.3e42 |]

    for value in values do
        try 
            let result = Convert.ToInt64 value
            printfn $"Converted the {value.GetType().Name} value {value} to the {result.GetType().Name} value {result}."
        with
        | :? OverflowException ->
            printfn $"The {value.GetType().Name} value {value} is outside the range of the Int64 type."
        | :? FormatException ->
            printfn $"The {value.GetType().Name} value {value} is not in a recognizable format."
        | :? InvalidCastException ->
            printfn $"No conversion to an Int64 exists for the {value.GetType().Name} value {value}."
        
    // The example displays the following output:
    //    Converted the Boolean value True to the Int64 value 1.
    //    Converted the Int32 value -12 to the Int64 value -12.
    //    Converted the Int32 value 163 to the Int64 value 163.
    //    Converted the Int32 value 935 to the Int64 value 935.
    //    Converted the Char value x to the Int64 value 120.
    //    No conversion to an Int64 exists for the DateTime value 5/12/2009 12:00:00 AM.
    //    Converted the String value 104 to the Int64 value 104.
    //    The String value 103.0 is not in a recognizable format.
    //    Converted the String value -1 to the Int64 value -1.
    //    The String value 1.00e2 is not in a recognizable format.
    //    The String value One is not in a recognizable format.
    //    Converted the Double value 100 to the Int64 value 100.
    //    The Double value 1.63E+43 is outside the range of the Int64 type.
    // </Snippet8>

let convertSByte () =
    // <Snippet9>
    let numbers = [| SByte.MinValue; -1y; 0y; 10y; SByte.MaxValue |]

    for number in numbers do
        let result = Convert.ToInt64 number
        printfn $"Converted the {number.GetType().Name} value {number} to the {result.GetType().Name} value {result}."

    // The example displays the following output:
    //       Converted the SByte value -128 to the Int64 value -128.
    //       Converted the SByte value -1 to the Int64 value -1.
    //       Converted the SByte value 0 to the Int64 value 0.
    //       Converted the SByte value 10 to the Int64 value 10.
    //       Converted the SByte value 127 to the Int64 value 127.
    // </Snippet9>

let convertSingle () =
    // <Snippet10>
    let values = [| Single.MinValue; -1.38e10f; -1023.299f; -12.98f
                    0f; 9.113e-16f; 103.919f; 17834.191f; Single.MaxValue |]

    for value in values do
    try
        let result = Convert.ToInt64 value
        printfn $"Converted the {value.GetType().Name} value '{value}' to the {result.GetType().Name} value {result}."
    with :? OverflowException ->
        printfn $"{value} is outside the range of the Int64 type."
        
    // The example displays the following output:
    //    -3.4028235E+38 is outside the range of the Int64 type.
    //    Converted the Single value -1.38E+10 to the Int64 value -13799999488.
    //    Converted the Single value -1023.299 to the Int64 value -1023.
    //    Converted the Single value -12.98 to the Int64 value -13.
    //    Converted the Single value 0 to the Int64 value 0.
    //    Converted the Single value 9.113E-16 to the Int64 value 0.
    //    Converted the Single value 103.919 to the Int64 value 104.
    //    Converted the Single value 17834.191 to the Int64 value 17834.
    //    3.4028235E+38 is outside the range of the Int64 type.
    // </Snippet10>

let convertString () =
    // <Snippet11>
    let values = 
        [| "One"; "1.34e28"; "-26.87"; "-18"; "-6.00"
           " 0"; "137"; "1601.9"; string Int32.MaxValue |]

    for value in values do
        try 
            let result = Convert.ToInt64 value
            printfn $"Converted the {value.GetType().Name} value {value} to the {result.GetType().Name} value {result}."
        with
        | :? OverflowException ->
            printfn $"The {value.GetType().Name} value {value} is outside the range of the Int64 type."
        | :? FormatException ->
            printfn $"The {value.GetType().Name} value {value} is not in a recognizable format."

    // The example displays the following output:
    //    The String value 'One' is not in a recognizable format.
    //    The String value '1.34e28' is not in a recognizable format.
    //    The String value '-26.87' is not in a recognizable format.
    //    Converted the String value '-18' to the Int64 value -18.
    //    The String value '-6.00' is not in a recognizable format.
    //    Converted the String value ' 0' to the Int64 value 0.
    //    Converted the String value '137' to the Int64 value 137.
    //    The String value '1601.9' is not in a recognizable format.
    //    Converted the String value '2147483647' to the Int64 value 2147483647.
    // </Snippet11>

let convertUInt16 () =
    // <Snippet12>
    let numbers = [| UInt16.MinValue; 121us; 340us; UInt16.MaxValue |]

    for value in numbers do
        try 
            let result = Convert.ToInt64 value
            printfn $"Converted the {value.GetType().Name} value {value} to the {result.GetType().Name} value {result}."
        with :? OverflowException ->
            printfn $"The {value.GetType().Name} value {value} is outside the range of the Int64 type."
    
    // The example displays the following output:
    //    Converted the UInt16 value 0 to the Int64 value 0.
    //    Converted the UInt16 value 121 to the Int64 value 121.
    //    Converted the UInt16 value 340 to the Int64 value 340.
    //    Converted the UInt16 value 65535 to the Int64 value 65535.
    // </Snippet12>

let convertUInt32 () =
    // <Snippet13>
    let numbers = [| UInt32.MinValue; 121u; 340u; UInt32.MaxValue |]
    
    for number in numbers do
        let result = Convert.ToInt64 number
        printfn $"Converted the {number.GetType().Name} value {number:N0} to the {result.GetType().Name} value {result:N0}."
    
    // The example displays the following output:
    //    Converted the UInt32 value 0 to the Int64 value 0.
    //    Converted the UInt32 value 121 to the Int64 value 121.
    //    Converted the UInt32 value 340 to the Int64 value 340.
    //    Converted the UInt32 value 4,294,967,295 to the Int64 value 4,294,967,295.
    // </Snippet13>

let convertUInt64 () =
    // <Snippet14>
    let numbers = [| UInt64.MinValue; 121uL; 340uL; UInt64.MaxValue |]
    
    for number in numbers do
        try
            let result = Convert.ToInt64 number
            printfn $"Converted the {number.GetType().Name} value {number} to a {result.GetType().Name} value {result}."
        with :? OverflowException ->
            printfn $"The {number.GetType().Name} value {number} is outside the range of the Int64 type."
        
    // The example displays the following output:
    //    Converted the UInt64 value 0 to a Int32 value 0.
    //    Converted the UInt64 value 121 to a Int32 value 121.
    //    Converted the UInt64 value 340 to a Int32 value 340.
    //    The UInt64 value 18446744073709551615 is outside the range of the Int64 type.
    // </Snippet14>s

convertBoolean ()
printfn "-----"
convertByte ()
printfn "-----"
convertChar ()
printfn "-----"
convertDecimal ()
printfn "-----"
convertDouble ()
printfn "-----"
convertInt16 ()
printfn "-----"
convertInt32 ()
printfn "-----"
convertObject ()
printfn "-----"
convertSByte ()
printfn "-----"
convertSingle ()
printfn "----"
convertString ()
printfn "-----"
convertUInt16 ()
printfn "-----"
convertUInt32 ()
printfn "-----"
convertUInt64 ()
