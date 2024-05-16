module instantiate1
// <Snippet6>
open System.Text

let showSBInfo (sb: StringBuilder) =
    for prop in sb.GetType().GetProperties() do
        if prop.GetIndexParameters().Length = 0 then
            printf $"{prop.Name}: {prop.GetValue sb:N0}    "

    printfn ""

let value = "An ordinary string"
let index = value.IndexOf "An " + 3
let capacity = 0xFFFF

// Instantiate a StringBuilder from a string.
let sb1 = StringBuilder value
showSBInfo sb1

// Instantiate a StringBuilder from string and define a capacity.
let sb2 = StringBuilder(value, capacity)
showSBInfo sb2

// Instantiate a StringBuilder from substring and define a capacity.
let sb3 = StringBuilder(value, index, value.Length - index, capacity)
showSBInfo sb3

// The example displays the following output:
//    Value: An ordinary string
//    Capacity: 18    MaxCapacity: 2,147,483,647    Length: 18
//
//    Value: An ordinary string
//    Capacity: 65,535    MaxCapacity: 2,147,483,647    Length: 18
//
//    Value: ordinary string
//    Capacity: 65,535    MaxCapacity: 2,147,483,647    Length: 15
// </Snippet6>
