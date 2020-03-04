Map.ofList [ (1, "one"); (2, "two") ]
|> Map.add 0 "zero"
|> Map.add 2 "twice"
|> Map.iter (fun key value -> printfn "key: %d value: %s" key value)