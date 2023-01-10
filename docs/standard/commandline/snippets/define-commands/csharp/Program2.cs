using System.CommandLine;

class Program2
{
    static async Task Main(string[] args)
    {
        await DefineCommands(args);
        await DefineOptions(args);
        await GlobalOption(args);
        await RequiredOption(args);
        await HiddenOption(args);
        await FromAmong(args);
        await DefineArguments(args);
    }

    static async Task DefineArguments(string[] args)
    {
        // <definearguments>
        var delayArgument = new Argument<int>
            (name: "delay",
            description: "An argument that is parsed as an int.",
            getDefaultValue: () => 42);
        var messageArgument = new Argument<string>
            ("message", "An argument that is parsed as a string.");

        var rootCommand = new RootCommand();
        rootCommand.Add(delayArgument);
        rootCommand.Add(messageArgument);

        rootCommand.SetHandler((delayArgumentValue, messageArgumentValue) =>
            {
                Console.WriteLine($"<delay> argument = {delayArgumentValue}");
                Console.WriteLine($"<message> argument = {messageArgumentValue}");
            },
            delayArgument, messageArgument);

        await rootCommand.InvokeAsync(args);
        // </definearguments>
        Console.WriteLine("Sample command line.");
        await rootCommand.InvokeAsync("21 \"Hello world!\"");
    }

    static async Task DefineCommands(string[] args)
    {
        // <definecommands>
        var rootCommand = new RootCommand();
        var sub1Command = new Command("sub1", "First-level subcommand");
        rootCommand.Add(sub1Command);
        var sub1aCommand = new Command("sub1a", "Second level subcommand");
        sub1Command.Add(sub1aCommand);
        // </definecommands>

        sub1aCommand.SetHandler(() =>
            {
                Console.WriteLine(sub1aCommand.Description);
            });

        await rootCommand.InvokeAsync(args);
    }

    static async Task DefineOptions(string[] args)
    {
        // <defineoptions>
        var delayOption = new Option<int>
            (name: "--delay",
            description: "An option whose argument is parsed as an int.",
            getDefaultValue: () => 42);
        var messageOption = new Option<string>
            ("--message", "An option whose argument is parsed as a string.");

        var rootCommand = new RootCommand();
        rootCommand.Add(delayOption);
        rootCommand.Add(messageOption);

        rootCommand.SetHandler((delayOptionValue, messageOptionValue) =>
            {
                Console.WriteLine($"--delay = {delayOptionValue}");
                Console.WriteLine($"--message = {messageOptionValue}");
            },
            delayOption, messageOption);
        // </defineoptions>

        await rootCommand.InvokeAsync(args);
        Console.WriteLine("Sample command line.");
        await rootCommand.InvokeAsync("--delay 21 --message \"Hello world!\"");
    }

    static async Task GlobalOption(string[] args)
    {
        // <defineglobal>
        var delayOption = new Option<int>
            ("--delay", "An option whose argument is parsed as an int.");
        var messageOption = new Option<string>
            ("--message", "An option whose argument is parsed as a string.");

        var rootCommand = new RootCommand();
        rootCommand.AddGlobalOption(delayOption);
        rootCommand.Add(messageOption);

        var subCommand1 = new Command("sub1", "First level subcommand");
        rootCommand.Add(subCommand1);

        var subCommand1a = new Command("sub1a", "Second level subcommand");
        subCommand1.Add(subCommand1a);

        subCommand1a.SetHandler((delayOptionValue) =>
            {
                Console.WriteLine($"--delay = {delayOptionValue}");
            },
            delayOption);

        await rootCommand.InvokeAsync(args);
        // </defineglobal>

        Console.WriteLine("Request help for second level subcommand.");
        await rootCommand.InvokeAsync("sub1 sub1a -h");
        Console.WriteLine("Global option in second level subcommand.");
        await rootCommand.InvokeAsync("sub1 sub1a --delay 42");
    }

    static async Task RequiredOption(string[] args)
    {
        // <requiredoption>
        var endpointOption = new Option<Uri>("--endpoint") { IsRequired = true };
        var command = new RootCommand();
        command.Add(endpointOption);

        command.SetHandler((uri) =>
            {
                Console.WriteLine(uri?.GetType());
                Console.WriteLine(uri?.ToString());
            },
            endpointOption);

        await command.InvokeAsync(args);
        // </requiredoption>
        Console.WriteLine("Provide required option");
        await command.InvokeAsync("--endpoint https://contoso.com");
    }

    static async Task HiddenOption(string[] args)
    {
        // <hiddenoption>
        var endpointOption = new Option<Uri>("--endpoint") { IsHidden = true };
        var command = new RootCommand();
        command.Add(endpointOption);

        command.SetHandler((uri) =>
            {
                Console.WriteLine(uri?.GetType());
                Console.WriteLine(uri?.ToString());
            },
            endpointOption);

        await command.InvokeAsync(args);
        // </hiddenoption>
        Console.WriteLine("Request help for hidden option.");
        await command.InvokeAsync("-h");
        Console.WriteLine("Provide hidden option.");
        await command.InvokeAsync("--endpoint https://contoso.com");
    }

    static async Task FromAmong(string[] args)
    {
        // <staticlist>
        var languageOption = new Option<string>(
            "--language",
            "An option that that must be one of the values of a static list.")
                .FromAmong(
                    "csharp",
                    "fsharp",
                    "vb",
                    "pwsh",
                    "sql");
        // </staticlist>

        var rootCommand = new RootCommand("Static list example");
        rootCommand.Add(languageOption);

        rootCommand.SetHandler((languageOptionValue) =>
            {
                Console.WriteLine($"--language = {languageOptionValue}");
            },
            languageOption);

        await rootCommand.InvokeAsync(args);
        Console.WriteLine("Request help, provide a valid language, provide an invalid language.");
        await rootCommand.InvokeAsync("-h");
        await rootCommand.InvokeAsync("--language csharp");
        await rootCommand.InvokeAsync("--language not-a-language");
    }
}
