public class ExampleTask
{
    // <TaskReturn>
    public static async Task DisplayCurrentInfoAsync()
    {
        await WaitAndApologizeAsync();

        Console.WriteLine($"Today is {DateTime.Now:D}");
        Console.WriteLine($"The current time is {DateTime.Now.TimeOfDay:t}");
        Console.WriteLine("The current temperature is 76 degrees.");
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
    // </TaskReturn>
}
