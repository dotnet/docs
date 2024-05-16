module DecimalDivision_46630_1

open System

let divideWithoutRounding () =
    // <Snippet1>
    let dividend = Decimal.One
    let divisor = 3m
    // The following displays 0.9999999999999999999999999999 to the console
    printfn $"{dividend/divisor * divisor}"
    // </Snippet1>

let divideWithRounding () =
    // <Snippet2>
    let dividend = Decimal.One
    let divisor = 3m
    // The following displays 1.00 to the console
    printfn $"{Math.Round(dividend/divisor * divisor, 2)}"
    // </Snippet2>

divideWithoutRounding ()
divideWithRounding () 