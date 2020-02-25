
    // Use Seq.exists to determine whether there is an element of a sequence
    // that satisfies a given Boolean expression.
    // containsNumber returns true if any of the elements of the supplied sequence match 
    // the supplied number.
    let containsNumber number seq1 = Seq.exists (fun elem -> elem = number) seq1
    let seq0to3 = seq {0 .. 3}
    printfn "For sequence %A, contains zero is %b" seq0to3 (containsNumber 0 seq0to3)