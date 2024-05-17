module precisionlist5

// <Snippet8>
open System
open System.IO

let values = [ 2.2 / 1.01; 1. / 3.; Math.PI ]

using (new StreamWriter(@".\Doubles.dat")) (fun sw -> 
    for i = 0 to values.Length - 1 do
        sw.Write $"""{values[i]:G17}{if i < values.Length - 1 then "|" else ""}""")

using (new StreamReader(@".\Doubles.dat")) (fun sr ->
    let temp = sr.ReadToEnd()
    let tempStrings = temp.Split '|'
    
    let restoredValues = 
      [ for i = 0 to tempStrings.Length - 1 do
            Double.Parse tempStrings[i] ]

    for i = 0 to values.Length - 1 do
        printfn $"""{restoredValues[i]} {if values[i].Equals restoredValues[i] then "=" else "<>"} {values[i]}""")

// The example displays the following output:
//       2.17821782178218 = 2.17821782178218
//       0.333333333333333 = 0.333333333333333
//       3.14159265358979 = 3.14159265358979
// </Snippet8>