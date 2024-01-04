module default1

//<Snippet3>
open System.Text

let showSBInfo (sb: StringBuilder) =
    for prop in sb.GetType().GetProperties() do
        if prop.GetIndexParameters().Length = 0 then
            printf $"{prop.Name}: {prop.GetValue sb:N0}    "

    printfn ""

let sb = StringBuilder()
showSBInfo sb
sb.Append "This is a sentence." |> ignore
showSBInfo sb

for i = 0 to 10 do
    sb.Append "This is an additional sentence." |> ignore
    showSBInfo sb

// The example displays the following output:
//    Capacity: 16    MaxCapacity: 2,147,483,647    Length: 0
//    Capacity: 32    MaxCapacity: 2,147,483,647    Length: 19
//    Capacity: 64    MaxCapacity: 2,147,483,647    Length: 50
//    Capacity: 128    MaxCapacity: 2,147,483,647    Length: 81
//    Capacity: 128    MaxCapacity: 2,147,483,647    Length: 112
//    Capacity: 256    MaxCapacity: 2,147,483,647    Length: 143
//    Capacity: 256    MaxCapacity: 2,147,483,647    Length: 174
//    Capacity: 256    MaxCapacity: 2,147,483,647    Length: 205
//    Capacity: 256    MaxCapacity: 2,147,483,647    Length: 236
//    Capacity: 512    MaxCapacity: 2,147,483,647    Length: 267
//    Capacity: 512    MaxCapacity: 2,147,483,647    Length: 298
//    Capacity: 512    MaxCapacity: 2,147,483,647    Length: 329
//    Capacity: 512    MaxCapacity: 2,147,483,647    Length: 360
// </Snippet3>
