module Program

open System

[<EntryPoint>]
let main _ =
    let array = [| 2; 4; 6; 8; 10; 12; 14; 16; 18; 20 |]
    let slice = Span<int>(array, 2, 5)
    for i = 0 to slice.Length - 1 do
        slice[i] <- slice[i] * 2

    // Examine the original array values.
    for value in array do
        printf $"{value}  "
    printfn ""
    0
// The example displays the following output:
//      2  4  12  16  20  24  28  16  18  20