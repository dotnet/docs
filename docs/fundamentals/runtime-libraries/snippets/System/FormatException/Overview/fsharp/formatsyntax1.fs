module formatsyntax1

// <Snippet12>
open System

String.Format("{0,-10:C}", 126347.89m)         
|> printfn "%s"
// </Snippet12>