open System
open System.IO

let inline replace (piece: string) (replacement: string) (str: string) = str.Replace(piece, replacement)

let getSectionText (section: string) (fileName: string) =
    let lines = File.ReadLines(fileName)
    let titleLine = lines |> Seq.find (fun line -> line.StartsWith(section))
    let len = section.Length
    titleLine.[len..].Trim()

let titleSectionInYaml = "title:"

let stuffForYaml =
    Directory.GetCurrentDirectory()
    |> Directory.GetFiles
    |> Seq.filter (fun name -> name.EndsWith(".md"))
    |> Seq.map (fun name ->
        let unqualifiedName = Path.GetFileName(name)
        (getSectionText titleSectionInYaml unqualifiedName), unqualifiedName)

let tocFile = "toc.yaml"

for (title, file) in stuffForYaml do
    File.AppendAllText(tocFile, sprintf "\n- name: %s\n  href: %s" title file)