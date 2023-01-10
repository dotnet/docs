using System.CommandLine;
using System.CommandLine.Invocation;

namespace ContextExitCode;

class Program
{
    // <contextexitcode>
    static async Task<int> Main(string[] args)
    {
        var delayOption = new Option<int>("--delay");
        var messageOption = new Option<string>("--message");

        var rootCommand = new RootCommand("Parameter binding example");
        rootCommand.Add(delayOption);
        rootCommand.Add(messageOption);

        rootCommand.SetHandler(async (context) =>
            {
                int delayOptionValue = context.ParseResult.GetValueForOption(delayOption);
                string? messageOptionValue = context.ParseResult.GetValueForOption(messageOption);
            
                Console.WriteLine($"--delay = {delayOptionValue}");
                await Task.Delay(delayOptionValue);
                Console.WriteLine($"--message = {messageOptionValue}");
                context.ExitCode = 100;
            });

        return await rootCommand.InvokeAsync(args);
    }
// </contextexitcode>
}
