//<Snippet1>
module ExceptionTestModule

open System

let x = 0
try
    let y = 100 / x
    ()
with
| :? ArithmeticException as e ->
    printfn $"ArithmeticException Handler: {e}"
| e ->
    printfn $"Generic Exception Handler: {e}"

// This code example produces the following results:
//     ArithmeticException Handler: System.DivideByZeroException: Attempted to divide by zero.
//        at <StartupCode$fs>.$ExceptionTestModule.main@()
//</Snippet1>