List.init 10 (fun i -> (i, i * i))
|> List.filter (fun (n, nsqr) -> n % 2 = 0)
|> List.rev
|> List.iter (fun (n, nsqr) -> printfn "(%d, %d) " n nsqr)