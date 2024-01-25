module qa28

// <Snippet28>
open System

let value = 16342
String.Format("{0,18:00000000} {0,18:00000000.000} {0,18:000,0000,000.0}", value)
|> printfn "%s"
// The example displays the following output:
//           00016342       00016342.000    0,000,016,342.0
// </Snippet28>