module comparison2

// <Snippet10>
let value1 =
    10.201438f ** 2f
    |> sqrt

let value2 =
   ((value1 * 3.51f) ** 2f |> sqrt) / 3.51f

printfn $"{value1} = {value2}: {value1.Equals value2}\n"

        // The example displays the following output on .NET:
        //       10.201438 = 10.201439: False
        // The example displays the following output on .NET Framework:
        //       10.20144 = 10.20144: False
// </Snippet10>
