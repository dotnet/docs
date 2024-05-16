module class2

type ArrivalStatus =
    | Late = -1
    | OnTime = 0
    | Early = 1

// <Snippet3>
let status1 = ArrivalStatus()
printfn $"Arrival Status: {status1} ({status1:D})"
// The example displays the following output:
//       Arrival Status: OnTime (0)
// </Snippet3>

// <Snippet4>
let status2 = enum<ArrivalStatus> 1
printfn $"Arrival Status: {status2} ({status2:D})"
// The example displays the following output:
//       Arrival Status: Early (1)
// </Snippet4>

// <Snippet5>
let value3 = 2
let status3 = enum<ArrivalStatus> value3

let value4 = int status3
// </Snippet5>

// <Snippet6>
let number = -1
let arrived = ArrivalStatus.ToObject(typeof<ArrivalStatus>, number) :?> ArrivalStatus
// </Snippet6>