(*
Change the `messageNumber` and `messageTitle` and invoke from any directory, like this  
`dotnet fsi ./pathToFile/create-new-fsharp-compiler-message.fsx`

- creates a .md file with title, date, and SEO keywords
- adds the .md file to toc.yml in the right order
- creates an .fsx file for code snippets referenced in the .md file

You can find error numbers here:
- https://github.com/dotnet/fsharp/blob/main/src/fsharp/CompilerDiagnostics.fs#L218-L350
- https://github.com/dotnet/fsharp/blob/main/src/fsharp/FSComp.txt#L34
*)
let messageNumber= "0026"
let messageTitle= "Message title"

open System
open System.IO

let prefixedMessageNumber = "FS" + messageNumber
let currentDirectory = __SOURCE_DIRECTORY__
let date = DateTime.Now.ToString "MM/dd/yyyy"
let mdFilename = "fs" + messageNumber + ".md"
let fsxFilename= "fs" + messageNumber + ".fsx"

/// MD file
printfn "Writing %s" mdFilename

let mdContents = 
    sprintf
        "\
---
title: \"Compiler error %s\"
ms.date: %s
f1_keywords:
  - \"%s\"
helpviewer_keywords:
  - \"%s\"
---

# %s: %s

[!code-fsharp[%s-comment](~/samples/snippets/fsharp/compiler-messages/%s#L2-L3)]
        "
        prefixedMessageNumber
        date
        prefixedMessageNumber
        prefixedMessageNumber

        prefixedMessageNumber
        messageTitle

        prefixedMessageNumber
        fsxFilename

File.WriteAllText(currentDirectory + "/../" + mdFilename, mdContents, Text.Encoding.UTF8)

/// Table of Contents entry
printfn "Appending entry to toc.yml"

let tocContents = 
    File.ReadAllLines(currentDirectory + "/../toc.yml")

let header = Array.take 3 tocContents

let tocText =
    let name = sprintf "  - name: %s - %s" prefixedMessageNumber messageTitle
    let href = sprintf "    href: ./%s" mdFilename
    [| name; href |]

let body =
    tocContents
    |> Array.skip 3
    |> Array.chunkBySize 2
    |> Array.append [| tocText |]
    |> Array.sort

let sb = Text.StringBuilder()

header |> Array.iter (sb.AppendLine >> ignore)

body
|> Array.iter (fun a -> 
    sb.AppendLine a.[0] |> ignore
    sb.AppendLine a.[1] |> ignore)

File.WriteAllText(currentDirectory + "/../toc.yml", sb.ToString())

/// F# script file to reference in .md file
printfn "Writing %s" fsxFilename

let fsxText = 
    """// comment
let someCode = 5
printfn "%i" someCode
    """

let fsxFolder = 
    currentDirectory + 
    "/../../../../../samples/snippets/fsharp/compiler-messages/"

File.WriteAllText(fsxFolder + fsxFilename, fsxText)
