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
            Arity = ArgumentArity.ZeroOrOne,
            DefaultValueFactory = result =>
                {
                    // This runs only when the option isn't specified at all.
                    // If the option is specified without a value (for example, `-v`),
                    // DefaultValueFactory isn't called and the value is an empty string,
                    // which is handled later when mapping to "diagnostic".
                    return "normal";
                }
        };

        // Add -q as a separate option for quiet verbosity.
        Option<bool> quietOption = new("-q")
        {
            Description = "Set verbosity to quiet (shorthand for --verbosity quiet).",
            Recursive = true
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
        rootCommand.Options.Add(quietOption);

        Command processCommand = new("build", "Build the project");
        rootCommand.Subcommands.Add(processCommand);

        processCommand.SetAction(parseResult =>
        {
            string verbosityString;

            // Check if -q was specified.
            if (parseResult.GetValue(quietOption))
            {
                verbosityString = "quiet";
            }
            else
            {
                verbosityString = parseResult.GetValue(verbosityOption);

                // If the option was specified without an argument,
                // the value will be empty string.
                // Set it to diagnostic as per design guidance.
                if (string.IsNullOrEmpty(verbosityString))
                {
                    verbosityString = "diagnostic";
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
