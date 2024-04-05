module comparison2

// <Snippet10>
open System

let value1 = 
    Math.Pow(100.10142, 2)
    |> sqrt

let value2 = 
    let v = pown (value1 * 3.51) 2
    (Math.Sqrt v) / 3.51

printfn $"{value1} = {value2}: {value1.Equals value2}\n"
printfn $"{value1:R} = {value2:R}"
// The example displays the following output:
//    100.10142 = 100.10142: False
//
//    100.10142 = 100.10141999999999
// </Snippet10>