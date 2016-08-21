let computation duration =
        printfn "Sleep duration set: %d ms" duration
        let result = Async.Sleep(duration)
        printfn "Created async work item"
        result

let invokeAndPoll computation =
    printfn "Create begin/end functions"
    let (beginInvoke, endInvoke, cancelInvoke) = Async.AsBeginEnd(computation)
    printfn "BeginInvoke"
    let result = beginInvoke(1000, null, null)
    printf "Waiting"
    while (not result.IsCompleted) do
        System.Threading.Thread.Sleep(100)
        printf "."
    printfn ""
    printfn "The operation completed"
    endInvoke(result)
    ()

invokeAndPoll computation