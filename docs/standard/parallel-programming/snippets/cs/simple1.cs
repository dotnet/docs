using System;
using System.Threading.Tasks;

public class SimpleExample
{
    public static async Task Main()
    {
        // Declare, assign, and start the antecedent task.
        Task<DayOfWeek> taskA = Task.Run(() => DateTime.Today.DayOfWeek);

        // Execute the continuation when the antecedent finishes.
        await taskA.ContinueWith(antecedent => Console.WriteLine($"Today is {antecedent.Result}."));
    }
}
// The example displays the following output:
//       Today is Monday.