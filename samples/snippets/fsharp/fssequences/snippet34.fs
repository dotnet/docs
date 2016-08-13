
    // Use Seq.exists2 to compare elements in two sequences.
    // isEqualElement returns true if any elements at the same position in two supplied
    // sequences match.
    let isEqualElement seq1 seq2 = Seq.exists2 (fun elem1 elem2 -> elem1 = elem2) seq1 seq2
    let seq1to5 = seq { 1 .. 5 }
    let seq5to1 = seq { 5 .. -1 .. 1 }
    if (isEqualElement seq1to5 seq5to1) then
        printfn "Sequences %A and %A have at least one equal element at the same position." seq1to5 seq5to1
    else
        printfn "Sequences %A and %A do not have any equal elements that are at the same position." seq1to5 seq5to1