module starting2

open System

let showFormatted () =
    // <Snippet36>
    let pricePerOunce = 17.36m
    String.Format("The current price is {0:C2} per ounce.", pricePerOunce)
    |> printfn "%s"
    // Result if current culture is en-US:
    //      The current price is $17.36 per ounce.
    // </Snippet36>

// <Snippet35>
let pricePerOunce = 17.36m
String.Format("The current price is {0} per ounce.", pricePerOunce)
|> printfn "%s"
// Result: The current price is 17.36 per ounce.
// </Snippet35>
showFormatted ()
