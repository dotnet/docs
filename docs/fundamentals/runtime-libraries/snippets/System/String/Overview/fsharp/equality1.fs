module equality1.fs
// <Snippet11>
open System
open System.Globalization
open System.Threading

let testForEquality (str: string) (cmp: StringComparison) =
    let position = str.IndexOf "://"
    if position < 0 then false
    else
        let substring = str.Substring(0, position)
        substring.Equals("FILE", cmp)

Thread.CurrentThread.CurrentCulture <- CultureInfo.CreateSpecificCulture "tr-TR"

let filePath = "file://c:/notes.txt"

printfn "Culture-sensitive test for equality:"
if not (testForEquality filePath StringComparison.CurrentCultureIgnoreCase) then
    printfn $"Access to {filePath} is allowed."
else
    printfn $"Access to {filePath} is not allowed."

printfn "\nOrdinal test for equality:"
if not (testForEquality filePath StringComparison.OrdinalIgnoreCase) then
    printfn $"Access to {filePath} is allowed."
else
    printfn $"Access to {filePath} is not allowed."

// The example displays the following output:
//       Culture-sensitive test for equality:
//       Access to file://c:/notes.txt is allowed.
//
//       Ordinal test for equality:
//       Access to file://c:/notes.txt is not allowed.
// </Snippet11>
