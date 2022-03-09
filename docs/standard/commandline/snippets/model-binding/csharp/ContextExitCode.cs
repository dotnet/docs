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

        var rootCommand = new RootCommand("Model binding example");
        rootCommand.Add(delayOption);
        rootCommand.Add(messageOption);

        rootCommand.SetHandler(async
            (int delayOptionValue, string messageOptionValue, InvocationContext ctx) =>
            {
                Console.WriteLine($"--delay = {delayOptionValue}");
                await Task.Delay(delayOptionValue);
                Console.WriteLine($"--message = {messageOptionValue}");
                ctx.ExitCode = 100;
            },
            delayOption, messageOption);

        return await rootCommand.InvokeAsync(args);
    }
// </contextexitcode>
}
