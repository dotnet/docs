module replace1
// <Snippet11>
open System.Text

let myStringBuilder = StringBuilder "Hello World!"
myStringBuilder.Replace('!', '?') |> ignore
printfn $"{myStringBuilder}"

// The example displays the following output:
//       Hello World?
// </Snippet11>
