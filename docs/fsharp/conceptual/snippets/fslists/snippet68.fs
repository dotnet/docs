[ 1 .. 10 ]
|> List.toSeq
|> Seq.truncate 5
|> Seq.iter (fun elem -> printf "%d " elem)
printfn ""