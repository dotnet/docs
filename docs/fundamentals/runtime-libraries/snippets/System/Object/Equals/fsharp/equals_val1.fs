module equals_val1

// <Snippet3>
let value1 = 12uy
let value2 = 12

let object1 = value1 :> obj
let object2 = value2 :> obj

printfn $"{object1} ({object1.GetType().Name}) = {object2} ({object2.GetType().Name}): {object1.Equals object2}"

// The example displays the following output:
//        12 (Byte) = 12 (Int32): False
// </Snippet3>