using System.CommandLine;

class Program2
{
    // <verbosityaccess>
    static void VerbosityWithAccessExample(string[] args)
    {
        // Create main verbosity option that accepts string values.
        Option<string> verbosityOption = new("--verbosity")
        {
            Description = "Set the verbosity level. Allowed values are q[uiet], m[inimal], n[ormal], d[etailed], and diag[nostic].",
            Recursive = true,
            DefaultValueFactory = result =>
            {
                if (result.Tokens.Count == 0)
                {
                    return "normal";
                }
                return result.Tokens.Single().Value.ToLowerInvariant();
            }
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

        // Create -v and -q shorthand options.
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
            // Determine effective verbosity level.
            string verbosityString = "normal";

            // Check which option was provided.
            // Priority: -q overrides all, then -v, then --verbosity (or default if none specified).
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
                verbosityString = parseResult.GetValue(verbosityOption) ?? "normal";
            }

            // Convert to enum for easier comparison/
            VerbosityLevel verbosity = verbosityString switch
            {
                "quiet" or "q" => VerbosityLevel.Quiet,
                "minimal" or "m" => VerbosityLevel.Minimal,
                "normal" or "n" => VerbosityLevel.Normal,
                "detailed" or "d" => VerbosityLevel.Detailed,
                "diagnostic" or "diag" => VerbosityLevel.Diagnostic,
                _ => VerbosityLevel.Normal
            };

            // Use verbosity level to control output.
            WriteOutput(verbosity, VerbosityLevel.Quiet, "");
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
    enum VerbosityLevel
    {
        Quiet,
        Minimal,
        Normal,
        Detailed,
        Diagnostic
    }
    // </verbosityaccess>
}
