let names = [| "A"; "man"; "landed"; "on"; "the"; "moon" |]
let sentence = names |> Seq.reduce (fun acc item -> acc + " " + item)
printfn "sentence = %s" sentence