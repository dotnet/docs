
    let computation duration =
            printfn "Sleep duration set: %d ms" duration
            let result = Async.Sleep(duration)
            printfn "Created async work item"
            result

    let invokeAndWait computation duration (timeout:int) =
        printfn "Create begin/end functions"
        let (beginInvoke, endInvoke, cancelInvoke) = Async.AsBeginEnd(computation)
        printfn "BeginInvoke"
        let result = beginInvoke(duration, null, null)
        printfn "Waiting"
        match result.AsyncWaitHandle.WaitOne(timeout) with
        | true -> printfn "The operation completed."
        | false -> printfn "The operation failed to complete."
        endInvoke(result)
        ()

    // Duration of the async workflow, and timeout: in ms
    invokeAndWait computation 1000 5000
    invokeAndWait computation 10000 5000