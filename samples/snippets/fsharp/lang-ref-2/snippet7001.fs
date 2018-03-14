// Program.fs
open Module1

// Create the computation expression object.
let trace1 = trace {
   // A normal let expression (does not call Bind).
   let x = 1
   // A let expression that uses the Bind method.
   let! y = 2
   let sum = x + y
   // return executes the Return method.
   return sum
   }

// Execute the code. Start with the Delay method.
let result = trace1()