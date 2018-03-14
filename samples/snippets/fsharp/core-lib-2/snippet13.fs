let lazyFactorial n = Lazy.Create (fun () ->
    let rec factorial n =
        match n with
        | 0 | 1 -> 1
        | n -> n * factorial (n - 1)
    factorial n)
let printLazy (lazyVal:Lazy<int>) =
    if (lazyVal.IsValueCreated) then
        printfn "Retrieving stored value: %d" (lazyVal.Value)
    else
        printfn "Computing value: %d" (lazyVal.Force())
let lazyVal1 = lazyFactorial 12
let lazyVal2 = lazyFactorial 10
lazyVal1.Force() |> ignore
printLazy lazyVal1
printLazy lazyVal2