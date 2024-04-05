module pattern1
// <Snippet12>
open System
open System.Text

type StringBuilderFinder(sb: StringBuilder, textToFind: string) =
    member _.SearchAndAppend(stringToSearch: string) =
        sb.Append stringToSearch |> ignore
        stringToSearch.Contains textToFind

let tempF = [| "47.6F"; "51.3F"; "49.5F"; "62.3F" |]
let tempC = [| "21.2C"; "16.1C"; "23.5C"; "22.9C" |]
let temps = [| tempF; tempC |]

let sb = StringBuilder()
let f = StringBuilderFinder(sb, "F")
let temperatures = temps[Random.Shared.Next(2)]
let mutable baseDate = DateTime(2013, 5, 1)
let mutable isFahrenheit = false

for temperature in temperatures do
    if isFahrenheit then
        sb.AppendFormat("{0:d}: {1}\n", baseDate, temperature) |> ignore
    else
        isFahrenheit <- $"{baseDate:d}: {temperature}\n" |> f.SearchAndAppend

    baseDate <- baseDate.AddDays 1

if isFahrenheit then
    sb.Insert(0, "Average Daily Temperature in Degrees Fahrenheit") |> ignore
    sb.Insert(47, "\n\n") |> ignore

else
    sb.Insert(0, "Average Daily Temperature in Degrees Celsius") |> ignore
    sb.Insert(44, "\n\n") |> ignore

printfn $"{sb}"

// The example displays output similar to the following:
//    Average Daily Temperature in Degrees Celsius
//
//    5/1/2013: 21.2C
//    5/2/2013: 16.1C
//    5/3/2013: 23.5C
//    5/4/2013: 22.9C
// </Snippet12>
