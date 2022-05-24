using System.CommandLine;

class Program
{
    // <mainandhandler>
    static async Task<int> Main(string[] args)
    {
        int returnCode = 0;

        var urlOption = new Option<string>("--url", "A URL.");

        var rootCommand = new RootCommand("Handle termination example");
        rootCommand.Add(urlOption);

        rootCommand.SetHandler(async (context) =>
            {
                string? urlOptionValue = context.ParseResult.GetValueForOption(urlOption);
                var token = context.GetCancellationToken();
                returnCode = await DoRootCommand(urlOptionValue, token);
            });

        await rootCommand.InvokeAsync(args);

        return returnCode;
    }

    public static async Task<int> DoRootCommand(
        string? urlOptionValue, CancellationToken cancellationToken)
    {
        try
        {
            using (var httpClient = new HttpClient())
            {
                await httpClient.GetAsync(urlOptionValue, cancellationToken);
            }
            return 0;
        }
        catch (OperationCanceledException)
        {
            Console.Error.WriteLine("The operation was aborted");
            return 1;
        }
    }
    // </mainandhandler>
}
