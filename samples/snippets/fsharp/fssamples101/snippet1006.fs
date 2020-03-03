let names = [| "A"; "man"; "landed"; "on"; "the"; "moon" |]
let sentence = names |> Array.reduce (fun acc item -> acc + " " + item)
printfn "sentence = %s" sentence