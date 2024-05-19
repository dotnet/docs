module BackgroundEx1
// <Snippet3>
open System.Diagnostics
open System.Threading

let executeInForeground () =
    let sw = Stopwatch.StartNew()
    printfn $"Thread {Thread.CurrentThread.ManagedThreadId}: {Thread.CurrentThread.ThreadState}, Priority {Thread.CurrentThread.Priority}"
    while sw.ElapsedMilliseconds <= 5000 do
        printfn $"Thread {Thread.CurrentThread.ManagedThreadId}: Elapsed {sw.ElapsedMilliseconds / 1000L:N2} seconds"
        Thread.Sleep 500
    sw.Stop()

let th = Thread executeInForeground
th.IsBackground <- true
th.Start()
Thread.Sleep 1000
printfn $"Main thread ({Thread.CurrentThread.ManagedThreadId}) exiting..."

// The example displays output like the following:
//       Thread 3: Background, Priority Normal
//       Thread 3: Elapsed 0.00 seconds
//       Thread 3: Elapsed 0.51 seconds
//       Main thread (1) exiting...
// </Snippet3>