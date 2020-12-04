(*
Can be invoked from any directory, like this  
`dotnet fsi ./pathToFile/create-new-fsharp-compiler-message.fsx`

- creates a .md file with title, date, and SEO keywords
- adds the .md file to toc.yml
- creates an .fsx file for code snippets referenced in the .md file
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

let tocText = 
    sprintf 
        "
  - name: %s - %s
    href: ./%s"
        prefixedMessageNumber
        messageTitle
        mdFilename

let tocContents = 
    File.ReadAllText(currentDirectory + "/../toc.yml")
        .TrimEnd() + tocText + "\n"

File.WriteAllText(currentDirectory + "/../toc.yml", tocContents)

/// F# script file to reference in .md file
printfn "Writing %s" fsxFilename

let fsxText = 
    """(* comment *)
let someCode = 5
printfn "%i" someCode
    """

let fsxFolder = 
    currentDirectory + 
    "/../../../../../samples/snippets/fsharp/compiler-messages/"

File.WriteAllText(fsxFolder + fsxFilename, fsxText)
