module Wait1
// <Snippet8>
open System
open System.Threading
open System.Threading.Tasks

let rand = Random()

// Wait on a single task with no timeout specified.
let taskA = Task.Run(fun () -> Thread.Sleep 2000)
printfn $"taskA Status: {taskA.Status}"
try 
    taskA.Wait()
    printfn $"taskA Status: {taskA.Status}"

with :? AggregateException ->
    printfn "Exception in taskA."

// The example displays output like the following:
//     taskA Status: WaitingToRun
//     taskA Status: RanToCompletion
// </Snippet8>
