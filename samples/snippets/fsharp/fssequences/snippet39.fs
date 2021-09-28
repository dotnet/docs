// This function can be used on any sequence, so the same function
// works with both lists and arrays.
let allPositive coll = Seq.forall (fun elem -> elem > 0) coll
printfn "%A" (allPositive [| 0; 1; 2; 3 |])
printfn "%A" (allPositive [ 1; 2; 3 ])