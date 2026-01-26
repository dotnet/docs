module precision1

open System

// <Snippet1>
let value = -4.42330604244772E-305

let fromLiteral = -4.42330604244772E-305
let fromVariable = value
let fromParse = Double.Parse "-4.42330604244772E-305"

printfn $"Double value from literal: {fromLiteral,29:R}"
printfn $"Double value from variable: {fromVariable,28:R}"
printfn $"Double value from Parse method: {fromParse,24:R}"
// On 32-bit versions of the .NET Framework, the output is:
//    Double value from literal:        -4.42330604244772E-305
//    Double value from variable:       -4.42330604244772E-305
//    Double value from Parse method:   -4.42330604244772E-305
//
// On other versions of the .NET Framework, the output is:
//    Double value from literal:      -4.4233060424477198E-305
//    Double value from variable:     -4.4233060424477198E-305
//    Double value from Parse method:   -4.42330604244772E-305
// </Snippet1>