let map1 = [ for i in 1 .. 100 -> (i, 100 - i) ] |> Map.ofList
let result = Map.tryPick (fun key value -> if key = value then Some(key) else None) map1
match result with
| Some x -> printfn "Result where key and value are the same: %d" x
| None -> printfn "No result satisifies the condition."