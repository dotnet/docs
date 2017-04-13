// <Snippet1>
using System;
using System.Threading;
using System.Threading.Tasks;

public class Example
{
    private static SemaphoreSlim semaphore;
    // A padding interval to make the output more orderly.
    private static int padding;

    public static void Main()
    {
        // Create the semaphore.
        semaphore = new SemaphoreSlim(0, 3);
        Console.WriteLine("{0} tasks can enter the semaphore.",
                          semaphore.CurrentCount);
        Task[] tasks = new Task[5];
        
        // Create and start five numbered tasks.
        for(int i = 0; i <= 4; i++)
        {
            tasks[i] = Task.Run( () => {
            // Each task begins by requesting the semaphore.
            Console.WriteLine("Task {0} begins and waits for the semaphore.",
                              Task.CurrentId);
            semaphore.Wait();

            Interlocked.Add(ref padding, 100);

            Console.WriteLine("Task {0} enters the semaphore.", Task.CurrentId);

            // The task just sleeps for 1+ seconds.
            Thread.Sleep(1000 + padding);

            Console.WriteLine("Task {0} releases the semaphore; previous count: {1}.",
                              Task.CurrentId, semaphore.Release()); } );
        }

        // Wait for half a second, to allow all the tasks to start and block.
        Thread.Sleep(500);

        // Restore the semaphore count to its maximum value.
        Console.Write("Main thread calls Release(3) --> ");
        semaphore.Release(3);
        Console.WriteLine("{0} tasks can enter the semaphore.",
                          semaphore.CurrentCount);
        // Main thread waits for the tasks to complete.
        Task.WaitAll(tasks);
        
        Console.WriteLine("Main thread exits.");
    }
}
// The example displays output like the following:
//       0 tasks can enter the semaphore.
//       Task 1 begins and waits for the semaphore.
//       Task 5 begins and waits for the semaphore.
//       Task 2 begins and waits for the semaphore.
//       Task 4 begins and waits for the semaphore.
//       Task 3 begins and waits for the semaphore.
//       Main thread calls Release(3) --> 3 tasks can enter the semaphore.
//       Task 4 enters the semaphore.
//       Task 1 enters the semaphore.
//       Task 3 enters the semaphore.
//       Task 4 releases the semaphore; previous count: 0.
//       Task 2 enters the semaphore.
//       Task 1 releases the semaphore; previous count: 0.
//       Task 3 releases the semaphore; previous count: 0.
//       Task 5 enters the semaphore.
//       Task 2 releases the semaphore; previous count: 1.
//       Task 5 releases the semaphore; previous count: 2.
//       Main thread exits.
// </Snippet1>



