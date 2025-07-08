module Instance1
// <Snippet4>
open System.Threading

let obj = obj ()

let showThreadInformation (state: obj) =
    lock obj (fun () ->
        let th = Thread.CurrentThread
        printfn $"Managed thread #{th.ManagedThreadId}: "
        printfn $"   Background thread: {th.IsBackground}"
        printfn $"   Thread pool thread: {th.IsThreadPoolThread}"
        printfn $"   Priority: {th.Priority}"
        printfn $"   Culture: {th.CurrentCulture.Name}"
        printfn $"   UI culture: {th.CurrentUICulture.Name}"
        printfn "")

ThreadPool.QueueUserWorkItem showThreadInformation |> ignore
let th1 = Thread(ParameterizedThreadStart showThreadInformation)
th1.Start()
let th2 = Thread(ParameterizedThreadStart showThreadInformation)
th2.IsBackground <- true
th2.Start()
Thread.Sleep 500
showThreadInformation ()

// The example displays output like the following:
//       Managed thread #6:
//          Background thread: True
//          Thread pool thread: False
//          Priority: Normal
//          Culture: en-US
//          UI culture: en-US
//
//       Managed thread #3:
//          Background thread: True
//          Thread pool thread: True
//          Priority: Normal
//          Culture: en-US
//          UI culture: en-US
//
//       Managed thread #4:
//          Background thread: False
//          Thread pool thread: False
//          Priority: Normal
//          Culture: en-US
//          UI culture: en-US
//
//       Managed thread #1:
//          Background thread: False
//          Thread pool thread: False
//          Priority: Normal
//          Culture: en-US
//          UI culture: en-US
// </Snippet4>
