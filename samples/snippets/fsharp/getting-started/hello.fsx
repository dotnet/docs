printfn "Hello from F# Interactive!"

let square x = x * x

[ 1 .. 10 ]
|> List.map square
|> printfn "Squares: %A"
