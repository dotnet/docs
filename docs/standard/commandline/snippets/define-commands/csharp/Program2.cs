using System.CommandLine;

class Program2
{
    static async Task Main(string[] args)
    {
        await DefineCommands(args);
        await DefineOptions(args);
        await RecursiveOption(args);
        await RequiredOption(args);
        await HiddenOption(args);
        await FromAmong(args);
        await DefineArguments(args);
    }

    static async Task DefineArguments(string[] args)
    {
        // <definearguments>
        Argument<int> delayArgument = new(name: "delay")
        {
            Description = "An argument that is parsed as an int.",
            DefaultValueFactory = parseResult => 42
        };
        Argument<string> messageArgument = new("message")
        {
            Description = "An argument that is parsed as a string."
        };

        RootCommand rootCommand = new()
        {
            delayArgument,
            messageArgument
        };

        rootCommand.SetAction(parseResult =>
        {
            Console.WriteLine($"<delay> argument = {parseResult.GetValue(delayArgument)}");
            Console.WriteLine($"<message> argument = {parseResult.GetValue(messageArgument)}");
        });

        await rootCommand.Parse(args).InvokeAsync();
        // </definearguments>
        Console.WriteLine("Sample command line.");
        await rootCommand.Parse("21 \"Hello world!\"").InvokeAsync();
    }

    static Task DefineCommands(string[] args)
    {
        // <definecommands>
        RootCommand rootCommand = new();
        Command sub1Command = new("sub1", "First-level subcommand");
        rootCommand.Add(sub1Command);
        Command sub1aCommand = new("sub1a", "Second level subcommand");
        sub1Command.Add(sub1aCommand);
        // </definecommands>

        sub1aCommand.SetAction(parseResult =>
        {
            Console.WriteLine(sub1aCommand.Description);
        });

        return rootCommand.Parse(args).InvokeAsync();
    }

    static async Task DefineOptions(string[] args)
    {
        // <defineoptions>
        Option<int> delayOption = new("--delay")
        {
            Description = "An option whose argument is parsed as an int.",
            DefaultValueFactory = parseResult => 42
        };
        Option<string> messageOption = new("--message")
        {
            Description = "An option whose argument is parsed as a string."
        };

        RootCommand rootCommand = new();
        rootCommand.Add(delayOption);
        rootCommand.Add(messageOption);

        rootCommand.SetAction(parseResult =>
        {
            Console.WriteLine($"--delay = {parseResult.GetValue(delayOption)}");
            Console.WriteLine($"--message = {parseResult.GetValue(messageOption)}");
        });
        // </defineoptions>

        await rootCommand.Parse(args).InvokeAsync();
        Console.WriteLine("Sample command line.");
        await rootCommand.Parse("--delay 21 --message \"Hello world!\"").InvokeAsync();
    }

    static async Task RecursiveOption(string[] args)
    {
        // <definerecursive>
        Option<int> delayOption = new("--delay")
        {
            Description = "An option whose argument is parsed as an int.",
            Recursive = true
        };
        Option<string> messageOption = new("--message")
        {
            Description = "An option whose argument is parsed as a string."
        };

        RootCommand rootCommand = new();
        rootCommand.Options.Add(delayOption);
        rootCommand.Options.Add(messageOption);

        Command subCommand1 = new("sub1", "First level subcommand");
        rootCommand.Add(subCommand1);

        Command subCommand1a = new("sub1a", "Second level subcommand");
        subCommand1.Add(subCommand1a);

        subCommand1a.SetAction(parseResult =>
        {
            Console.WriteLine($"--delay = {parseResult.GetValue(delayOption)}");
        });

        await rootCommand.Parse(args).InvokeAsync();
        // </definerecursive>

        Console.WriteLine("Request help for second level subcommand.");
        await rootCommand.Parse("sub1 sub1a -h").InvokeAsync();
        Console.WriteLine("Global option in second level subcommand.");
        await rootCommand.Parse("sub1 sub1a --delay 42").InvokeAsync();
    }

    static async Task RequiredOption(string[] args)
    {
        // <requiredoption>
        Option<Uri> endpointOption = new("--endpoint")
        {
            Required = true
        };
        RootCommand command = new() { endpointOption };
        command.SetAction(parseResult =>
        {
            Uri uri = parseResult.GetValue(endpointOption)!;

            Console.WriteLine(uri.GetType());
            Console.WriteLine(uri.ToString());
        });

        await command.Parse(args).InvokeAsync();
        // </requiredoption>
        Console.WriteLine("Provide required option");
        await command.Parse("--endpoint https://contoso.com").InvokeAsync();
    }

    static async Task HiddenOption(string[] args)
    {
        // <hiddenoption>
        Option<Uri> endpointOption = new("--endpoint")
        {
            Hidden = true
        };
        RootCommand command = new() { endpointOption };

        command.SetAction(parseResult =>
        {
            Uri? uri = parseResult.GetValue(endpointOption);

            Console.WriteLine(uri?.GetType());
            Console.WriteLine(uri?.ToString());
        });

        await command.Parse(args).InvokeAsync();
        // </hiddenoption>
        Console.WriteLine("Request help for hidden option.");
        await command.Parse("-h").InvokeAsync();
        Console.WriteLine("Provide hidden option.");
        await command.Parse("--endpoint https://contoso.com").InvokeAsync();
    }

    static async Task FromAmong(string[] args)
    {
        // <staticlist>
        Option<string> languageOption = new("--language")
        {
            Description = "An option that that must be one of the values of a static list."
        };
        languageOption.AcceptOnlyFromAmong("csharp", "fsharp", "vb");
        // </staticlist>

        RootCommand rootCommand = new("Static list example") { languageOption };
        rootCommand.SetAction(parseResult =>
        {
            Console.WriteLine($"--language = {parseResult.GetValue(languageOption)}");
        });

        await rootCommand.Parse(args).InvokeAsync();
        Console.WriteLine("Request help, provide a valid language, provide an invalid language.");
        await rootCommand.Parse("-h").InvokeAsync();
        await rootCommand.Parse("--language csharp").InvokeAsync();
        await rootCommand.Parse("--language not-a-language").InvokeAsync();
    }
}
