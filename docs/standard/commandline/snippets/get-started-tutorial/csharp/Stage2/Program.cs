// <all>
using System.CommandLine;

namespace scl;

class Program
{
    static int Main(string[] args)
    {
        var fileOption = new Option<FileInfo?>(
            name: "--file",
            description: "The file to read and display on the console.");

        // <options>
        var delayOption = new Option<int>(
            name: "--delay",
            description: "Delay between lines, specified as milliseconds per character in a line.",
            getDefaultValue: () => 42);

        var fgcolorOption = new Option<ConsoleColor>(
            name: "--fgcolor",
            description: "Foreground color of text displayed on the console.",
            getDefaultValue: () => ConsoleColor.White);

        var lightModeOption = new Option<bool>(
            name: "--light-mode",
            description: "Background color of text displayed on the console: default is black, light mode is white.");
        // </options>

        // <rootcommand>
        var rootCommand = new RootCommand("Sample app for System.CommandLine");
        //rootCommand.AddOption(fileOption);
        // </rootcommand>

        // <subcommand>
        var readCommand = new Command("read", "Read and display the file.")
            {
                fileOption,
                delayOption,
                fgcolorOption,
                lightModeOption
            };
        rootCommand.AddCommand(readCommand);
        // </subcommand>

        // <sethandler>
        readCommand.SetHandler(async (file, delay, fgcolor, lightMode) =>
            {
                await ReadFile(file!, delay, fgcolor, lightMode);
            },
            fileOption, delayOption, fgcolorOption, lightModeOption);
        // </sethandler>

        return rootCommand.InvokeAsync(args).Result;
    }

    // <handler>
    internal static async Task ReadFile(
            FileInfo file, int delay, ConsoleColor fgColor, bool lightMode)
    {
        Console.BackgroundColor = lightMode ? ConsoleColor.White : ConsoleColor.Black;
        Console.ForegroundColor = fgColor;
        List<string> lines = File.ReadLines(file.FullName).ToList();
        foreach (string line in lines)
        {
            Console.WriteLine(line);
            await Task.Delay(delay * line.Length);
        };
    }
    // </handler>
}
// </all>
