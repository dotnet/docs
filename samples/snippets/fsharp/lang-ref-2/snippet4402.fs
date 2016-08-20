type Color =
    | Red = 1
    | Green = 2
    | Blue = 3

// The target type of the conversion is determined by type inference.
let col1 = enum 1
// The target type is supplied by a type annotation.
let col2 : Color = enum 2
do
    if (col1 = Color.Red) then
       printfn "Red"