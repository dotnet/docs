module qa_interpolated2

// <SnippetQAInterpolated2>
open System

let names = [| "Balto"; "Vanya"; "Dakota"; "Samuel"; "Koani"; "Yiska"; "Yuma" |]
let output = $"{names[0]}, {names[1]}, {names[2]}, {names[3]}, {names[4]}, {names[5]}, {names[6]}"  

let date = DateTime.Now
output + $"\nIt is {date:t} on {date:d}. The day of the week is {date.DayOfWeek}."
|> printfn "%s" 
// The example displays the following output:
//     Balto, Vanya, Dakota, Samuel, Koani, Yiska, Yuma
//     It is 10:29 AM on 1/8/2018. The day of the week is Monday.
// </SnippetQAInterpolated2>