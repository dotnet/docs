using System.CommandLine;
using System.CommandLine.Parsing;

class Program
{
    static void Main(string[] args)
    {
        DefineSubcommands(args);
        DefineOptions(args);
        RequiredOption(args);
        DefineArguments(args);
        ParseErrors(args);
        DefineAliases(args);
    }

    static void DefineSubcommands(string[] args)
    {
        // <definesubcommands>
        RootCommand rootCommand = new();

        Command sub1Command = new("sub1", "First-level subcommand");
        rootCommand.Subcommands.Add(sub1Command);

        Command sub1aCommand = new("sub1a", "Second level subcommand");
        sub1Command.Subcommands.Add(sub1aCommand);
        // </definesubcommands>

        // alternative syntax (not shown it the docs for now)
        rootCommand = new()
        {
            new Command("sub1", "First-level subcommand")
            {
                new Command("sub1a", "Second level subcommand")
            }
        };
    }

    static void DefineOptions(string[] args)
    {
        // <defineoptions>
        Option<int> delayOption = new("--delay", "-d")
        {
            Description = "An option whose argument is parsed as an int.",
            DefaultValueFactory = parseResult => 42,
        };
        Option<string> messageOption = new("--message", "-m")
        {
            Description = "An option whose argument is parsed as a string."
        };

        RootCommand rootCommand = new();
        rootCommand.Options.Add(delayOption);
        rootCommand.Options.Add(messageOption);
        // </defineoptions>
    }

    static void RequiredOption(string[] args)
    {
        // <requiredoption>
        Option<FileInfo> fileOption = new("--output")
        {
            Required = true
        };
        // </requiredoption>
    }

    static void DefineArguments(string[] args)
    {
        // <definearguments>
        Argument<int> delayArgument = new("delay")
        {
            Description = "An argument that is parsed as an int.",
            DefaultValueFactory = parseResult => 42
        };
        Argument<string> messageArgument = new("message")
        {
            Description = "An argument that is parsed as a string."
        };

        RootCommand rootCommand = new();
        rootCommand.Arguments.Add(delayArgument);
        rootCommand.Arguments.Add(messageArgument);
        // </definearguments>
    }

    static void ParseErrors(string[] args)
    {
        // <parseerrors>
        Option<string> verbosityOption = new("--verbosity", "-v")
        {
            Description = "Set the verbosity level.",
        };
        verbosityOption.AcceptOnlyFromAmong("quiet", "minimal", "normal", "detailed", "diagnostic");
        RootCommand rootCommand = new() { verbosityOption };

        ParseResult parseResult = rootCommand.Parse(args);
        foreach (ParseError parseError in parseResult.Errors)
        {
            Console.WriteLine(parseError.Message);
        }
        // </parseerrors>
    }

    static void DefineAliases(string[] args)
    {
        // <definealiases>
        Option<bool> helpOption = new("--help", ["-h", "/h", "-?", "/?"]);
        Command command = new("serialize") { helpOption };
        command.Aliases.Add("serialise");
        // </definealiases>
    }
}
