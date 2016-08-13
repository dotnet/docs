
    type status = {
        mutable percentDone : int
        mutable isDone : bool
        }

    let computation (statusObj: status) duration =
            // Round off the duration to a multiple of 100.
            let duration = (duration / 100) * 100
            printfn "Sleep duration set: %d ms" duration
            let result = async {
                for i in 1 .. 100 do
                    do! Async.Sleep(duration / 100)
                    statusObj.percentDone <- i
                statusObj.isDone <- true
                }
            printfn "Created async work item"
            result

    let invokeAndMonitor computation =
        printfn "Create begin/end functions"
        let statusObj = { percentDone = 0; isDone = false }
        let (beginInvoke, endInvoke, cancelInvoke) = Async.AsBeginEnd(computation statusObj)
        printfn "BeginInvoke"
        let result = beginInvoke(10000, null, statusObj)
        printfn "Waiting..."
        let mutable isDone = false
        while (not isDone) do
            System.Threading.Thread.Sleep(1000)
            let statusObj = result.AsyncState :?> status
            isDone <- statusObj.isDone
            printf "%d%% " statusObj.percentDone
        printfn ""
        printfn "The operation completed"
        endInvoke(result)
        ()

    invokeAndMonitor computation