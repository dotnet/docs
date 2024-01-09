module basetoderived1

// <Snippet1>
open System

type Person() =
    member val Name = String.Empty with get, set

type PersonWithId() =
    inherit Person()
    member val Id = String.Empty with get, set


let p = Person()
p.Name <- "John"
try
    let pid = p :?> PersonWithId
    printfn "Conversion succeeded."
with :? InvalidCastException ->
    printfn "Conversion failed."

let pid1 = PersonWithId()
pid1.Name <- "John"
pid1.Id <- "246"
let p1: Person = pid1
try
    let pid1a = p1 :?> PersonWithId
    printfn "Conversion succeeded."
with :? InvalidCastException ->
    printfn "Conversion failed."

// The example displays the following output:
//       Conversion failed.
//       Conversion succeeded.
// </Snippet1>