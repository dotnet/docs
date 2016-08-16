
    let bigint1 = bigint.Parse("20029374923749273947298347928374927349872")

    try
       let bigint2 = bigint.Parse("x")
       printfn "%s" (bigint2.ToString())
    with
       | :? System.FormatException as e -> printfn "Error: %s" e.Message