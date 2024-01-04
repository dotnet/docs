open System

let ``instantiate by assignment`` =
    // <Snippet1>
    let value1 = 64uy
    let value2 = 255uy
    // </Snippet1>
    ()

let ``instantiateByNarrowingConversion`` =
    // <Snippet2>
    let int1 = 128
    try
        let value1 = byte int1
        printfn $"{value1}"
    with :? OverflowException ->
        printfn $"{int1} is out of range of a byte."

    let dbl2 = 3.997
    try
        let value2 = byte dbl2
        printfn $"{value2}"
    with :? OverflowException ->
        printfn $"{dbl2} is out of range of a byte."

    // The example displays the following output:
    //       128
    //       3
    // </Snippet2>

let parse =
    // <Snippet3>
    let string1 = "244"
    try
        let byte1 = Byte.Parse string1
        printfn $"{byte1}" 
    with
    | :? OverflowException ->
        printfn $"'{string1}' is out of range of a byte."
    | :? FormatException ->
        printfn $"'{string1}' is out of range of a byte."

    let string2 = "F9"
    try
        let byte2 = Byte.Parse(string2, System.Globalization.NumberStyles.HexNumber)
        printfn $"{byte2}"
    with
    | :? OverflowException ->
        printfn $"'{string2}' is out of range of a byte."
    | :? FormatException ->
        printfn $"'{string2}' is out of range of a byte."

    // The example displays the following output:
    //       244
    //       249
    // </Snippet3>