module call1
// <Snippet4>
open System.Text

let sb = StringBuilder()
sb.Append "This is the beginning of a sentence, " |> ignore
sb.Replace("the beginning of ", "") |> ignore
sb.Insert((string sb).IndexOf "a " + 2, "complete ") |> ignore
sb.Replace(",", ".") |> ignore
printfn $"{sb}"
// The example displays the following output:
//        This is a complete sentence.
// </Snippet4>
