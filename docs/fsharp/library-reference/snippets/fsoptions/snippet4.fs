
    let consOption list opt =
        Option.fold (fun state value -> value :: state) list opt
    printfn "%A" <| consOption [1 .. 10] None
    printfn "%A" <| consOption [1 .. 10] (Some(0))

    // Read input from the console, and if the input parses as
    // an integer, cons to the list.
    let readNumber () =
        let line = System.Console.ReadLine()
        let (success, value) = System.Int32.TryParse(line)
        if success then Some(value) else None
    let mutable list1 = []
    let mutable count = 0
    while count < 5 do
        printfn "Enter a number: "
        list1 <- consOption list1 (readNumber())
        printfn "New list: %A" <| list1
        count <- count + 1