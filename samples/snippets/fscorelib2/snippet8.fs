
    let rec factorial n = match n with 0 | 1 -> 1 | n -> n * (factorial (n-1))
    let lazyValue = lazy ( factorial (10) )
    // No computation occurs until the match expression executes.
    match lazyValue with
    | Lazy value -> printfn "10 factorial is %d" value