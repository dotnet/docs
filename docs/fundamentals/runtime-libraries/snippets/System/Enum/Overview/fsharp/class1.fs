module class1

// <Snippet1>
type ArrivalStatus =
    | Late = -1
    | OnTime = 0
    | Early = 1
// </Snippet1>

// <Snippet2>
let status = ArrivalStatus.OnTime
printfn $"Arrival Status: {status} ({status:D})"
// The example displays the following output:
//       Arrival Status: OnTime (0)
// </Snippet2>