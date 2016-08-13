

    let cacheMap = new System.Collections.Generic.Dictionary<_, _>()
    cacheMap.Add(0, 1I)
    cacheMap.Add(1, 1I)

    let lazyFactorial n =
        let rec factorial n =
            if cacheMap.ContainsKey(n) then cacheMap.[n] else
            let result = new System.Numerics.BigInteger(n) * factorial (n - 1)
            cacheMap.Add(n, result)
            result
        if cacheMap.ContainsKey(n) then
            printfn "Reading factorial for %d from cache." n
            Lazy.CreateFromValue(cacheMap.[n])
        else
            printfn "Creating lazy factorial for %d." n
            Lazy.Create (fun () ->
                printfn "Evaluating lazy factorial for %d." n
                let result = factorial n
                result)

    printfn "%A" ((lazyFactorial 12).Force())
    printfn "%A" ((lazyFactorial 10).Force())
    printfn "%A" ((lazyFactorial 11).Force())
    printfn "%A" ((lazyFactorial 30).Force())