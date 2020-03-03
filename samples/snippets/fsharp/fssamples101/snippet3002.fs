let data = [1;2;3;4]
let r1 = data |> List.map (fun x -> x + 1)
printfn "Adding '1' using map = %A" r1
let r2 = data |> List.map string
printfn "Converting to strings using map = %A" r2
let r3 = data |> List.map (fun x -> (x,x))
printfn "Tupling up using map = %A" r3