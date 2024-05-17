let printSequence (sequence1: Collections.seq<_>) =
    Seq.iter (fun elem -> printf "%s " (elem.ToString())) sequence1
