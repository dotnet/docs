// <all>
using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Help;
using System.CommandLine.Invocation;
using System.CommandLine.Parsing;
using Spectre.Console;

class Program
{
    static async Task Main(string[] args)
    {
        await Original(args);
        await First2Columns(args);
        await DescriptionSection(args);
    }

    static async Task Original(string[] args)
    {
        // <original>
        var fileOption = new Option<FileInfo>(
            "--file",
            description: "The file to print out.",
            getDefaultValue: () => new FileInfo("scl.runtimeconfig.json"));
        var lightModeOption = new Option<bool> (
            "--light-mode",
            description: "Determines whether the background color will be black or white");
        var foregroundColorOption = new Option<ConsoleColor>(
            "--color",
            description: "Specifies the foreground color of console output",
            getDefaultValue: () => ConsoleColor.White);

        var rootCommand = new RootCommand("Read a file")
        {
            fileOption,
            lightModeOption,
            foregroundColorOption
        };

        rootCommand.SetHandler((file, lightMode, color) =>
            {
                Console.BackgroundColor = lightMode ? ConsoleColor.White: ConsoleColor.Black;
                Console.ForegroundColor = color;
                Console.WriteLine($"--file = {file?.FullName}");
                Console.WriteLine($"File contents:\n{file?.OpenText().ReadToEnd()}");
            },
            fileOption,
            lightModeOption,
            foregroundColorOption);

        await rootCommand.InvokeAsync(args);
        // </original>
        Console.WriteLine("Default help");
        await rootCommand.InvokeAsync("-h");
    }

    static async Task First2Columns(string[] args)
    {
        var fileOption = new Option<FileInfo>(
            "--file",
            description: "The file to print out.",
            getDefaultValue: () => new FileInfo("scl.runtimeconfig.json"));
        var lightModeOption = new Option<bool>(
            "--light-mode",
            description: "Determines whether the background color will be black or white",
            getDefaultValue: () => true);
        var foregroundColorOption = new Option<ConsoleColor>(
            "--color",
            description: "Specifies the foreground color of console output",
            getDefaultValue: () => ConsoleColor.White);

        var rootCommand = new RootCommand("Read a file")
        {
            fileOption,
            lightModeOption,
            foregroundColorOption
        };

        rootCommand.SetHandler((file, lightMode, color) =>
            {
                Console.BackgroundColor = lightMode ? ConsoleColor.Black : ConsoleColor.White;
                Console.ForegroundColor = color;
                Console.WriteLine($"--file = {file?.FullName}");
                Console.WriteLine($"File contents:\n{file?.OpenText().ReadToEnd()}");
            },
            fileOption,
            lightModeOption,
            foregroundColorOption);

        // <first2columns>
        fileOption.ArgumentHelpName = "FILEPATH";

        var parser = new CommandLineBuilder(rootCommand)
                .UseDefaults()
                .UseHelp(ctx =>
                {
                    ctx.HelpBuilder.CustomizeSymbol(foregroundColorOption,
                        firstColumnText: "--color <Black, White, Red, or Yellow>",
                        secondColumnText: "Specifies the foreground color. " +
                            "Choose a color that provides enough contrast " +
                            "with the background color. " + 
                            "For example, a yellow foreground can't be read " +
                            "against a light mode background.");
                })
                .Build();

        parser.Invoke(args);
        // </first2columns>
        Console.WriteLine("First two columns customized.");
        await parser.InvokeAsync("-h");
    }

    static async Task DescriptionSection(string[] args)
    {
        var fileOption = new Option<FileInfo>(
            "--file",
            description: "The file to print out.",
            getDefaultValue: () => new FileInfo("scl.runtimeconfig.json"));
        var lightModeOption = new Option<bool>(
            "--light-mode",
            description: "Determines whether the background color will be black or white",
            getDefaultValue: () => true);
        var foregroundColorOption = new Option<ConsoleColor>(
            "--color",
            description: "Specifies the foreground color of console output",
            getDefaultValue: () => ConsoleColor.White);

        var rootCommand = new RootCommand("Read a file")
        {
            fileOption,
            lightModeOption,
            foregroundColorOption
        };

        rootCommand.SetHandler((file, lightMode, color) =>
            {
                Console.BackgroundColor = lightMode ? ConsoleColor.Black : ConsoleColor.White;
                Console.ForegroundColor = color;
                Console.WriteLine($"--file = {file?.FullName}");
                Console.WriteLine($"File contents:\n{file?.OpenText().ReadToEnd()}");
            },
            fileOption,
            lightModeOption,
            foregroundColorOption);

        // <description>
        fileOption.ArgumentHelpName = "FILEPATH";

        var parser = new CommandLineBuilder(rootCommand)
                .UseDefaults()
                .UseHelp(ctx =>
                {
                    ctx.HelpBuilder.CustomizeSymbol(foregroundColorOption,
                        firstColumnText: "--color <Black, White, Red, or Yellow>",
                        secondColumnText: "Specifies the foreground color. " +
                            "Choose a color that provides enough contrast " +
                            "with the background color. " +
                            "For example, a yellow foreground can't be read " +
                            "against a light mode background.");
                    ctx.HelpBuilder.CustomizeLayout(
                        _ =>
                            HelpBuilder.Default
                                .GetLayout()
                                .Skip(1) // Skip the default command description section.
                                .Prepend(
                                    _ => Spectre.Console.AnsiConsole.Write(
                                        new FigletText(rootCommand.Description!))
                        ));
                })
                .Build();

        await parser.InvokeAsync(args);
        // </description>
        Console.WriteLine("Description section customized");
        await parser.InvokeAsync("-h");
    }
}
// </all>
