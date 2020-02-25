
    let append1 string1 = string1 + ".append1"
    let append2 string1 = string1 + ".append2"

    let result1 = "abc" |> append1
    printfn "\"abc\" |> append1 gives %A" result1

    let result2 = "abc" 
                  |> append1
                  |> append2
    printfn "result2: %A" result2

    [1; 2; 3]
    |> List.map (fun elem -> elem * 100)
    |> List.rev
    |> List.iter (fun elem -> printf "%d " elem)
    printfn ""