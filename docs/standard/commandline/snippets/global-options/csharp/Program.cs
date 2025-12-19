using System.CommandLine;
using System.CommandLine.Parsing;

// <verbositylevel>
enum VerbosityLevel
{
    Quiet,
    Minimal,
    Normal,
    Detailed,
    Diagnostic
}
// </verbositylevel>

class Program
{
    static void Main(string[] args)
    {
        // Examples for documentation - not meant to be run together
        // Uncomment the example you want to test
        
        // GlobalOptionExample(args);
        // VerbosityOptionExample(args);
        // VerbosityWithAccessExample(args);
    }

    // <globaloption>
    static void GlobalOptionExample(string[] args)
    {
        // Create a global option that applies to all commands
        Option<bool> verboseOption = new("--verbose", "-v")
        {
            Description = "Show verbose output",
            Recursive = true // This makes it available to all subcommands
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
        // Create verbosity option that accepts full and short names as strings
        Option<string> verbosityOption = new("--verbosity")
        {
            Description = "Set the verbosity level. Allowed values are q[uiet], m[inimal], n[ormal], d[etailed], and diag[nostic].",
            Recursive = true
        };

        verbosityOption.DefaultValueFactory = result =>
        {
            if (result.Tokens.Count == 0)
            {
                return "normal";
            }
            return result.Tokens.Single().Value.ToLowerInvariant();
        };
        
        // Configure validation to handle both short and long forms
        verbosityOption.Validators.Add(result =>
        {
            if (result.Tokens.Count == 0)
            {
                return; // Allow default value
            }

            string value = result.Tokens.Single().Value.ToLowerInvariant();
            var validValues = new[] { "quiet", "q", "minimal", "m", "normal", "n", "detailed", "d", "diagnostic", "diag" };
            
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
            
            // Convert string to enum
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
    // </verbosityoption>

    // <verbosityaccess>
    static void VerbosityWithAccessExample(string[] args)
    {
        // Create main verbosity option that accepts string values
        Option<string> verbosityOption = new("--verbosity")
        {
            Description = "Set the verbosity level. Allowed values are q[uiet], m[inimal], n[ormal], d[etailed], and diag[nostic].",
            Recursive = true
        };

        verbosityOption.DefaultValueFactory = result =>
        {
            if (result.Tokens.Count == 0)
            {
                return "normal";
            }
            return result.Tokens.Single().Value.ToLowerInvariant();
        };

        verbosityOption.Validators.Add(result =>
        {
            if (result.Tokens.Count == 0)
            {
                return;
            }

            string value = result.Tokens.Single().Value.ToLowerInvariant();
            var validValues = new[] { "quiet", "q", "minimal", "m", "normal", "n", "detailed", "d", "diagnostic", "diag" };
            
            if (!validValues.Contains(value))
            {
                result.AddError($"Argument '{value}' not recognized. Must be one of: 'q[uiet]', 'm[inimal]', 'n[ormal]', 'd[etailed]', 'diag[nostic]'");
            }
        });

        // Create -v and -q shorthand options
        Option<bool> vOption = new("-v")
        {
            Description = "Enable diagnostic verbosity (shorthand for --verbosity diagnostic)",
            Recursive = true
        };
        
        Option<bool> qOption = new("-q")
        {
            Description = "Enable quiet mode (shorthand for --verbosity quiet)",
            Recursive = true
        };

        RootCommand rootCommand = new("Sample app with verbosity options");
        rootCommand.Options.Add(verbosityOption);
        rootCommand.Options.Add(vOption);
        rootCommand.Options.Add(qOption);

        Command buildCommand = new("build", "Build the project");
        rootCommand.Subcommands.Add(buildCommand);

        buildCommand.SetAction(parseResult =>
        {
            // Determine effective verbosity level
            string verbosityString = "normal";
            
            // Check which option was provided (priority: -q, -v, --verbosity)
            if (parseResult.GetValue(qOption))
            {
                verbosityString = "quiet";
            }
            else if (parseResult.GetValue(vOption))
            {
                verbosityString = "diagnostic";
            }
            else
            {
                verbosityString = parseResult.GetValue(verbosityOption);
            }

            // Convert to enum for easier comparison
            VerbosityLevel verbosity = verbosityString switch
            {
                "quiet" or "q" => VerbosityLevel.Quiet,
                "minimal" or "m" => VerbosityLevel.Minimal,
                "normal" or "n" => VerbosityLevel.Normal,
                "detailed" or "d" => VerbosityLevel.Detailed,
                "diagnostic" or "diag" => VerbosityLevel.Diagnostic,
                _ => VerbosityLevel.Normal
            };

            // Use verbosity level to control output
            WriteOutput(verbosity, VerbosityLevel.Quiet, ""); // Quiet shows nothing
            WriteOutput(verbosity, VerbosityLevel.Minimal, "Building...");
            WriteOutput(verbosity, VerbosityLevel.Normal, "Building project with default settings...");
            WriteOutput(verbosity, VerbosityLevel.Detailed, "Build started at " + DateTime.Now);
            WriteOutput(verbosity, VerbosityLevel.Diagnostic, "Detailed diagnostic information: ...");
        });

        rootCommand.Parse(args).Invoke();
    }

    static void WriteOutput(VerbosityLevel current, VerbosityLevel required, string message)
    {
        if (current >= required && !string.IsNullOrEmpty(message))
        {
            Console.WriteLine(message);
        }
    }
    // </verbosityaccess>
}
