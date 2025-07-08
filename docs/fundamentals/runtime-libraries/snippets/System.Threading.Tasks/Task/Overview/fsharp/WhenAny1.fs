module WhenAny1
// <Snippet10>
open System
open System.Threading
open System.Threading.Tasks

let rnd = new Random()

let tasks =
    [| for _ = 0 to 2 do
           Task.Run(fun () -> rnd.Next(500, 3000) |> Thread.Sleep) |]

try
    let index = Task.WaitAny tasks
    printfn $"Task #{tasks[index].Id} completed first.\n"
    printfn "Status of all tasks:"

    for t in tasks do
        printfn $"   Task #{t.Id}: {t.Status}"

with :? AggregateException ->
    printfn "An exception occurred."

// The example displays output like the following:
//     Task #1 completed first.
//
//     Status of all tasks:
//        Task #3: Running
//        Task #1: RanToCompletion
//        Task #4: Running
// </Snippet10>




//         // Wait for first task to complete.
//         Task<double>[] tasks2 = new Task<double>[3];
//
//         // Try three different approaches to the problem. Take the first one.
//         tasks2[0] = Task<double>.Factory.StartNew(() => TrySolution1());
//         tasks2[1] = Task<double>.Factory.StartNew(() => TrySolution2());
//         tasks2[2] = Task<double>.Factory.StartNew(() => TrySolution3());
//
//
//         int index = Task.WaitAny(tasks2);
//         double d = tasks2[index].Result;
//         Console.WriteLine("task[{0}] completed first with result of {1}.", index, d);
//
//         Console.ReadKey();
//
//
//
//     static void DoSomeWork(int val)
//
//         // Pretend to do something.
//         Thread.SpinWait(val);
//
//
//     static double TrySolution1()
//
//         int i = rand.Next(1000000);
//         // Simulate work by spinning
//         Thread.SpinWait(i);
//         return DateTime.Now.Millisecond;
//
//     static double TrySolution2()
//
//         int i = rand.Next(1000000);
//         // Simulate work by spinning
//         Thread.SpinWait(i);
//         return DateTime.Now.Millisecond;
//
//     static double TrySolution3()
//
//         int i = rand.Next(1000000);
//         // Simulate work by spinning
//         Thread.SpinWait(i);
//         Thread.SpinWait(1000000);
//         return DateTime.Now.Millisecond;
//
//
