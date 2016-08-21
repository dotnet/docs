// This is a simulated cancellable computation. It checks the token source
// to see if the cancel signal was received.
let computation (tokenSource:System.Threading.CancellationTokenSource) =
    async {
        while (not tokenSource.IsCancellationRequested) do
            do! Async.Sleep(100)
    }

let tokenSource1 = new System.Threading.CancellationTokenSource()
let tokenSource2 = new System.Threading.CancellationTokenSource()
Async.StartWithContinuations(computation tokenSource1,
                             (fun _ -> printfn "Computation 1 completed." ),
                             (fun _ -> printfn "Computation 1 exception." ),
                             (fun _ -> printfn "Computation 1 canceled." ),
                             tokenSource1.Token)
Async.StartWithContinuations(computation tokenSource2,
                             (fun _ -> printfn "Computation 2 completed." ),
                             (fun _ -> printfn "Computation 2 exception." ),
                             (fun _ -> printfn "Computation 2 canceled." ),
                             tokenSource2.Token)
printfn "Started computations."
System.Threading.Thread.Sleep(1000)
printfn "Sending cancellation signal."
tokenSource1.Cancel()
tokenSource2.Cancel()

// Wait for user input to prevent application termination.
System.Console.ReadLine() |> ignore