module ThreadSafeEx1

// <Snippet3>
open System
open System.Threading

type Example() =
    [<ThreadStatic; DefaultValue>]
    static val mutable private previous : float
    
    [<ThreadStatic; DefaultValue>]
    static val mutable private perThreadCtr : int

    [<ThreadStatic; DefaultValue>]
    static val mutable private perThreadTotal : float

    static let source = new CancellationTokenSource()
    static let countdown = new CountdownEvent(1)
    static let randLock = obj ()
    static let numericLock = obj ()
    static let rand = Random()

    let mutable totalValue = 0.0
    let mutable totalCount = 0

    member _.GetRandomNumbers(token: CancellationToken) =
        let mutable result = 0.0
        countdown.AddCount 1
        try 
            try
                for _ = 0 to 1999999 do
                    // Make sure there's no corruption of Random.
                    token.ThrowIfCancellationRequested()

                    lock randLock (fun () -> 
                        result <- rand.NextDouble() )

                    // Check for corruption of Random instance.
                    if result = Example.previous && result = 0.0 then 
                        source.Cancel()
                    else
                        Example.previous <- result
                        
                    Example.perThreadCtr <- Example.perThreadCtr + 1
                    Example.perThreadTotal <- Example.perThreadTotal + result

                // Update overall totals.
                lock numericLock (fun () ->
                    // Show result.
                    printfn "Thread %s finished execution." Thread.CurrentThread.Name
                    printfn $"Random numbers generated: {Example.perThreadCtr:N0}" 
                    printfn $"Sum of random numbers: {Example.perThreadTotal:N2}" 
                    printfn $"Random number mean: {(Example.perThreadTotal / float Example.perThreadCtr):N4}\n"
                    
                    // Update overall totals.
                    totalCount <- totalCount + Example.perThreadCtr
                    totalValue <- totalValue + Example.perThreadTotal)

            with :? OperationCanceledException as e -> 
                printfn "Corruption in Thread %s %s" (e.GetType().Name) Thread.CurrentThread.Name
        finally
            countdown.Signal() |> ignore

    member this.Execute() =
        let token = source.Token
        for i = 1 to 10 do 
            let newThread = Thread(fun () -> this.GetRandomNumbers token)
            newThread.Name <- string i
            newThread.Start()
        this.GetRandomNumbers token
        
        countdown.Signal() |> ignore

        countdown.Wait()

        source.Dispose()

        printfn $"\nTotal random numbers generated: {totalCount:N0}"
        printfn $"Total sum of all random numbers: {totalValue:N2}"
        printfn $"Random number mean: {(totalValue / float totalCount):N4}"

let ex = Example()
Thread.CurrentThread.Name <- "Main"
ex.Execute()

// The example displays output like the following:
//       Thread 6 finished execution.
//       Random numbers generated: 2,000,000
//       Sum of random numbers: 1,000,491.05
//       Random number mean: 0.5002
//
//       Thread 10 finished execution.
//       Random numbers generated: 2,000,000
//       Sum of random numbers: 999,329.64
//       Random number mean: 0.4997
//
//       Thread 4 finished execution.
//       Random numbers generated: 2,000,000
//       Sum of random numbers: 1,000,166.89
//       Random number mean: 0.5001
//
//       Thread 8 finished execution.
//       Random numbers generated: 2,000,000
//       Sum of random numbers: 999,628.37
//       Random number mean: 0.4998
//
//       Thread Main finished execution.
//       Random numbers generated: 2,000,000
//       Sum of random numbers: 999,920.89
//       Random number mean: 0.5000
//
//       Thread 3 finished execution.
//       Random numbers generated: 2,000,000
//       Sum of random numbers: 999,370.45
//       Random number mean: 0.4997
//
//       Thread 7 finished execution.
//       Random numbers generated: 2,000,000
//       Sum of random numbers: 999,330.92
//       Random number mean: 0.4997
//
//       Thread 9 finished execution.
//       Random numbers generated: 2,000,000
//       Sum of random numbers: 1,000,172.79
//       Random number mean: 0.5001
//
//       Thread 5 finished execution.
//       Random numbers generated: 2,000,000
//       Sum of random numbers: 1,000,079.43
//       Random number mean: 0.5000
//
//       Thread 1 finished execution.
//       Random numbers generated: 2,000,000
//       Sum of random numbers: 999,817.91
//       Random number mean: 0.4999
//
//       Thread 2 finished execution.
//       Random numbers generated: 2,000,000
//       Sum of random numbers: 999,930.63
//       Random number mean: 0.5000
//
//
//       Total random numbers generated: 22,000,000
//       Total sum of all random numbers: 10,998,238.98
//       Random number mean: 0.4999
// </Snippet3>
