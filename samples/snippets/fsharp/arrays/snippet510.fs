let data = [| 1; 2; 3; 4 |]
let r1 = data |> Array.map (fun x -> x + 1)
printfn "Adding '1' using map = %A" r1
let r2 = data |> Array.map string
printfn "Converting to strings by using map = %A" r2
let r3 = data |> Array.map (fun x -> (x, x))
printfn "Converting to tuples by using map = %A" r3
