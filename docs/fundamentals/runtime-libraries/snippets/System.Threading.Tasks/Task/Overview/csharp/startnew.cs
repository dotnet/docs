// <snippet01>
using System;
using System.Threading;
using System.Threading.Tasks;

class Example1
{
    static void Main()
    {
        Action<object> action = (object obj) =>
                                {
                                    Console.WriteLine("Task={0}, obj={1}, Thread={2}",
                                    Task.CurrentId, obj,
                                    Thread.CurrentThread.ManagedThreadId);
                                };

        // Create a task but do not start it.
        Task t1 = new Task(action, "alpha");

        // Construct a started task
        Task t2 = Task.Factory.StartNew(action, "beta");
        // Block the main thread to demonstrate that t2 is executing
        t2.Wait();

        // Launch t1 
        t1.Start();
        Console.WriteLine($"t1 has been launched. (Main Thread={Thread.CurrentThread.ManagedThreadId})");
        // Wait for the task to finish.
        t1.Wait();

        // Construct a started task using Task.Run.
        String taskData = "delta";
        Task t3 = Task.Run(() =>
        {
            Console.WriteLine("Task={0}, obj={1}, Thread={2}",
                                                     Task.CurrentId, taskData,
                                                      Thread.CurrentThread.ManagedThreadId);
        });
        // Wait for the task to finish.
        t3.Wait();

        // Construct an unstarted task
        Task t4 = new Task(action, "gamma");
        // Run it synchronously
        t4.RunSynchronously();
        // Although the task was run synchronously, it is a good practice
        // to wait for it in the event exceptions were thrown by the task.
        t4.Wait();
    }
}
// The example displays output like the following:
//       Task=1, obj=beta, Thread=3
//       t1 has been launched. (Main Thread=1)
//       Task=2, obj=alpha, Thread=4
//       Task=3, obj=delta, Thread=3
//       Task=4, obj=gamma, Thread=1
// </snippet01>
