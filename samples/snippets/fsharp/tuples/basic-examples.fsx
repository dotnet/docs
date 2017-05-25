//
// Basic examples
//

// Tuple of two integers.
(1, 2)

// Triple of strings.
("one", "two", "three")

// Tuple of generic types.
(a, b)

// Tuple that has mixed types.
("one", 1, 2.0)

// Tuple of integer expressions.
(a + 1, b + 1)

// Struct Tuple of floats
struct (1.025f, 1.5f)

//
// Pattern matching
//

let print tuple1 =
   match tuple1 with
    | (a, b) -> printfn "Pair %A %A" a b
//    
// Pattern matching via binding
//

let (a, b) = (1, 2)

// Or as a struct
let struct (c, d) = struct (1, 2)

//
// Pattern matching via function parameter
//

let getDistance ((x1,y1): float*float) ((x2,y2): float*float) =
    // Note the ability to work on individual elements
    (x1*x2 - y1*y2) 
    |> abs 
    |> sqrt

//
// Wildcard
//

let (a, _) = (1, 2)

// Or as a struct
let struct (c, _) = struct (1, 2)

//
// Copy values to struct tuple
//

// Create a reference tuple
let (a, b) = (1, 2)

// Construct a struct tuple from it
let struct (c, d) = struct (a, b)

//
// Fst and Snd functions
//

let c = fst (1, 2)
let d = snd (1, 2)

//
// Self-defined third function
//
let third (_, _, c) = c

//
// Using Tuples section
//
let divRem a b =
   let x = a / b
   let y = a % b
   (x, y)

let sumNoCurry (a, b) = a + b

let sum a b = a + b

let addTen = sum 10
let result = addTen 95
// Result is 105.