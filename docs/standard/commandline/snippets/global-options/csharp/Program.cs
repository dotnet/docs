using System.CommandLine;

class Program1
{
    static void Main(string[] args)
    {
        GlobalOptionExample(args);
        //VerbosityOptionExample(args);
    }

    // <globaloption>
    static void GlobalOptionExample(string[] args)
    {
        // Create a global option that applies to all commands.
        Option<bool> verboseOption = new("--verbose", "-v")
        {
            Description = "Show verbose output",
            Recursive = true
        };

        RootCommand rootCommand = new("Sample app demonstrating global options");
        rootCommand.Options.Add(verboseOption);

        Command buildCommand = new("build", "Build the project");
        Command testCommand = new("test", "Run tests");

        rootCommand.Subcommands.Add(buildCommand);
        rootCommand.Subcommands.Add(testCommand);

        buildCommand.SetAction(parseResult =>
        {
            bool isVerbose = parseResult.GetValue(verboseOption);
            Console.WriteLine($"Building project... (verbose: {isVerbose})");
        });

        testCommand.SetAction(parseResult =>
        {
            bool isVerbose = parseResult.GetValue(verboseOption);
            Console.WriteLine($"Running tests... (verbose: {isVerbose})");
        });

        rootCommand.Parse(args).Invoke();
    }
    // </globaloption>

    // <verbosityoption>
    static void VerbosityOptionExample(string[] args)
    {
        // Create verbosity option that accepts full and short names as strings.
        // -v without an argument defaults to diagnostic.
        Option<string> verbosityOption = new("--verbosity", "-v")
        {
            Description = "Output verbosity level. Allowed values are q[uiet], m[inimal], n[ormal], d[etailed], and diag[nostic].",
            Recursive = true,
            Arity = System.CommandLine.ArgumentArity.ZeroOrOne,
            DefaultValueFactory = result =>
                {
                    // This is called when the option is NOT specified at all
                    return "normal";
                }
        };

        // Handle both short and long forms.
        verbosityOption.Validators.Add(result =>
        {
            if (result.Tokens.Count == 0)
            {
                return; // Allow default value.
            }

            string value = result.Tokens.Single().Value.ToLowerInvariant();
            string[] validValues = new[] { "quiet", "q", "minimal", "m", "normal", "n", "detailed", "d", "diagnostic", "diag" };

            if (!validValues.Contains(value))
            {
                result.AddError($"Argument '{value}' not recognized. Must be one of: 'q[uiet]', 'm[inimal]', 'n[ormal]', 'd[etailed]', 'diag[nostic]'");
            }
        });

        RootCommand rootCommand = new("Sample app with verbosity");
        rootCommand.Options.Add(verbosityOption);

        Command processCommand = new("process", "Process data");
        rootCommand.Subcommands.Add(processCommand);

        processCommand.SetAction(parseResult =>
        {
            string verbosityString = parseResult.GetValue(verbosityOption);
            
            // If the option was specified without an argument, the value will be null or empty string
            if (string.IsNullOrEmpty(verbosityString))
            {
                // Check if the option was actually specified
                var optionResult = parseResult.GetResult(verbosityOption);
                if (optionResult != null)
                {
                    // Option was specified without argument -> diagnostic
                    verbosityString = "diagnostic";
                }
                else
                {
                    // Option was not specified -> normal (default)
                    verbosityString = "normal";
                }
            }

            // Convert string to enum.
            VerbosityLevel verbosity = verbosityString switch
            {
                "quiet" or "q" => VerbosityLevel.Quiet,
                "minimal" or "m" => VerbosityLevel.Minimal,
                "normal" or "n" => VerbosityLevel.Normal,
                "detailed" or "d" => VerbosityLevel.Detailed,
                "diagnostic" or "diag" => VerbosityLevel.Diagnostic,
                _ => VerbosityLevel.Normal
            };

            Console.WriteLine($"Verbosity level: {verbosity}");
        });

        rootCommand.Parse(args).Invoke();
    }

    enum VerbosityLevel
    {
        Quiet,
        Minimal,
        Normal,
        Detailed,
        Diagnostic
    }
    // </verbosityoption>
}
