// <all>
using System.CommandLine;

class Program
{
    static async Task Main(string[] args)
    {
        var rootCommand = new RootCommand("Sample command-line app");

        rootCommand.SetHandler(() =>
        {
            Console.WriteLine("Hello world!");
        });

        await rootCommand.InvokeAsync(args);
    }
}
// </all>
