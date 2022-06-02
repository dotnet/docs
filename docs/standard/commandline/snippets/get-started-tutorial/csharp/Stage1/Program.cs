// <all>
using System.CommandLine;

namespace scl;

class Program
{
    static async Task<int> Main(string[] args)
    {
        // <option>
        var fileOption = new Option<FileInfo?>(
            name: "--file",
            description: "The file to read and display on the console.");

        var rootCommand = new RootCommand("Sample app for System.CommandLine");
        rootCommand.AddOption(fileOption);
        // </option>

        // <sethandler>
        rootCommand.SetHandler((file) => 
            { 
                ReadFile(file!); 
            },
            fileOption);
        // </sethandler>

        return await rootCommand.InvokeAsync(args);
    }

    // <handler>
    static void ReadFile(FileInfo file)
    {
        File.ReadLines(file.FullName).ToList()
            .ForEach(line => Console.WriteLine(line));
    }
    // </handler>
}
// </all>
