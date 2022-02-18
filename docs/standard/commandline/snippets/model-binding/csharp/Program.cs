using System.CommandLine;

class Program
{
    static async Task Main(string[] args)
    {
        await IntAndString(args);
        await Enum(args);
        await ArraysAndLists(args);
        await FileInfo(args);
        await Uri(args);
        await ComplexType.Program.Main(args);
        await ParseArgument.Program.Main(args);
        await AddValidator.Program.Main(args);
        await OnlyTake(args);
    }

    static async Task IntAndString(string[] args)
    {
        // <intandstring>
        var delayOption = new Option<int>
            ("--delay", "An option whose argument is parsed as an int.");
        var messageOption = new Option<string>
            ("--message", "An option whose argument is parsed as a string.");

        var rootCommand = new RootCommand("Model binding example");
        rootCommand.Add(delayOption);
        rootCommand.Add(messageOption);

        rootCommand.SetHandler(
            // <lambda>
            (int delayOptionValue, string messageOptionValue) =>
            {
                DisplayIntAndString(delayOptionValue, messageOptionValue);
            },
            // </lambda>
            // <services>
            delayOption, messageOption);
            // </services>

        await rootCommand.InvokeAsync(args);
        // </intandstring>
        await rootCommand.InvokeAsync("--delay 42 --message \"Hello world!\"");
    }

    // <intandstringhandler>
    public static void DisplayIntAndString(int delayOptionValue, string messageOptionValue)
    {
        Console.WriteLine($"--delay = {delayOptionValue}");
        Console.WriteLine($"--message = {messageOptionValue}");
    }
    // </intandstringhandler>

    // <enum>
    static async Task Enum(string[] args)
    {
        // <enum>
        var colorOption = new Option<ConsoleColor>("--color");
        
        var rootCommand = new RootCommand("Enum binding example");
        rootCommand.Add(colorOption);

        rootCommand.SetHandler((ConsoleColor colorOptionValue) =>
            { Console.WriteLine(colorOptionValue); },
            colorOption);

        await rootCommand.InvokeAsync(args);
        // </enum>
        await rootCommand.InvokeAsync("--color red");
        await rootCommand.InvokeAsync("--color RED");
    }
    static async Task ArraysAndLists(string[] args)
    {
        // <ienumerable>
        var itemsOption = new Option<IEnumerable<string>>("--items")
            { AllowMultipleArgumentsPerToken = true };

        var command = new RootCommand("IEnumerable binding example");
        command.Add(itemsOption);

        command.SetHandler(
            (IEnumerable<string> items) =>
            {
                Console.WriteLine(items.GetType());

                foreach (var item in items)
                {
                    Console.WriteLine(item);
                }
            }, itemsOption);

        await command.InvokeAsync(args);
        // </ienumerable>
        await command.InvokeAsync("--items one --items two --items three");
        await command.InvokeAsync("--items one two three");
    }
    static async Task FileInfo(string[] args)
    {
        // <fileinfo>
        var fileOption = new Option<FileInfo>("--file");

        var command = new RootCommand();
        command.Add(fileOption);

        command.SetHandler(
            (FileInfo? file) =>
            {
                Console.WriteLine($"Type: {file?.GetType()}");
                Console.WriteLine($"Name: {file?.FullName}");
            }, fileOption);

        await command.InvokeAsync(args);
        // </fileinfo>
        await command.InvokeAsync("--file scl.runtimeconfig.json");
    }

    static async Task Uri(string[] args)
    {
        // <uri>
        var endpointOption = new Option<Uri>("--endpoint");

        var command = new RootCommand();
        command.Add(endpointOption);

        command.SetHandler(
            (Uri? uri) =>
            {
                Console.WriteLine($"Type: {uri?.GetType()}");
                Console.WriteLine($"URL: {uri?.ToString()}");
            }, endpointOption);

        await command.InvokeAsync(args);
        // </uri>
        await command.InvokeAsync("--endpoint https://contoso.com");
    }

    static async Task OnlyTake(string[] args)
    {
        // <onlytake>
        var rootCommand = new RootCommand
        {
            new Argument<string[]>(name: "arg1", parse: result =>
            {
                result.OnlyTake(2);
                return result.Tokens.Select(t => t.Value).ToArray();
            }),
            new Argument<string[]>("arg2")
        };
        rootCommand.SetHandler(
            (string[] arg1, string[] arg2) =>
            {
                Console.WriteLine($"arg1 = {String.Concat(arg1)}");
                Console.WriteLine($"arg2 = {String.Concat(arg2)}");
            },
            rootCommand.Arguments[0], rootCommand.Arguments[1]);
        await rootCommand.InvokeAsync(args);
        // </onlytake>
        await rootCommand.InvokeAsync("1 2 3 4 5");
    }
}
