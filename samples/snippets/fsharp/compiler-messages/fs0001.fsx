(* simple type annotation mismatch example *)
let booleanBinding: bool = 10

(* more complex type-inference across functions example *)
// this function has type `int -> int`.
// `+` takes the type of the arguments passed to it, and `1` is of type `int`, so
// `+` must be of type `int -> int`
let addOne i = i + 1

// this function has type `int -> int`, which may be surprising because no types are explicitly specified.
// the `printfn` call on the first line is of type `'a -> unit`, because `printfn "%A"` takes a value of any type and returns unit.
// this means that the type of the `i` parameter hasn't yet been decided based on how the parameter is used.
// the `addOne` call on the second line is of type `int -> int`, because `addOne` is of type `int -> int` (see above).
// this means that `i` _must_ be of type `int`, so the overall type signature of `printThenAdd` is inferred to be `int -> int`
let printThenAdd i =
    printfn "%A" i
    addOne i

// this line triggers the error
// > This expression was expected to have type
// >   'int'
// > but here has type
// >   'string'
// because `printThenAdd` has been inferred to have type `int -> int`, but a string was passed in as the `int` parameter
printThenAdd "a number"
|> ignore

(* partial application type inference example *)
// Define a function that takes two arguments and returns their sum
let Sum x y = x + y

// This works: RegisterFunction1 accepts a function with generic types 'A -> 'B
// When passed Sum (which is int -> int -> int), type inference maps:
// 'A to int (the first parameter type)
// 'B to int -> int (the remaining function after partial application)
let RegisterFunction1 (fn:'A->'B) = ()
let Test1 = RegisterFunction1 Sum

// This fails: RegisterFunction2 expects a function 'A -> int (returning int, not a function)
// When passed Sum (which is int -> int -> int), type inference maps:
// 'A to int (the first parameter type)
// But then expects the return type to be int, not int -> int (the partially applied function)
let RegisterFunction2 (fn:'A->int) = ()
// Uncommenting the next line would trigger the error:
// > This expression was expected to have type
// >   'int -> int'
// > but here has type
// >   'int -> int -> int'
// let Test2 = RegisterFunction2 Sum
