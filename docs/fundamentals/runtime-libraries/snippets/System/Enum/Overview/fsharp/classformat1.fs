module classformat1

open System

type ArrivalStatus =
    | Unknown = -3
    | Late = -1
    | OnTime = 0
    | Early = 1

// <Snippet10>
let formats = [ "G"; "F"; "D"; "X" ]
let status = ArrivalStatus.Late
for fmt in formats do
    printfn $"{status.ToString fmt}"

// The example displays the following output:
//       Late
//       Late
//       -1
//       FFFFFFFF
// </Snippet10>