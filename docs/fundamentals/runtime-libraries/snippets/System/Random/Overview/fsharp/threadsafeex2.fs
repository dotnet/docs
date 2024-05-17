module ThreadSafeEx2

// <Snippet4>
open System
open System.Threading
open System.Threading.Tasks

type Example() =
    static let source = new CancellationTokenSource()
    static let rand = Random()

    static let randLock = obj ()
    static let numericLock = obj ()

    let mutable totalValue = 0.0
    let mutable totalCount = 0

    member _.Execute() =
        use source = source // Dispose of the CancellationTokenSource when we're done with it.
        let token = source.Token

        let tasks =
            [| for i = 0 to 10 do
                   Task.Run(
                       (fun () ->
                           let mutable previous = 0.0
                           let mutable taskCtr = 0
                           let mutable taskTotal = 0.0
                           let mutable result = 0.0

                           for _ = 1 to 2000000 do
                               // Make sure there's no corruption of Random.
                               token.ThrowIfCancellationRequested()

                               lock randLock (fun () -> result <- rand.NextDouble())

                               // Check for corruption of Random instance.
                               if result = previous && result = 0.0 then
                                   source.Cancel()
                               else
                                   previous <- result

                               taskCtr <- taskCtr + 1
                               taskTotal <- taskTotal + result

                           lock numericLock (fun () ->
                               // Show result.
                               printfn "Task %i finished execution." i
                               printfn $"Random numbers generated: {taskCtr:N0}"
                               printfn $"Sum of random numbers: {taskTotal:N2}"
                               printfn $"Random number mean: {(taskTotal / float taskCtr):N4}\n"

                               // Update overall totals.
                               totalCount <- totalCount + taskCtr
                               totalValue <- totalValue + taskTotal)),
                       token
                   ) |]

        try
            // Run tasks with F# Async.
            Task.WhenAll tasks
            |> Async.AwaitTask
            |> Async.RunSynchronously

            printfn $"\nTotal random numbers generated: {totalCount:N0}"
            printfn $"Total sum of all random numbers: {totalValue:N2}"
            printfn $"Random number mean: {(totalValue / float totalCount):N4}"
        with
        | :? AggregateException as e ->
            for inner in e.InnerExceptions do
                match inner with
                | :? TaskCanceledException as canc ->
                    if canc <> null then
                        printfn $"Task #{canc.Task.Id} cancelled"
                    else
                        printfn $"Exception: {inner.GetType().Name}"
                | _ -> ()

let ex = Example()
Thread.CurrentThread.Name <- "Main"
ex.Execute()

// The example displays output like the following:
//       Task 1 finished execution.
//       Random numbers generated: 2,000,000
//       Sum of random numbers: 1,000,502.47
//       Random number mean: 0.5003
//
//       Task 0 finished execution.
//       Random numbers generated: 2,000,000
//       Sum of random numbers: 1,000,445.63
//       Random number mean: 0.5002
//
//       Task 2 finished execution.
//       Random numbers generated: 2,000,000
//       Sum of random numbers: 1,000,556.04
//       Random number mean: 0.5003
//
//       Task 3 finished execution.
//       Random numbers generated: 2,000,000
//       Sum of random numbers: 1,000,178.87
//       Random number mean: 0.5001
//
//       Task 4 finished execution.
//       Random numbers generated: 2,000,000
//       Sum of random numbers: 999,819.17
//       Random number mean: 0.4999
//
//       Task 5 finished execution.
//       Random numbers generated: 2,000,000
//       Sum of random numbers: 1,000,190.58
//       Random number mean: 0.5001
//
//       Task 6 finished execution.
//       Random numbers generated: 2,000,000
//       Sum of random numbers: 999,720.21
//       Random number mean: 0.4999
//
//       Task 7 finished execution.
//       Random numbers generated: 2,000,000
//       Sum of random numbers: 999,000.96
//       Random number mean: 0.4995
//
//       Task 8 finished execution.
//       Random numbers generated: 2,000,000
//       Sum of random numbers: 999,499.33
//       Random number mean: 0.4997
//
//       Task 9 finished execution.
//       Random numbers generated: 2,000,000
//       Sum of random numbers: 1,000,193.25
//       Random number mean: 0.5001
//
//       Task 10 finished execution.
//       Random numbers generated: 2,000,000
//       Sum of random numbers: 999,960.82
//       Random number mean: 0.5000
//
//
//       Total random numbers generated: 22,000,000
//       Total sum of all random numbers: 11,000,067.33
//       Random number mean: 0.5000
// </Snippet4>
