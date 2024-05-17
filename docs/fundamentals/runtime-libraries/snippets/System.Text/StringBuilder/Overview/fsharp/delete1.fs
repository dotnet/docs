module delete1
// <Snippet10>
open System.Text

let showSBInfo (sb: StringBuilder) =
    for prop in sb.GetType().GetProperties() do
        if prop.GetIndexParameters().Length = 0 then
            printf $"{prop.Name}: {prop.GetValue sb:N0}    "

    printfn ""

let sb = StringBuilder "A StringBuilder object"
showSBInfo sb
// Remove "object" from the text.
let textToRemove = "object"
let pos = (string sb).IndexOf textToRemove

if pos >= 0 then
    sb.Remove(pos, textToRemove.Length) |> ignore
    showSBInfo sb

// Clear the StringBuilder contents.
sb.Clear() |> ignore
showSBInfo sb

// The example displays the following output:
//    Value: A StringBuilder object
//    Capacity: 22    MaxCapacity: 2,147,483,647    Length: 22
//
//    Value: A StringBuilder
//    Capacity: 22    MaxCapacity: 2,147,483,647    Length: 16
//
//    Value:
//    Capacity: 22    MaxCapacity: 2,147,483,647    Length: 0
// </Snippet10>
