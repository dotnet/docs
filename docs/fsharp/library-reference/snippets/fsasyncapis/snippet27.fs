
    open System

    let async1 = async {
        do! Async.SwitchToNewThread()
        for i in 1 .. 10 do
           printfn "%d" i
           do! Async.Sleep(1000)
        }

    Async.StartImmediate(async1)
    printfn "Got to here"

    Console.WriteLine("Press a key")
    Console.ReadLine() |> ignore