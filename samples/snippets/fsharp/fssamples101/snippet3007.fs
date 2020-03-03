let data = [("Cats",4);
            ("Dogs",5);
            ("Mice",3);
            ("Elephants",2)]
let res = data |> List.filter (fun (nm,x) -> nm.Length <= 4)
printfn "Animals with short names: %A" res