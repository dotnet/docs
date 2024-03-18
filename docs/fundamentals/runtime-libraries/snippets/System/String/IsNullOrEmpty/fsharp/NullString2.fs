namespace IsNullOrEmpty
open System

module NullString2 =

    // <Snippet3>
    let s = ""
    printfn "The length of '%s' is %d." s s.Length

    // The example displays the following output:
    //       The length of '' is 0.
    // </Snippet3>
