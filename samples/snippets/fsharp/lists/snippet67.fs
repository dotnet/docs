[ 1 .. 10 ]
|> List.sumBy (fun x -> x * x)
|> printfn "Sum: %d"