using System;
using System.Threading.Tasks;

public class AwaitTaskExample
{
    public static async Task DisplayCurrentInfo()
    {
        // <SnippetAwaitTask>
        Task wait = WaitAndApologize();

        string output = $"Today is {DateTime.Now:D}\n" +
                        $"The current time is {DateTime.Now.TimeOfDay:t}\n" +
                        $"The current temperature is 76 degrees.\n";
        await wait;
        Console.WriteLine(output);
        // </SnippetAwaitTask>
    }

    static async Task WaitAndApologize()
    {
        // Task.Delay is a placeholder for actual work.
        await Task.Delay(2000);
        // Task.Delay delays the following line by two seconds.
        Console.WriteLine("\nSorry for the delay. . . .\n");
    }
}
// The example displays the following output:
//       Sorry for the delay. . . .
//
//       Today is Wednesday, May 24, 2017
//       The current time is 15:25:16.2935649
//       The current temperature is 76 degrees.
