module RuntimeAsyncProgram

[<EntryPoint>]
let main args =
    match args with
    | [| path |] ->
        let length = (RuntimeAsyncExample.readManifest path).GetAwaiter().GetResult()
        printfn "%d" length
        0
    | _ ->
        eprintfn "Usage: dotnet run -- <file>"
        1
