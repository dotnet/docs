namespace IsNullOrEmpty
open System

module NullString1 =

    // <Snippet2>
    let (s: string) = null

    printfn "The value of the string is '%s'" s

    try
        printfn "String length is %d" s.Length
    with
        | :? NullReferenceException as ex -> printfn "%s" ex.Message

    // The example displays the following output:
    //     The value of the string is ''
    //     Object reference not set to an instance of an object.
    // </Snippet2>
