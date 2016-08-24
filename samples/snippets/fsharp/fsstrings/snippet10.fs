let replaceNth n newChar inputString =
    let result = String.mapi (fun i c -> if i = n then newChar else c) inputString
    printfn "%s" result
    result
printfn "MASK"
"MASK" |> replaceNth 0 'B'
|> replaceNth 3 'H'
|> replaceNth 2 'T'
|> replaceNth 1 'O'
|> replaceNth 0 'M'
|> replaceNth 1 'A'
|> replaceNth 2 'S'
|> replaceNth 3 'K'