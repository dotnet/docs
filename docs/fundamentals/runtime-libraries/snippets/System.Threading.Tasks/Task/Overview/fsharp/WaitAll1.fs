module WaitAll1
// <Snippet11>
open System
open System.Threading
open System.Threading.Tasks

// Wait for all tasks to complete.
let tasks =
    [| for _ = 0 to 9 do
           Task.Run(fun () -> Thread.Sleep 2000) |]

try
    Task.WaitAll tasks

with :? AggregateException as ae ->
    printfn "One or more exceptions occurred: "

    for ex in ae.Flatten().InnerExceptions do
        printfn $"   {ex.Message}"

printfn "Status of completed tasks:"

for t in tasks do
    printfn $"   Task #{t.Id}: {t.Status}"

// The example displays the following output:
//     Status of completed tasks:
//        Task #2: RanToCompletion
//        Task #1: RanToCompletion
//        Task #3: RanToCompletion
//        Task #4: RanToCompletion
//        Task #6: RanToCompletion
//        Task #5: RanToCompletion
//        Task #7: RanToCompletion
//        Task #8: RanToCompletion
//        Task #9: RanToCompletion
//        Task #10: RanToCompletion
// </Snippet11>
