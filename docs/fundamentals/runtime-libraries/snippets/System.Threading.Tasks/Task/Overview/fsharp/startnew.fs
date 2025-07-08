module startnew
// <snippet01>
open System.Threading
open System.Threading.Tasks

let action =
    fun (obj: obj) -> printfn $"Task={Task.CurrentId}, obj={obj}, Thread={Thread.CurrentThread.ManagedThreadId}"

// Create a task but do not start it.
let t1 = new Task(action, "alpha")

// Construct a started task
let t2 = Task.Factory.StartNew(action, "beta")
// Block the main thread to demonstrate that t2 is executing
t2.Wait()

// Launch t1
t1.Start()
printfn $"t1 has been launched. (Main Thread={Thread.CurrentThread.ManagedThreadId})"
// Wait for the task to finish.
t1.Wait()

// Construct a started task using Task.Run.
let taskData = "delta"

let t3 =
    Task.Run(fun () -> printfn $"Task={Task.CurrentId}, obj={taskData}, Thread={Thread.CurrentThread.ManagedThreadId}")
// Wait for the task to finish.
t3.Wait()

// Construct an unstarted task
let t4 = new Task(action, "gamma")
// Run it synchronously
t4.RunSynchronously()
// Although the task was run synchronously, it is a good practice
// to wait for it in the event exceptions were thrown by the task.
t4.Wait()


// The example displays output like the following:
//       Task=1, obj=beta, Thread=3
//       t1 has been launched. (Main Thread=1)
//       Task=2, obj=alpha, Thread=4
//       Task=3, obj=delta, Thread=3
//       Task=4, obj=gamma, Thread=1
// </snippet01>
