open System

let callToString () =
    // <Snippet1>
    let numbers = [| 0; 16; 104; 213 |]
    for number in numbers do
        // Display value using default formatting.
        number.ToString()
        |> printf "%-3s  -->   "

        // Display value with 3 digits and leading zeros.
        number.ToString "D3"
        |> printf "%s   "
        
        // Display value with hexadecimal.
        number.ToString "X2"
        |> printf "%s   "
        
        // Display value with four hexadecimal digits.
        number.ToString "X4"
        |> printfn "%s"

    // The example displays the following output:
    //       0    -->   000   00   0000
    //       16   -->   016   10   0010
    //       104  -->   104   68   0068
    //       213  -->   213   D5   00D5
    // </Snippet1>

let callConvert () =
    // <Snippet2>
    let numbers = [| 0; 16; 104; 213 |]
    printfn "%s   %8s   %5s   %5s" "Value" "Binary" "Octal" "Hex"
    for number in numbers do
        printfn $"%5i{number}   %8s{Convert.ToString(number, 2)}   %5s{Convert.ToString(number, 8)}   %5s{Convert.ToString(number, 16)}"
                        
    // The example displays the following output:
    //       Value     Binary   Octal     Hex
    //           0          0       0       0
    //          16      10000      20      10
    //         104    1101000     150      68
    //         213   11010101     325      d5
    // </Snippet2>

callToString ()
printfn "-----"
callConvert ()