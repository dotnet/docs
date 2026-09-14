
using System;
using System.Threading.Tasks;

public class AsyncExample
{
    public static async Task TaskDiscard()
    {
        await ExecuteAsyncMethods();
    }

    // <ArgNullCheck>
    public static void Method(string arg)
    {
        _ = arg ?? throw new ArgumentNullException(paramName: nameof(arg), message: "arg can't be null");

        // Do work with arg.
    }
    // </ArgNullCheck>

    // <SnippetDiscardTask>
    private static async Task ExecuteAsyncMethods()
    {
        Console.WriteLine("About to launch a task...");
        _ = Task.Run(() =>
        {
            var iterations = 0;
            for (int ctr = 0; ctr < int.MaxValue; ctr++)
                iterations++;
            Console.WriteLine("Completed looping operation...");
            throw new InvalidOperationException();
        });
        await Task.Delay(5000);
        Console.WriteLine("Exiting after 5 second delay");
    }
    // The example displays output like the following:
    //       About to launch a task...
    //       Completed looping operation...
    //       Exiting after 5 second delay
    // </SnippetDiscardTask>
}

public class Unused
{
    // <SnippetNoDiscardTask>
    private static async Task ExecuteAsyncMethods()
    {
        Console.WriteLine("About to launch a task...");
        // CS4014: Because this call is not awaited, execution of the current method continues before the call is completed.
        // Consider applying the 'await' operator to the result of the call.
        Task.Run(() =>
        {
            var iterations = 0;
            for (int ctr = 0; ctr < int.MaxValue; ctr++)
                iterations++;
            Console.WriteLine("Completed looping operation...");
            throw new InvalidOperationException();
        });
        await Task.Delay(5000);
        Console.WriteLine("Exiting after 5 second delay");
        // </SnippetNoDiscardTask>
    }

}
