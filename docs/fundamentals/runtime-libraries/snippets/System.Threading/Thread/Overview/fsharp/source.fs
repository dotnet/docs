module source
// <Snippet1>
open System.Threading

// Simple threading scenario:  Start a static method running
// on a second thread.

// The ThreadProc method is called when the thread starts.
// It loops ten times, writing to the console and yielding
// the rest of its time slice each time, and then ends.
let threadProc () =
    for i = 0 to 9 do
        printfn $"ThreadProc: {i}"
        // Yield the rest of the time slice.
        Thread.Sleep 0

printfn "Main thread: Start a second thread."
// The constructor for the Thread class requires a ThreadStart
// delegate that represents the method to be executed on the
// thread. F# simplifies the creation of this delegate.
let t = Thread threadProc

// Start ThreadProc.  Note that on a uniprocessor, the new
// thread does not get any processor time until the main thread
// is preempted or yields.  Uncomment the Thread.Sleep that
// follows t.Start() to see the difference.
t.Start()
//Thread.Sleep 0

for _ = 0 to 3 do
    printfn "Main thread: Do some work."
    Thread.Sleep 0

printfn "Main thread: Call Join(), to wait until ThreadProc ends."
t.Join()
printfn "Main thread: ThreadProc.Join has returned.  Press Enter to end program."
stdin.ReadLine() |> ignore
// </Snippet1>
