module parse2

// <Snippet2>
open System

let values = 
    [ null; String.Empty; "True"; "False"
      "true"; "false"; "    true    "
      "TrUe"; "fAlSe"; "fa lse"; "0"
      "1"; "-1"; "string" ]
// Parse strings using the Boolean.Parse method.
for value in values do
    try
        let flag = Boolean.Parse value
        printfn $"'{value}' --> {flag}"
    with 
    | :? ArgumentException ->
        printfn "Cannot parse a null string."
    | :? FormatException ->
        printfn $"Cannot parse '{value}'."
printfn ""
// Parse strings using the Boolean.TryParse method.
for value in values do
    match Boolean.TryParse value with
    | true, flag -> 
        printfn $"'{value}' --> {flag}"
    | false, _ ->
        printfn $"Unable to parse '{value}'"

// The example displays the following output:
//       Cannot parse a null string.
//       Cannot parse ''.
//       'True' --> True
//       'False' --> False
//       'true' --> True
//       'false' --> False
//       '    true    ' --> True
//       'TrUe' --> True
//       'fAlSe' --> False
//       Cannot parse 'fa lse'.
//       Cannot parse '0'.
//       Cannot parse '1'.
//       Cannot parse '-1'.
//       Cannot parse 'string'.
//
//       Unable to parse ''
//       Unable to parse ''
//       'True' --> True
//       'False' --> False
//       'true' --> True
//       'false' --> False
//       '    true    ' --> True
//       'TrUe' --> True
//       'fAlSe' --> False
//       Cannot parse 'fa lse'.
//       Unable to parse '0'
//       Unable to parse '1'
//       Unable to parse '-1'
//       Unable to parse 'string'
// </Snippet2>