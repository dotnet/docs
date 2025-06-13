// <all>
using System.CommandLine;
using System.CommandLine.Help;
using System.CommandLine.Invocation;
using Spectre.Console;

class Program
{
    static void Main(string[] args)
    {
        Original(args);
        AllowedValues(args);
        Sections(args);
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
        rootCommand.Parse("-h").Invoke();
        // </original>
    }

    static void AllowedValues(string[] args)
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
            DefaultValueFactory = _ => ConsoleColor.White,
        };

        // <allowedvalues>
        fileOption.HelpName = "FILEPATH";
        foregroundColorOption.AcceptOnlyFromAmong(
            ConsoleColor.Black.ToString(),
            ConsoleColor.White.ToString(),
            ConsoleColor.Red.ToString(),
            ConsoleColor.Yellow.ToString()
        );
        // </allowedvalues>

        RootCommand rootCommand = new("Read a file")
        {
            fileOption,
            lightModeOption,
            foregroundColorOption
        };
        rootCommand.Parse("-h").Invoke();
    }

    static void Sections(string[] args)
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
            DefaultValueFactory = _ => ConsoleColor.White,
        };

        fileOption.HelpName = "FILEPATH";
        foregroundColorOption.AcceptOnlyFromAmong(
            ConsoleColor.Black.ToString(),
            ConsoleColor.White.ToString(),
            ConsoleColor.Red.ToString(),
            ConsoleColor.Yellow.ToString()
        );

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

        // <setcustomaction>
        for (int i = 0; i < rootCommand.Options.Count; i++)
        {
            // RootCommand has a default HelpOption, we need to update its Action.
            if (rootCommand.Options[i] is HelpOption defaultHelpOption)
            {
                defaultHelpOption.Action = new CustomHelpAction((HelpAction)defaultHelpOption.Action!);
                break;
            }
        }
        // </setcustomaction>

        rootCommand.Parse("-h").Invoke();
    }

    // <customaction>
    internal class CustomHelpAction : SynchronousCommandLineAction
    {
        private readonly HelpAction _defaultHelp;

        public CustomHelpAction(HelpAction action) => _defaultHelp = action;

        public override int Invoke(ParseResult parseResult)
        {
            Spectre.Console.AnsiConsole.Write(new FigletText(parseResult.RootCommandResult.Command.Description!));

            int result = _defaultHelp.Invoke(parseResult);

            Spectre.Console.AnsiConsole.WriteLine("Sample usage: --file input.txt");

            return result;

        }
    }
    // </customaction>
}
// </all>
