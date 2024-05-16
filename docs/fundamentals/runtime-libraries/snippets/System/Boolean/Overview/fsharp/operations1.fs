module operations1

// <Snippet10>
open System
open System.IO
open System.Threading

let showSyntax errMsg =
    printfn $"{errMsg}\n\nSyntax: Example [[/f <filename> [/b]]\n" 

let mutable isRedirected = false
let mutable isBoth = false
let mutable fileName = ""

let rec parse = function
    | [] -> ()
    | "-b" :: rest
    | "/b" :: rest ->
        isBoth <- true
        // Parse remaining arguments.
        parse rest
    | "-f" :: file :: rest
    | "/f" :: file :: rest ->
        isRedirected <- true
        fileName <- file
        // Parse remaining arguments.
        parse rest
    | "-f" :: []
    | "/f" :: [] ->
        isRedirected <- true
        // No more arguments to parse.
    | x -> showSyntax $"The {x} switch is not supported"

Environment.GetCommandLineArgs()[1..]
|> List.ofArray
|> parse

// If isBoth is True, isRedirected must be True.
if isBoth && not isRedirected then
    showSyntax "The /f switch must be used if /b is used."
// If isRedirected is True, a fileName must be specified.
elif fileName = "" && isRedirected then
    showSyntax "The /f switch must be followed by a filename."    
else
    use mutable sw = null

    // Handle output.
    let writeLine =
        if isRedirected then 
            sw <- new StreamWriter(fileName)
            if isBoth then
                fun text -> 
                    printfn "%s" text
                    sw.WriteLine text
            else sw.WriteLine
        else printfn "%s"

    writeLine $"Application began at {DateTime.Now}"
    Thread.Sleep 5000
    writeLine $"Application ended normally at {DateTime.Now}"

// </Snippet10>
module Evaluation =
    let someFunction () =
        let booleanValue = false

        // <Snippet11>
        if booleanValue = true then
        // </Snippet11>
            ()

        // <Snippet12>
        if booleanValue then
        // </Snippet12>
            ()