
// The following code demonstrates the use of reference
// cells to enable partially applied arguments to be changed
// by later code.

let increment1 delta number = number + delta

let mutable myMutableIncrement = 10

// Closures created by partial application and literals.
let incrementBy1 = increment1 1
let incrementBy2 = increment1 2

// Partial application of one argument from a mutable variable.
let incrementMutable = increment1 myMutableIncrement

myMutableIncrement <- 12

// This line prints 110.
printfn "%d" (incrementMutable 100)

let myRefIncrement = ref 10

// Partial application of one argument, dereferenced
// from a reference cell.
let incrementRef = increment1 !myRefIncrement

myRefIncrement := 12

// This line also prints 110.
printfn "%d" (incrementRef 100)

// Reset the value of the reference cell.
myRefIncrement := 10

// New increment function takes a reference cell.
let increment2 delta number = number + !delta

// Partial application of one argument, passing a reference cell
// without dereferencing first.
let incrementRef2 = increment2 myRefIncrement

myRefIncrement := 12

// This line prints 112.
printfn "%d" (incrementRef2 100)