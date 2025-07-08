module Wait2
// <Snippet9>
open System
open System.Threading
open System.Threading.Tasks

// Wait on a single task with a timeout specified.
let taskA = Task.Run(fun () -> Thread.Sleep 2000)

try
    taskA.Wait 1000 |> ignore // Wait for 1 second.
    let completed = taskA.IsCompleted
    printfn $"Task A completed: {completed}, Status: {taskA.Status}"

    if not completed then
        printfn "Timed out before task A completed."

with :? AggregateException ->
    printfn "Exception in taskA."


// The example displays output like the following:
//     Task A completed: False, Status: Running
//     Timed out before task A completed.
// </Snippet9>
