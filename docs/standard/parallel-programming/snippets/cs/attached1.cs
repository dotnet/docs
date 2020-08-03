using System;
using System.Threading.Tasks;

public class AttachedExample
{
    public static async Task Main()
    {
        await Task.Factory
                  .StartNew(
            () =>
            {
                Console.WriteLine($"Running antecedent task {Task.CurrentId}...");
                Console.WriteLine("Launching attached child tasks...");
                for (int ctr = 1; ctr <= 5; ctr++)
                {
                    int index = ctr;
                    Task.Factory.StartNew(async value =>
                    {
                        Console.WriteLine($"   Attached child task #{value} running");
                        await Task.Delay(1000);
                    }, index, TaskCreationOptions.AttachedToParent);
                }
                Console.WriteLine("Finished launching attached child tasks...");
            }).ContinueWith(
                antecedent =>
                    Console.WriteLine($"Executing continuation of Task {antecedent.Id}"));
    }
}
// The example displays the similar output:
//     Running antecedent task 1...
//     Launching attached child tasks...
//     Finished launching attached child tasks...
//        Attached child task #1 running
//        Attached child task #5 running
//        Attached child task #3 running
//        Attached child task #2 running
//        Attached child task #4 running
//     Executing continuation of Task 1