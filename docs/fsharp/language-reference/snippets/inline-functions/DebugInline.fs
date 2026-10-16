module DebugInline

// <DebugInline>
let inline addFee (fee: decimal) (amount: decimal) =
    let total = amount + fee
    total

let invoiceTotal = addFee 2m 40m
printfn "%M" invoiceTotal
// 42
// </DebugInline>

do if invoiceTotal <> 42m then failwith "Invoice total"
