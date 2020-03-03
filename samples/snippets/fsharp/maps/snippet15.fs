let map1 = [ for i in 1 .. 100 -> (i, i*i) ] |> Map.ofList
let result = Map.tryFind 50 map1
match result with
| Some x -> printfn "Found %d." x
| None -> printfn "Did not find the specified value."