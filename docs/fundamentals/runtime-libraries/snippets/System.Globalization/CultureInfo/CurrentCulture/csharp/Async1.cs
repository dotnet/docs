// <Snippet14>
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Versioning;
using System.Threading;
using System.Threading.Tasks;

public class Example14
{
    public static async Task Main()
    {
        var tasks = new List<Task>();
        Console.WriteLine($"The current culture is {Thread.CurrentThread.CurrentCulture.Name}");
        Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
        // Change the current culture to Portuguese (Brazil).
        Console.WriteLine($"Current culture changed to {Thread.CurrentThread.CurrentCulture.Name}");
        Console.WriteLine($"Application thread is thread {Thread.CurrentThread.ManagedThreadId}");
        // Launch six tasks and display their current culture.
        for (int ctr = 0; ctr <= 5; ctr++)
            tasks.Add(Task.Run(() =>
            {
                Console.WriteLine($"Culture of task {Task.CurrentId} on thread {Thread.CurrentThread.ManagedThreadId} is {Thread.CurrentThread.CurrentCulture.Name}");
            }));

        await Task.WhenAll(tasks.ToArray());
    }
}
// The example displays output like the following:
//     The current culture is en-US
//     Current culture changed to pt-BR
//     Application thread is thread 9
//     Culture of task 2 on thread 11 is pt-BR
//     Culture of task 1 on thread 10 is pt-BR
//     Culture of task 3 on thread 11 is pt-BR
//     Culture of task 5 on thread 11 is pt-BR
//     Culture of task 6 on thread 11 is pt-BR
//     Culture of task 4 on thread 10 is pt-BR
// </Snippet14>
