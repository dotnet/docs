module call2
// <Snippet5>
open System.Text

let sb = StringBuilder "This is the beginning of a sentence, "

sb
    .Replace("the beginning of ", "")
    .Insert((string sb).IndexOf "a " + 2, "complete ")
    .Replace(",", ".")
|> ignore

printfn $"{sb}"
// The example displays the following output:
//        This is a complete sentence.
// </Snippet5>
