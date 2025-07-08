module EnumMain

//<snippet1>
open System

type Days =
    | Saturday = 0
    | Sunday = 1
    | Monday = 2
    | Tuesday = 3
    | Wednesday = 4
    | Thursday = 5
    | Friday = 6

type BoilingPoints =
    | Celsius = 100
    | Fahrenheit = 212

[<Flags>]
type Colors =
    | Red = 1
    | Green = 2
    | Blue = 4
    | Yellow = 8

let weekdays = typeof<Days>
let boiling = typeof<BoilingPoints>

printfn "The days of the week, and their corresponding values in the Days Enum are:"

for s in Enum.GetNames weekdays do
    printfn $"""{s,-11}= {Enum.Format(weekdays, Enum.Parse(weekdays, s), "d")}"""

printfn "\nEnums can also be created which have values that represent some meaningful amount."
printfn "The BoilingPoints Enum defines the following items, and corresponding values:"

for s in Enum.GetNames boiling do
    printfn $"""{s,-11}= {Enum.Format(boiling, Enum.Parse(boiling, s), "d")}"""

let myColors = Colors.Red ||| Colors.Blue ||| Colors.Yellow
printfn $"\nmyColors holds a combination of colors. Namely: {myColors}"
//</snippet1>