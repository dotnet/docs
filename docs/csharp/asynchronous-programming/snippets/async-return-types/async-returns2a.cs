public class AwaitTaskExample
{
    public static async Task DisplayCurrentInfoAsync()
    {
        // <AwaitTask>
        Task waitAndApologizeTask = WaitAndApologizeAsync();

        string output =
            $"Today is {DateTime.Now:D}\n" +
            $"The current time is {DateTime.Now.TimeOfDay:t}\n" +
            "The current temperature is 76 degrees.\n";

        await waitAndApologizeTask;
        Console.WriteLine(output);
        // </AwaitTask>
    }

    static async Task WaitAndApologizeAsync()
    {
        await Task.Delay(2000);

        Console.WriteLine("Sorry for the delay...\n");
    }
    // Example output:
    //    Sorry for the delay...
    //
    // Today is Monday, August 17, 2020
    // The current time is 12:59:24.2183304
    // The current temperature is 76 degrees.
}
