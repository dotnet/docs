module precisionlist4a

// <Snippet17>
open System
open System.IO

let values = [| 3.2f / 1.11f; 1f / 3f; MathF.PI |]

do
    use sw = new StreamWriter(@".\Singles.dat")
    for i = 0 to values.Length - 1 do
        sw.Write(string values[i])
        if i <> values.Length - 1 then
            sw.Write "|"

let restoredValues =
    use sr = new StreamReader(@".\Singles.dat")
    sr.ReadToEnd().Split '|'
    |> Array.map Single.Parse

for i = 0 to values.Length - 1 do
    printfn $"""{values[i]} {if values[i].Equals restoredValues[i] then "=" else "<>"} {restoredValues[i]}"""
                    
// The example displays the following output:
//       2.882883 <> 2.882883
//       0.3333333 <> 0.3333333
//       3.141593 <> 3.141593
// </Snippet17>