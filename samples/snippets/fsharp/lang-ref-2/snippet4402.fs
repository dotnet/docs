type Color =
    | Red = 1
    | Green = 2
    | Blue = 3

// The target type of the conversion cannot be determined by type inference, so the type parameter must be explicit.
let col1 = enum<Color> 1

// The target type is supplied by a type annotation.
let col2 : Color = enum 2
