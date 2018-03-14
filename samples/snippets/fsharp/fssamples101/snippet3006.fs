let data = [("Cats",4);
            ("Dogs",5);
            ("Mice",3);
            ("Elephants",2)]
let count = List.fold (fun acc (nm,x) -> acc+x) 0 data
printfn "Total number of animals: %d" count