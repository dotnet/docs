using System;
using System.Threading.Tasks;

public class ExceptionExample
{
    public static async Task Main()
    {
        Task<int> task = Task.Run(
            () =>
            {
                Console.WriteLine($"Executing task {Task.CurrentId}");
                return 54;
            });

        var continuation = task.ContinueWith(
            antecedent =>
            {
                Console.WriteLine($"Executing continuation task {Task.CurrentId}");
                Console.WriteLine($"Value from antecedent: {antecedent.Result}");

                throw new InvalidOperationException();
            });

        try
        {
            await task;
            await continuation;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
// The example displays the similar output:
//       Executing task 1
//       Executing continuation task 2
//       Value from antecedent: 54
//       Operation is not valid due to the current state of the object.