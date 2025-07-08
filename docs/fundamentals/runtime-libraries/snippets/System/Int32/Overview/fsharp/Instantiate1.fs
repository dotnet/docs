open System
open System.Numerics

let instantiateByAssignment () =
    // <Snippet1>
    let number1 = 64301
    let number2 = 25548612
    // </Snippet1>
    printfn $"{number1} - {number2}"

let instantiateByNarrowingConversion () =
    // <Snippet2>
    let lNumber = 163245617L
    try
        let number1 = int lNumber
        printfn $"{number1}"
    with :? OverflowException ->
        printfn "{lNumber} is out of range of an Int32."

    let dbl2 = 35901.997
    try
        let number2 = int dbl2
        printfn $"{number2}"
    with :? OverflowException ->
        printfn $"{dbl2} is out of range of an Int32."

    let bigNumber = BigInteger 132451
    try
        let number3 = int bigNumber
        printfn $"{number3}"
    with :? OverflowException ->
        printfn $"{bigNumber} is out of range of an Int32."

    // The example displays the following output:
    //       163245617
    //       35902
    //       132451
    // </Snippet2>

let parse () =
    // <Snippet3>
    let string1 = "244681"
    try
        let number1 = Int32.Parse string1
        printfn $"{number1}"
    with
    | :? OverflowException ->
        printfn "'{string1}' is out of range of a 32-bit integer."
    | :? FormatException ->
        printfn $"The format of '{string1}' is invalid."

    let string2 = "F9A3C"
    try
        let number2 = Int32.Parse(string2, System.Globalization.NumberStyles.HexNumber)
        printfn $"{number2}"
    with 
    | :? OverflowException ->
        printfn $"'{string2}' is out of range of a 32-bit integer."
    | :? FormatException ->
        printfn $"The format of '{string2}' is invalid."

    // The example displays the following output:
    //       244681
    //       1022524
    // </Snippet3>

let instantiateByWideningConversion () =
    // <Snippet4>
    let value1 = 124y
    let value2 = 1618s

    let number1 = int value1
    let number2 = int value2
    // </Snippet4>
    ()

instantiateByAssignment ()
printfn "----"
instantiateByNarrowingConversion ()
printfn "----"
parse ()
printfn "----"
instantiateByWideningConversion ()
   