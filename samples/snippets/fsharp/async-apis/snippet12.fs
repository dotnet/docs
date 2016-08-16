
    let computation duration =
            printfn "Sleep duration set: %d ms" duration
            let result = Async.Sleep(duration)
            printfn "Created async work item"
            result

    let invokeAndContinue computation =
        printfn "Create begin/end functions"
        let (beginInvoke, endInvoke, cancelInvoke) = Async.AsBeginEnd(computation)
        let callBack (result: System.IAsyncResult) =
            printfn "callBack executing"
            if (result.IsCompleted) then endInvoke(result)
            printfn "callBack executed"
        printfn "BeginInvoke"
        let result = beginInvoke(10000, new System.AsyncCallback(callBack), new System.Object())
        printfn "Waiting..."
        ()

    invokeAndContinue computation
    printfn "Press any key to stop waiting."
    System.Console.ReadLine() |> ignore