
let x = 10
let result = lazy (x + 10)
printfn "%d" (result.Force())