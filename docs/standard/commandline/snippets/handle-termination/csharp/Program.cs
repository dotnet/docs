using System.CommandLine;

class Program
{
    // <asyncaction>
    static Task<int> Main(string[] args)
    {
        Option<string> urlOption = new("--url", "A URL.");
        RootCommand rootCommand = new("Handle termination example") { urlOption };

        rootCommand.SetAction((ParseResult parseResult, CancellationToken cancellationToken) =>
        {
            string? urlOptionValue = parseResult.GetValue(urlOption);
            return DoRootCommand(urlOptionValue, cancellationToken);
        });

        return rootCommand.Parse(args).InvokeAsync();
    }

    public static async Task<int> DoRootCommand(
        string? urlOptionValue, CancellationToken cancellationToken)
    {
        using HttpClient httpClient = new();

        try
        {
            await httpClient.GetAsync(urlOptionValue, cancellationToken);
            return 0;
        }
        catch (OperationCanceledException)
        {
            await Console.Error.WriteLineAsync("The operation was aborted");
            return 1;
        }
    }
    // </asyncaction>
}
