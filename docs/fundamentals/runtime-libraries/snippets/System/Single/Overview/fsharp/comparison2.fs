module comparison2

// <Snippet10>
let value1 = 
    10.201438f ** 2f
    |> sqrt

let value2 =
   ((value1 * 3.51f) ** 2f |> sqrt) / 3.51f

printfn $"{value1} = {value2}: {value1.Equals value2}\n" 
printfn $"{value1:G9} = {value2:G9}"
// The example displays the following output:
//       10.20144 = 10.20144: False
//       
//       10.201438 = 10.2014389
// </Snippet10>