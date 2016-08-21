open System
open System.Threading

let mutable cancelFlag = false

let callback operation (successContinuation : unit -> unit,
                        exceptionContinuation : exn -> unit,
                        cancelContinuation : OperationCanceledException -> unit) =
    printfn "Operation running."
    try
        Async.Start(async {
            operation()
        })
        if (cancelFlag) then
            cancelContinuation(new OperationCanceledException())
        else
            successContinuation()
    with
    | exn -> exceptionContinuation(exn)


let operation =
    async {
        printfn "Operation started."
        do! Async.FromContinuations(callback (fun () -> printfn "Operation executing."
                                                        Thread.Sleep(10000)))
    }

Async.StartWithContinuations(operation,
                             (fun _ -> printfn "Success!"),
                             (fun exn -> printfn "Exception: %s" (exn.Message)),
                             (fun _ -> printfn "Operation cancelled."))

Console.WriteLine("Press enter to cancel.")
Console.ReadLine() |> ignore
cancelFlag <- true
printfn "Done."


Console.WriteLine("Press enter to exit.")
Console.ReadLine() |> ignore