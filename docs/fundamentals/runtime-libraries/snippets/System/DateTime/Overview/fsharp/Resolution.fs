module Resolution

open System

let demonstrateResolution () =
    // <Snippet1>
    let mutable output = ""
    for i = 0 to 20 do
        output <- output + $"{DateTime.Now.Millisecond}\n"
        // Introduce a delay loop.
        for _ = 0 to 1000 do ()

        if i = 10 then
            output <- output + "Thread.Sleep called...\n"
            System.Threading.Thread.Sleep 5

    printfn $"{output}"
    // Press "Run" to see the output.
    // </Snippet1>