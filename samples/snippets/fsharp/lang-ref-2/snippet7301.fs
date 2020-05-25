#if VERSION1
let function1 x y =
   printfn "x: %d y: %d" x y
   x + 2 * y
#else
let function1 x y =
   printfn "x: %d y: %d" x y
   x - 2*y
#endif

let result = function1 10 20