// <all>
using System.CommandLine;

class Program
{
    static async Task Main(string[] args)
    {
        RootCommand rootCommand = new("Sample command-line app");

        rootCommand.SetAction(parseResult =>
        {
            Console.WriteLine("Hello world!");
        });

        await rootCommand.Parse(args).InvokeAsync();
    }
}
// </all>
