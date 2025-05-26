// <all>
using System.CommandLine;
using System.CommandLine.Help;
using Spectre.Console;

class Program
{
    static void Main(string[] args)
    {
        Original(args);
        First2Columns(args);
        DescriptionSection(args);
    }

    static void Original(string[] args)
    {
        // <original>
        Option<FileInfo> fileOption = new("--file")
        {
            Description = "The file to print out.",
        };
        Option<bool> lightModeOption = new("--light-mode")
        {
            Description = "Determines whether the background color will be black or white"
        };
        Option<ConsoleColor> foregroundColorOption = new("--color")
        {
            Description = "Specifies the foreground color of console output",
            DefaultValueFactory = _ => ConsoleColor.White
        };

        RootCommand rootCommand = new("Read a file")
        {
            fileOption,
            lightModeOption,
            foregroundColorOption
        };

        rootCommand.SetAction(parseResult =>
        {
            if (parseResult.GetValue(fileOption) is FileInfo file)
            {
                Console.BackgroundColor = parseResult.GetValue(lightModeOption) ? ConsoleColor.White : ConsoleColor.Black;
                Console.ForegroundColor = parseResult.GetValue(foregroundColorOption);

                Console.WriteLine($"--file = {file.FullName}");
                Console.WriteLine($"File contents:\n{file.OpenText().ReadToEnd()}");
            }
        });

        rootCommand.Parse(args).Invoke();
        // </original>
        Console.WriteLine("Default help");
        rootCommand.Parse("-h").Invoke();
    }

    static void First2Columns(string[] args)
    {
        Option<FileInfo> fileOption = new("--file")
        {
            Description = "The file to print out.",
        };
        Option<bool> lightModeOption = new("--light-mode")
        {
            Description = "Determines whether the background color will be black or white"
        };
        Option<ConsoleColor> foregroundColorOption = new("--color")
        {
            Description = "Specifies the foreground color of console output",
            DefaultValueFactory = _ => ConsoleColor.White
        };

        RootCommand rootCommand = new("Read a file")
        {
            fileOption,
            lightModeOption,
            foregroundColorOption
        };

        rootCommand.SetAction(parseResult =>
        {
            if (parseResult.GetValue(fileOption) is FileInfo file)
            {
                Console.BackgroundColor = parseResult.GetValue(lightModeOption) ? ConsoleColor.White : ConsoleColor.Black;
                Console.ForegroundColor = parseResult.GetValue(foregroundColorOption);

                Console.WriteLine($"--file = {file.FullName}");
                Console.WriteLine($"File contents:\n{file.OpenText().ReadToEnd()}");
            }
        });

        // <first2columns>
        fileOption.HelpName = "FILEPATH";

        HelpBuilder helpBuilder = new();
        helpBuilder.CustomizeSymbol(foregroundColorOption,
            firstColumnText: "--color <Black, White, Red, or Yellow>",
            secondColumnText: "Specifies the foreground color. " +
                "Choose a color that provides enough contrast " +
                "with the background color. " +
                "For example, a yellow foreground can't be read " +
                "against a light mode background.");

        for (int i = 0; i < rootCommand.Options.Count; i++)
        {
            // RootCommand has a default HelpOption, we need to replace it.
            if (rootCommand.Options[i] is HelpOption defaultHelpOption)
            {
                rootCommand.Options[i] = new HelpOption
                {
                    Action = new HelpAction
                    {
                        Builder = helpBuilder
                    }
                };
                break;
            }
        }

        rootCommand.Parse(args).Invoke();
        // </first2columns>
        Console.WriteLine("First two columns customized.");
        rootCommand.Parse("-h").Invoke();
    }

    static void DescriptionSection(string[] args)
    {
        Option<FileInfo> fileOption = new("--file")
        {
            Description = "The file to print out.",
        };
        Option<bool> lightModeOption = new("--light-mode")
        {
            Description = "Determines whether the background color will be black or white"
        };
        Option<ConsoleColor> foregroundColorOption = new("--color")
        {
            Description = "Specifies the foreground color of console output",
            DefaultValueFactory = _ => ConsoleColor.White
        };

        RootCommand rootCommand = new("Read a file")
        {
            fileOption,
            lightModeOption,
            foregroundColorOption
        };

        rootCommand.SetAction(parseResult =>
        {
            if (parseResult.GetValue(fileOption) is FileInfo file)
            {
                Console.BackgroundColor = parseResult.GetValue(lightModeOption) ? ConsoleColor.White : ConsoleColor.Black;
                Console.ForegroundColor = parseResult.GetValue(foregroundColorOption);

                Console.WriteLine($"--file = {file.FullName}");
                Console.WriteLine($"File contents:\n{file.OpenText().ReadToEnd()}");
            }
        });

        // <description>
        fileOption.HelpName = "FILEPATH";

        HelpBuilder helpBuilder = new();
        helpBuilder.CustomizeSymbol(foregroundColorOption,
            firstColumnText: "--color <Black, White, Red, or Yellow>",
            secondColumnText: "Specifies the foreground color. " +
                "Choose a color that provides enough contrast " +
                "with the background color. " +
                "For example, a yellow foreground can't be read " +
                "against a light mode background.");

        helpBuilder.CustomizeLayout(_ =>
            HelpBuilder.Default
                .GetLayout()
                .Skip(1) // Skip the default command description section.
                .Prepend(_ =>
                {
                    Spectre.Console.AnsiConsole.Write(new FigletText(rootCommand.Description!));
                    return true;
                })
        );

        for (int i = 0; i < rootCommand.Options.Count; i++)
        {
            // RootCommand has a default HelpOption, we need to replace it.
            if (rootCommand.Options[i] is HelpOption defaultHelpOption)
            {
                rootCommand.Options[i] = new HelpOption
                {
                    Action = new HelpAction
                    {
                        Builder = helpBuilder
                    }
                };
                break;
            }
        }

        rootCommand.Parse(args).Invoke();
        // </description>
        Console.WriteLine("Description section customized");
        rootCommand.Parse("-h").Invoke();
    }
}
// </all>
