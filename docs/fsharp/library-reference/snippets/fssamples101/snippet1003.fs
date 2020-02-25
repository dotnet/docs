
    printf "Seq.iter: "
    Seq.iter (fun (a,b) -> printf "(%d, %d) " a b) (seq { for i in 1..5 -> (i, i*i) })