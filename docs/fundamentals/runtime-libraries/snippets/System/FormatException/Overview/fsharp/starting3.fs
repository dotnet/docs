module starting3

// <Snippet33>
open System
open System.Text
 
let years = [| 2013; 2014; 2015 |]
let population = [| 1025632; 1105967; 1148203 |]
let sb = StringBuilder()
sb.Append(String.Format("{0,6} {1,15}\n\n", "Year", "Population")) |> ignore
for i = 0 to years.Length - 1 do
   sb.Append(String.Format("{0,6} {1,15:N0}\n", years[i], population[i])) |> ignore

printfn $"{sb}"

// Result:
//      Year      Population
//
//      2013       1,025,632
//      2014       1,105,967
//      2015       1,148,203
// </Snippet33>