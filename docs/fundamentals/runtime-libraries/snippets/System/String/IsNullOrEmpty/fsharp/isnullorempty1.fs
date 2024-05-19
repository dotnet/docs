namespace IsNullOrEmpty
open System

module IsNullOrEmpty1 =

    // <Snippet1>
    let testForNullOrEmpty (s: string): bool =
        s = null || s = String.Empty

    let s1 = null
    let s2 = ""

    printfn "%b" (testForNullOrEmpty s1)
    printfn "%b" (testForNullOrEmpty s2)

    // The example displays the following output:
    //    true
    //    true
    // </Snippet1>
