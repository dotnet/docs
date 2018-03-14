let data = [("Cats",4);
            ("Dogs",5);
            ("Mice",3);
            ("Elephants",2)]
let res = data |> List.choose (fun (nm,x) -> if nm.Length <= 4 then Some(x) else None)
printfn "Counts of animals with short names: %A" res