module qa3

open System

let willThrow () =
    let nOpen = 1
    let nClose = 2
    // <Snippet23>
    let result = 
        String.Format("The text has {0} '{' characters and {1} '}' characters.", nOpen, nClose)
    // </Snippet23>
    ()

let wontThrow () =
    let nOpen = 1
    let nClose = 2
    // <Snippet24>
    let result =
        String.Format("The text has {0} '{{' characters and {1} '}}' characters.", nOpen, nClose)
    // </Snippet24>
    ()

let recommended () =
    let nOpen = 1
    let nClose = 2
    // <Snippet25>
    let result =
        String.Format("The text has {0} '{1}' characters and {2} '{3}' characters.", nOpen, "{", nClose, "}")
    // </Snippet25>
    ()

willThrow ()
printfn ""
wontThrow ()
printfn ""
recommended ()
