
    let lazyValue n = Lazy.Create (fun () ->
        let rec factorial n =
            match n with
            | 0 | 1 -> 1
            | n -> n * factorial (n - 1)
        factorial n)
    let lazyVal = lazyValue 10
    printfn "%d" (lazyVal.Force())