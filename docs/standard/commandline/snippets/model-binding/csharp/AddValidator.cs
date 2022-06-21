namespace AddValidator;

// <all>
using System.CommandLine;

class Program
{
    internal static async Task Main(string[] args)
    {
        // <delayOption>
        var delayOption = new Option<int>("--delay");
        delayOption.AddValidator(result =>
        {
            if (result.GetValueForOption(delayOption) < 1)
            {
                result.ErrorMessage = "Must be greater than 0";
            }
        });
        // </delayoption>

        var rootCommand = new RootCommand();
        rootCommand.Add(delayOption);

        rootCommand.SetHandler((delayOptionValue) =>
            {
                Console.WriteLine($"--delay = {delayOptionValue}");
            },
            delayOption);

        await rootCommand.InvokeAsync(args);
    }
}
// </all>
