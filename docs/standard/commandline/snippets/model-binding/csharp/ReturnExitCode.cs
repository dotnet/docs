using System.CommandLine;

namespace ReturnExitCode;

class Program
{
    // <returnexitcode>
    static async Task<int> Main(string[] args)
    {
        var delayOption = new Option<int>("--delay");
        var messageOption = new Option<string>("--message");

        var rootCommand = new RootCommand("Parameter binding example");
        rootCommand.Add(delayOption);
        rootCommand.Add(messageOption);

        rootCommand.SetHandler((delayOptionValue, messageOptionValue) =>
            {
                Console.WriteLine($"--delay = {delayOptionValue}");
                Console.WriteLine($"--message = {messageOptionValue}");
                return Task.FromResult(100);
            },
            delayOption, messageOption);

        return await rootCommand.InvokeAsync(args);
    }
// </returnexitcode>
}
