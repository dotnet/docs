module expand1
// <Snippet9>
open System
open System.Text

// Create a StringBuilder object with no text.
let sb = StringBuilder()
// Append some text.
sb
    .Append('*', 10)
    .Append(" Adding Text to a StringBuilder Object ")
    .Append('*', 10)
|> ignore

sb.AppendLine "\n" |> ignore
sb.AppendLine "Some code points and their corresponding characters:" |> ignore
// Append some formatted text.
for i = 50 to 60 do
    sb.AppendFormat("{0,12:X4} {1,12}", i, Convert.ToChar i) |> ignore
    sb.AppendLine() |> ignore

// Find the end of the introduction to the column.
let pos = (string sb).IndexOf("characters:") + 11 + Environment.NewLine.Length
// Insert a column header.
sb.Insert(pos, String.Format("{2}{0,12:X4} {1,12}{2}", "Code Unit", "Character", "\n"))
|> ignore

// Convert the StringBuilder to a string and display it.
printfn $"{sb}"


// The example displays the following output:
//    ********** Adding Text to a StringBuilder Object **********
//
//    Some code points and their corresponding characters:
//
//       Code Unit    Character
//            0032            2
//            0033            3
//            0034            4
//            0035            5
//            0036            6
//            0037            7
//            0038            8
//            0039            9
//            003A            :
//            003B            ;
//            003C            <
// </Snippet9>
