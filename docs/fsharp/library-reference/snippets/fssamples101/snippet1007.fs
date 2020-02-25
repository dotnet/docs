
    let names = [|"Bob"; "Ann"; "Stephen"; "Vivek"; "Fred"; "Kim"; "Brian"; "Ling"; "Jane"; "Jonathan"|]
    let longNames = names |> Array.filter (fun x -> x.Length > 4)
    
    printfn "names = %A\n" names
    printfn "longNames = %A" longNames