// <Snippet11>
using System;
using System.Threading;
using System.Threading.Tasks;

public class Example3
{
    public static void Main()
    {
        // Wait for all tasks to complete.
        Task[] tasks = new Task[10];
        for (int i = 0; i < 10; i++)
        {
            tasks[i] = Task.Run(() => Thread.Sleep(2000));
        }
        try
        {
            Task.WaitAll(tasks);
        }
        catch (AggregateException ae)
        {
            Console.WriteLine("One or more exceptions occurred: ");
            foreach (var ex in ae.Flatten().InnerExceptions)
                Console.WriteLine($"   {ex.Message}");
        }

        Console.WriteLine("Status of completed tasks:");
        foreach (var t in tasks)
            Console.WriteLine($"   Task #{t.Id}: {t.Status}");
    }
}
// The example displays the following output:
//     Status of completed tasks:
//        Task #2: RanToCompletion
//        Task #1: RanToCompletion
//        Task #3: RanToCompletion
//        Task #4: RanToCompletion
//        Task #6: RanToCompletion
//        Task #5: RanToCompletion
//        Task #7: RanToCompletion
//        Task #8: RanToCompletion
//        Task #9: RanToCompletion
//        Task #10: RanToCompletion
// </Snippet11>
