let set1 = Set.ofList [ 1 .. 10]
           |> Set.filter (fun elem -> elem % 2 = 0)
printfn "%A" set1