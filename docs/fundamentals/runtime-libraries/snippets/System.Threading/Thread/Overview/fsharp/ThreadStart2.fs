module ThreadStart2
// <Snippet2>
open System
open System.Diagnostics
open System.Threading

let executeInForeground obj =
    let interval =
        try
            unbox<int> obj
        with :? InvalidCastException ->
            5000

    let sw = Stopwatch.StartNew()

    printfn $"Thread {Thread.CurrentThread.ManagedThreadId}: {Thread.CurrentThread.ThreadState}, Priority {Thread.CurrentThread.Priority}"

    while sw.ElapsedMilliseconds <= interval do
        printfn $"Thread {Thread.CurrentThread.ManagedThreadId}: Elapsed {sw.ElapsedMilliseconds / 1000L:N2} seconds"
        Thread.Sleep 500

    sw.Stop()

let th = Thread(ParameterizedThreadStart executeInForeground)
th.Start 4500
Thread.Sleep 1000
printfn $"Main thread ({Thread.CurrentThread.ManagedThreadId}) exiting..."

// The example displays output like the following:
//       Thread 3: Running, Priority Normal
//       Thread 3: Elapsed 0.00 seconds
//       Thread 3: Elapsed 0.52 seconds
//       Main thread (1) exiting...
//       Thread 3: Elapsed 1.03 seconds
//       Thread 3: Elapsed 1.55 seconds
//       Thread 3: Elapsed 2.06 seconds
//       Thread 3: Elapsed 2.58 seconds
//       Thread 3: Elapsed 3.09 seconds
//       Thread 3: Elapsed 3.61 seconds
//       Thread 3: Elapsed 4.12 seconds
// </Snippet2>
