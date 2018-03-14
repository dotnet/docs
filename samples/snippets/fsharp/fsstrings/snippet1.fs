let spaceOut inputString =
     String.collect (fun c -> sprintf "%c " c) inputString
printfn "%s" (spaceOut "Hello World!")