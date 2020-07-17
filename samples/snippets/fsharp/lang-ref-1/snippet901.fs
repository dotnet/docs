let function1 x y = x + y
// The next line results in a compiler warning.
function1 10 20
// Changing the code to one of the following eliminates the warning.
// Use this when you do want the return value.
let result = function1 10 20
// Use this if you are only calling the function for its side effects,
// and do not want the return value.
function1 10 20 |> ignore