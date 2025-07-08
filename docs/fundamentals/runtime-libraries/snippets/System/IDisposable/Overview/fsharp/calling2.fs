module calling2

// <Snippet2>
open System.IO
open System.Text.RegularExpressions

type WordCount2(filename) =
    let txt = 
        if File.Exists filename |> not then
            raise (FileNotFoundException "The file does not exist.")

        let sr = new StreamReader(filename)
        try
            sr.ReadToEnd()
        finally
            sr.Dispose()

    let pattern = @"\b\w+\b"
    
    let nWords = Regex.Matches(txt, pattern).Count

    member _.FullName = filename

    member _.Name = Path.GetFileName filename

    member _.Count = nWords
// </Snippet2>