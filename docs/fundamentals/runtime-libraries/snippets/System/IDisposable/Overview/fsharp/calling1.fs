module calling1

// <Snippet1>
open System.IO
open System.Text.RegularExpressions

type WordCount(filename) =
    let txt = 
        if File.Exists filename |> not then
            raise (FileNotFoundException "The file does not exist.")

        use sr = new StreamReader(filename)
        sr.ReadToEnd()

    let pattern = @"\b\w+\b"
    
    let nWords = Regex.Matches(txt, pattern).Count

    member _.FullName = filename

    member _.Name = Path.GetFileName filename

    member _.Count = nWords
// </Snippet1>