module ThreadStart1
// <Snippet1>
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
th.Start()
Thread.Sleep 1000
printfn $"Main thread ({Thread.CurrentThread.ManagedThreadId}) exiting..."

// The example displays output like the following:
//       Thread 3: Running, Priority Normal
//       Thread 3: Elapsed 0.00 seconds
//       Thread 3: Elapsed 0.51 seconds
//       Main thread (1) exiting...
//       Thread 3: Elapsed 1.02 seconds
//       Thread 3: Elapsed 1.53 seconds
//       Thread 3: Elapsed 2.05 seconds
//       Thread 3: Elapsed 2.55 seconds
//       Thread 3: Elapsed 3.07 seconds
//       Thread 3: Elapsed 3.57 seconds
//       Thread 3: Elapsed 4.07 seconds
//       Thread 3: Elapsed 4.58 seconds
// </Snippet1>
