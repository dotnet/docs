module classconversion2

open System

type ArrivalStatus =
    | Unknown = -3
    | Late = -1
    | OnTime = 0
    | Early = 1

// <Snippet8>
let status = ArrivalStatus.Early
let number = Convert.ChangeType(status, Enum.GetUnderlyingType typeof<ArrivalStatus>)
printfn $"Converted {status} to {number}"
// The example displays the following output:
//       Converted Early to 1
// </Snippet8>