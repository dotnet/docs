open System
open System.IO

let badPattern = "-[fsharp]"

let renameFile (filename: string) =
    filename.Replace(badPattern, String.Empty)

let files =
    Directory.GetCurrentDirectory()
    |> Directory.GetFiles
    |> Seq.filter (fun name -> name.EndsWith(badPattern + ".md"))

printfn "%d" (files |> Seq.length)

for file in files do
    let renamed = renameFile file
    File.Delete(renamed)
    File.Move(file, renamed)
    File.Delete(file)