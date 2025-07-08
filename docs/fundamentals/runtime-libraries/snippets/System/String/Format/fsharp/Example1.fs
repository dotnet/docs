module Example1

// <Snippet1>
open System

let values= [| Int16.MinValue; -27s; 0s; 1042s; Int16.MaxValue |]
printfn "%10s  %10s\n" "Decimal" "Hex"
for value in values do
    String.Format("{0,10:G}: {0,10:X}", value)
    |> printfn "%s"
// The example displays the following output:
//       Decimal         Hex
//    
//        -32768:       8000
//           -27:       FFE5
//             0:          0
//          1042:        412
//         32767:       7FFF
// </Snippet1>