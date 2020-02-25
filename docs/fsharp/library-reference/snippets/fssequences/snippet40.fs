
    // This function can be used on any sequence, so the same function
    // works with both lists and arrays.
    let allEqual coll = Seq.forall2 (fun elem1 elem2 -> elem1 = elem2) coll
    printfn "%A" (allEqual [| 1; 2 |] [| 1; 2 |])
    printfn "%A" (allEqual [ 1; 2 ] [ 2; 1 ])