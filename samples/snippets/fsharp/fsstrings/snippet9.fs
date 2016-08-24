let enumerateCharacters inputString =
    String.iteri (fun i c -> printfn "%d %c" i c) inputString
enumerateCharacters "TIME"
enumerateCharacters "SPACE"