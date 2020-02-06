
    printf "Array.iter: "
    Array.iter (fun (a,b) -> printf "(%d, %d) " a b) [| for i in 1..5 -> (i, i*i) |]