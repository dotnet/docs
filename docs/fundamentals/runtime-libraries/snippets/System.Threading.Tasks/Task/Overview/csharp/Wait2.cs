// <Snippet9>
using System;
using System.Threading;
using System.Threading.Tasks;

public class Example5
{
    public static void Main()
    {
        // Wait on a single task with a timeout specified.
        Task taskA = Task.Run(() => Thread.Sleep(2000));
        try
        {
            taskA.Wait(1000);       // Wait for 1 second.
            bool completed = taskA.IsCompleted;
            Console.WriteLine("Task A completed: {0}, Status: {1}",
                             completed, taskA.Status);
            if (!completed)
                Console.WriteLine("Timed out before task A completed.");
        }
        catch (AggregateException)
        {
            Console.WriteLine("Exception in taskA.");
        }
    }
}
// The example displays output like the following:
//     Task A completed: False, Status: Running
//     Timed out before task A completed.
// </Snippet9>
