module classconversion1

// <Snippet7>
open System

type ArrivalStatus =
    | Unknown = -3
    | Late = -1
    | OnTime = 0
    | Early = 1

let values = [ -3; -1; 0; 1; 5; Int32.MaxValue ]
for value in values do
    let status =
        if Enum.IsDefined(typeof<ArrivalStatus>, value) then
            enum value
        else
            ArrivalStatus.Unknown
    printfn $"Converted {value:N0} to {status}"
// The example displays the following output:
//       Converted -3 to Unknown
//       Converted -1 to Late
//       Converted 0 to OnTime
//       Converted 1 to Early
//       Converted 5 to Unknown
//       Converted 2,147,483,647 to Unknown
// </Snippet7>