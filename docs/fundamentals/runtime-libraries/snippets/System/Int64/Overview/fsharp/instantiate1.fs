open System
open System.Globalization
open System.Numerics

let instantiateByAssignment () =
    // <Snippet1>
    let number1 = -64301728L
    let number2 = 255486129307L
    // </Snippet1>
    printfn $"{number1} - {number2}"


let instantiateByNarrowingConversion () =
    // <Snippet2>
    let ulNumber = 163245617943825uL
    try
        let number1 = int64 ulNumber
        printfn $"{number1}"
    with :? OverflowException ->
        printfn $"{ulNumber} is out of range of an Int64."

    let dbl2 = 35901.997
    try
        let number2 = int64 dbl2
        printfn $"{number2}"
    with :? OverflowException ->
        printfn $"{dbl2} is out of range of an Int64."

    let bigNumber = BigInteger 1.63201978555e30
    try
        let number3 = int64 bigNumber
        printfn $"{number3}"
    with :? OverflowException ->
        printfn $"{bigNumber} is out of range of an Int64."

    // The example displays the following output:
    //    163245617943825
    //    35902
    //    1,632,019,785,549,999,969,612,091,883,520 is out of range of an Int64.
    // </Snippet2>

let parse () =
    // <Snippet3>
    let string1 = "244681903147"
    try
        let number1 = Int64.Parse string1
        printfn $"{number1}"
    with
    | :? OverflowException ->
        printfn $"'{string1}' is out of range of a 64-bit integer."
    | :? FormatException ->
        printfn $"The format of '{string1}' is invalid."

    let string2 = "F9A3CFF0A"
    try
        let number2 = Int64.Parse(string2, NumberStyles.HexNumber)
        printfn $"{number2}"

    with
    | :? OverflowException ->
        printfn $"'{string2}' is out of range of a 64-bit integer."
    | :? FormatException ->
        printfn $"The format of '{string2}' is invalid."

    // The example displays the following output:
    //    244681903147
    //    67012198154
    // </Snippet3>

let instantiateByWideningConversion () =
    // <Snippet4>
    let value1 = 124y
    let value2 = 1618s
    let value3 = Int32.MaxValue

    let number1 = int64 value1
    let number2 = int64 value2
    let number3: int64 = value3
    // </Snippet4>
    ()


instantiateByAssignment ()
printfn "----"
instantiateByNarrowingConversion ()
printfn "----"
parse ()
printfn "----"
instantiateByWideningConversion ()