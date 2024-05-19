module parse1.fs
// <Snippet9>
open System
open System.Globalization

let dateString = "07/10/2011"
let cultures = 
    [| CultureInfo.InvariantCulture
       CultureInfo.CreateSpecificCulture "en-GB"
       CultureInfo.CreateSpecificCulture "en-US" |]
printfn $"""{"Date String",-12} {"Culture",10} {"Month",8} {"Day",8}\n"""
for culture in cultures do
    let date = DateTime.Parse(dateString, culture)
    printfn $"""{dateString,-12} {(if String.IsNullOrEmpty culture.Name then "Invariant" else culture.Name),10} {date.Month,8} {date.Day,8}"""
// The example displays the following output:
//       Date String     Culture    Month      Day
//
//       07/10/2011    Invariant        7       10
//       07/10/2011        en-GB       10        7
//       07/10/2011        en-US        7       10
// </Snippet9>
