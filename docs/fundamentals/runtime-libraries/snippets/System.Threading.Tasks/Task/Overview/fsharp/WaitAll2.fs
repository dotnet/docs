module WaitAll2
// <Snippet12>
open System
open System.Threading
open System.Threading.Tasks

// Create a cancellation token and cancel it.
let source1 = new CancellationTokenSource()
let token1 = source1.Token
source1.Cancel()
// Create a cancellation token for later cancellation.
let source2 = new CancellationTokenSource()
let token2 = source2.Token

// Create a series of tasks that will complete, be cancelled,
// timeout, or throw an exception.
let tasks =
    [| for i in 0..11 do
           match i % 4 with
           // Task should run to completion.
           | 0 -> Task.Run(fun () -> Thread.Sleep 2000)
           // Task should be set to canceled state.
           | 1 -> Task.Run(fun () -> Thread.Sleep 2000, token1)
           // Task should throw an exception.
           | 2 -> Task.Run(fun () -> NotSupportedException())
           // Task should examine cancellation token.
           | _ ->
               Task.Run(fun () ->
                   Thread.Sleep 2000

                   if token2.IsCancellationRequested then
                       token2.ThrowIfCancellationRequested()

                   Thread.Sleep 500, token2) |]


Thread.Sleep 250
source2.Cancel()

try
    Task.WaitAll tasks

with :? AggregateException as ae ->
    printfn "One or more exceptions occurred:"

    for ex in ae.InnerExceptions do
        printfn $"   {ex.GetType().Name}: {ex.Message}"

printfn "\nStatus of tasks:"

for t in tasks do
    printfn $"   Task #{t.Id}: {t.Status}"

    if isNull t.Exception |> not then
        for ex in t.Exception.InnerExceptions do
            printfn $"      {ex.GetType().Name}: {ex.Message}"

// The example displays output like the following:
//   One or more exceptions occurred:
//      TaskCanceledException: A task was canceled.
//      NotSupportedException: Specified method is not supported.
//      TaskCanceledException: A task was canceled.
//      TaskCanceledException: A task was canceled.
//      NotSupportedException: Specified method is not supported.
//      TaskCanceledException: A task was canceled.
//      TaskCanceledException: A task was canceled.
//      NotSupportedException: Specified method is not supported.
//      TaskCanceledException: A task was canceled.
//
//   Status of tasks:
//      Task #13: RanToCompletion
//      Task #1: Canceled
//      Task #3: Faulted
//         NotSupportedException: Specified method is not supported.
//      Task #8: Canceled
//      Task #14: RanToCompletion
//      Task #4: Canceled
//      Task #6: Faulted
//         NotSupportedException: Specified method is not supported.
//      Task #7: Canceled
//      Task #15: RanToCompletion
//      Task #9: Canceled
//      Task #11: Faulted
//         NotSupportedException: Specified method is not supported.
//      Task #12: Canceled
// </Snippet12>
