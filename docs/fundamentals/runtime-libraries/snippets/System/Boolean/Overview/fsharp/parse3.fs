module parse3

// <Snippet9>
open System

let values = [ "09"; "12.6"; "0"; "-13 " ]
for value in values do
    match Int32.TryParse value with
    | true, number -> 
        // The method throws no exceptions.
        let result = Convert.ToBoolean number
        printfn $"Converted '{value}' to {result}"
    | false, _ ->
        printfn $"Unable to convert '{value}'"

// The example displays the following output:
//       Converted '09' to True
//       Unable to convert '12.6'
//       Converted '0' to False
//       Converted '-13 ' to True
// </Snippet9> 