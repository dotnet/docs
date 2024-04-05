module classparse1

open System

type ArrivalStatus =
    | Unknown = -3
    | Late = -1
    | OnTime = 0
    | Early = 1

// <Snippet9>
let number = "-1"
let name = "Early"

try
    let status1 = Enum.Parse(typeof<ArrivalStatus>, number) :?> ArrivalStatus
    let status1 =
        if not (Enum.IsDefined(typeof<ArrivalStatus>, status1) ) then
            ArrivalStatus.Unknown
        else 
            status1
        
    printfn $"Converted '{number}' to {status1}"
with :? FormatException ->
    printfn $"Unable to convert '{number}' to an ArrivalStatus value."

match Enum.TryParse<ArrivalStatus> name with
| true, status2 ->
    let status2 = 
        if not (Enum.IsDefined(typeof<ArrivalStatus>, status2) ) then
            ArrivalStatus.Unknown
        else 
            status2
    printfn $"Converted '{name}' to {status2}"
| _ ->
    printfn $"Unable to convert '{number}' to an ArrivalStatus value."
// The example displays the following output:
//       Converted '-1' to Late
//       Converted 'Early' to Early
// </Snippet9>