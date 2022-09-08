// <all>
using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Parsing;

class Program
{
    static async Task Main(string[] args)
    {
        var delayOption = new Option<int>("--delay");
        var messageOption = new Option<string>("--message");

        var rootCommand = new RootCommand("Middleware example");
        rootCommand.Add(delayOption);
        rootCommand.Add(messageOption);

        rootCommand.SetHandler((delayOptionValue, messageOptionValue) =>
            {
                DoRootCommand(delayOptionValue, messageOptionValue);
            },
            delayOption, messageOption);

        // <middleware>
        var commandLineBuilder = new CommandLineBuilder(rootCommand);

        commandLineBuilder.AddMiddleware(async (context, next) =>
        {
            if (context.ParseResult.Directives.Contains("just-say-hi"))
            {
                context.Console.WriteLine("Hi!");
            }
            else
            {
                await next(context);
            }
        });

        commandLineBuilder.UseDefaults();
        var parser = commandLineBuilder.Build();
        await parser.InvokeAsync(args);
        // </middleware>
    }

    public static void DoRootCommand(int delay, string message)
    {
        Console.WriteLine($"--delay = {delay}");
        Console.WriteLine($"--message = {message}");
    }
}
// </all>

