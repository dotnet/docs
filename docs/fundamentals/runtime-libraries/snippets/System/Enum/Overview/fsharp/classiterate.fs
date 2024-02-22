module classinterate

open System

type ArrivalStatus =
    | Unknown = -3
    | Late = -1
    | OnTime = 0
    | Early = 1

let getEnumByName () =
    // <Snippet11>
    let names = Enum.GetNames typeof<ArrivalStatus>
    printfn $"Members of {nameof ArrivalStatus}:"
    let names = Array.sort names
    for name in names do
        let status = Enum.Parse(typeof<ArrivalStatus>, name) :?> ArrivalStatus
        printfn $"   {status} ({status:D})"
    // The example displays the following output:
    //       Members of ArrivalStatus:
    //          Early (1)
    //          Late (-1)
    //          OnTime (0)
    //          Unknown (-3)
    // </Snippet11>

let getEnumByValue () =
    // <Snippet12>
    let values = Enum.GetValues typeof<ArrivalStatus>
    printfn $"Members of {nameof ArrivalStatus}:"
    for status in values do
        printfn $"   {status} ({status:D})"
    // The example displays the following output:
    //       Members of ArrivalStatus:
    //          OnTime (0)
    //          Early (1)
    //          Unknown (-3)
    //          Late (-1)
    // </Snippet12>

getEnumByName ()
printfn "-----"
getEnumByValue ()