open System

let callToString () =
    // <Snippet1>
    let numbers = [| -1403L; 0L; 169L; 1483104L |]
    for number in numbers do
        // Display value using default formatting.
        printf $"{number.ToString(),-8}  -->   "
        // Display value with 3 digits and leading zeros.
        printf $"{number,8:D3}"
        // Display value with 1 decimal digit.
        printf $"{number,13:N1}"
        // Display value as hexadecimal.
        printf $"{number,18:X2}"
        // Display value with eight hexadecimal digits.
        printfn $"{number,18:X8}"

    // The example displays the following output:
    //    -1403     -->      -1403     -1,403.0  FFFFFFFFFFFFFA85  FFFFFFFFFFFFFA85
    //    0         -->        000          0.0                00          00000000
    //    169       -->        169        169.0                A9          000000A9
    //    1483104   -->    1483104  1,483,104.0            16A160          0016A160
    // </Snippet1>

let callConvert () =
    // <Snippet2>
    let numbers = [| -146L; 11043L; 2781913L |]
    for number in numbers do
        printfn $"{number} (Base 10):"
        printfn $"   Binary:  {Convert.ToString(number, 2)}"
        printfn $"   Octal:   {Convert.ToString(number, 8)}"
        printfn $"   Hex:     {Convert.ToString(number, 16)}\n"
    
    // The example displays the following output:
    //    -146 (Base 10):
    //       Binary:  1111111111111111111111111111111111111111111111111111111101101110
    //       Octal:   1777777777777777777556
    //       Hex:     ffffffffffffff6e
    //
    //    11043 (Base 10):
    //       Binary:  10101100100011
    //       Octal:   25443
    //       Hex:     2b23
    //
    //    2781913 (Base 10):
    //       Binary:  1010100111001011011001
    //       Octal:   12471331
    //       Hex:     2a72d9
    // </Snippet2>

callToString ()
printfn "-----"
callConvert ()