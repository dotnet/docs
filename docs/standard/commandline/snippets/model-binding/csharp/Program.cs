using System.CommandLine;

class Program
{
    static async Task Main(string[] args)
    {
        await IntAndString(args);
        await Enum(args);
        await ArraysAndLists(args);
        await FileSystemInfoExample(args);
        await FileInfoExample(args);
        await Uri(args);
        await ComplexType.Program.Main(args);
        await ParseArgument.Program.Main(args);
        await AddValidator.Program.Main(args);
        await OnlyTakeExample(args);
    }

    static async Task IntAndString(string[] args)
    {
        // <intandstring>
        var delayOption = new Option<int>
            ("--delay", "An option whose argument is parsed as an int.");
        var messageOption = new Option<string>
            ("--message", "An option whose argument is parsed as a string.");

        var rootCommand = new RootCommand("Parameter binding example");
        rootCommand.Add(delayOption);
        rootCommand.Add(messageOption);

        rootCommand.SetHandler(
            // <lambda>
            (delayOptionValue, messageOptionValue) =>
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

        rootCommand.SetHandler((colorOptionValue) =>
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

        command.SetHandler((items) =>
            {
                Console.WriteLine(items.GetType());

                foreach (string item in items)
                {
                    Console.WriteLine(item);
                }
            },
            itemsOption);

        await command.InvokeAsync(args);
        // </ienumerable>
        await command.InvokeAsync("--items one --items two --items three");
        await command.InvokeAsync("--items one two three");
    }
    static async Task FileSystemInfoExample(string[] args)
    {
        // <filesysteminfo>
        var fileOrDirectoryOption = new Option<FileSystemInfo>("--file-or-directory");

        var command = new RootCommand();
        command.Add(fileOrDirectoryOption);

        command.SetHandler((fileSystemInfo) =>
            {
                switch (fileSystemInfo)
                {
                    case FileInfo file                    :
                        Console.WriteLine($"File name: {file.FullName}");
                        break;
                    case DirectoryInfo directory:
                        Console.WriteLine($"Directory name: {directory.FullName}");
                        break;
                    default:
                        Console.WriteLine("Not a valid file or directory name.");
                        break;
                }
            },
            fileOrDirectoryOption);

        await command.InvokeAsync(args);
        // </filesysteminfo>
        await command.InvokeAsync("--file-or-directory scl.runtimeconfig.json");
        await command.InvokeAsync("--file-or-directory ../net6.0");
        await command.InvokeAsync("--file-or-directory newfile.json");
    }

    static async Task FileInfoExample(string[] args)
    {
        // <fileinfo>
        var fileOption = new Option<FileInfo>("--file");

        var command = new RootCommand();
        command.Add(fileOption);

        command.SetHandler((file) =>
            {
                if (file is not null)
                {
                    Console.WriteLine($"File name: {file?.FullName}");
                }
                else
                {
                    Console.WriteLine("Not a valid file name.");
                }
            },
            fileOption);

        await command.InvokeAsync(args);
        // </fileinfo>
        await command.InvokeAsync("--file scl.runtimeconfig.json");
        await command.InvokeAsync("--file newfile.json");
    }

    static async Task Uri(string[] args)
    {
        // <uri>
        var endpointOption = new Option<Uri>("--endpoint");

        var command = new RootCommand();
        command.Add(endpointOption);

        command.SetHandler((uri) =>
            {
                Console.WriteLine($"URL: {uri?.ToString()}");
            },
            endpointOption);

        await command.InvokeAsync(args);
        // </uri>
        await command.InvokeAsync("--endpoint https://contoso.com");
    }

    static async Task OnlyTakeExample(string[] args)
    {
        // <onlytake>
        var arg1 = new Argument<string[]>(name: "arg1", parse: result =>
        {
            result.OnlyTake(2);//System.CommandLine.Parsing.ArgumentResult.OnlyTake
            return result.Tokens.Select(t => t.Value).ToArray();
        });
        var arg2 = new Argument<string[]>("arg2");

        var rootCommand = new RootCommand
        {
            arg1, arg2
        };
        rootCommand.SetHandler((arg1Value, arg2Value) =>
            {
                Console.WriteLine($"arg1 = {String.Concat(arg1Value)}");
                Console.WriteLine($"arg2 = {String.Concat(arg2Value)}");
            },
            arg1, arg2);
        await rootCommand.InvokeAsync(args);
        // </onlytake>
        await rootCommand.InvokeAsync("1 2 3 4 5");
    }
}
