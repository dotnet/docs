using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

class ContinuationStateExample
{
    static DateTime DoWork()
    {
        Thread.Sleep(2000);

        return DateTime.Now;
    }

    static async Task Main()
    {
        Task<DateTime> task = Task.Run(() => DoWork());

        var continuations = new List<Task<DateTime>>();
        for (int i = 0; i < 5; i++)
        {
            task = task.ContinueWith((antecedent, _) => DoWork(), DateTime.Now);
            continuations.Add(task);
        }

        await task;

        foreach (Task<DateTime> continuation in continuations)
        {
            DateTime start = (DateTime)continuation.AsyncState;
            DateTime end = continuation.Result;

            Console.WriteLine($"Task was created at {start.TimeOfDay} and finished at {end.TimeOfDay}.");
        }

        Console.ReadLine();
    }
}
// The example displays the similar output:
//     Task was created at 10:56:21.1561762 and finished at 10:56:25.1672062.
//     Task was created at 10:56:21.1610677 and finished at 10:56:27.1707646.
//     Task was created at 10:56:21.1610677 and finished at 10:56:29.1743230.
//     Task was created at 10:56:21.1610677 and finished at 10:56:31.1779883.
//     Task was created at 10:56:21.1610677 and finished at 10:56:33.1837083.