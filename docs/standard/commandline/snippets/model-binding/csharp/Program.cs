using System.CommandLine;

class Program
{
    static void Main(string[] args)
    {
        IntAndString(args);
        Enum(args);
        Arrays(args);
        FileSystemInfoExample(args);
        FileInfoExample(args);
        Uri(args);
        ComplexType.Program.Main(args);
        ParseArgument.Program.Main(args);
        AddValidator.Program.Main(args);
        OnlyTakeExample(args);
    }

    static void IntAndString(string[] args)
    {
        // <intandstring>
        Option<int> delayOption = new("--delay")
        {
            Description = "An option whose argument is parsed as an int."
        };
        Option<string> messageOption = new("--message")
        {
            Description = "An option whose argument is parsed as a string."
        };

        RootCommand rootCommand = new("Parameter binding example")
        {
            delayOption,
            messageOption
        };

        // <lambda>
        rootCommand.SetAction(parseResult =>
        {
            DisplayIntAndString(parseResult.GetValue(delayOption), parseResult.GetValue(messageOption));
        });
        // </lambda>

        rootCommand.Parse(args).Invoke();
        // </intandstring>
        rootCommand.Parse("--delay 42 --message \"Hello world!\"").Invoke();
    }

    // <intandstringaction>
    public static void DisplayIntAndString(int delayOptionValue, string messageOptionValue)
    {
        Console.WriteLine($"--delay = {delayOptionValue}");
        Console.WriteLine($"--message = {messageOptionValue}");
    }
    // </intandstringaction>

    // <enum>
    static void Enum(string[] args)
    {
        // <enum>
        Option<ConsoleColor> colorOption = new("--color");
        RootCommand rootCommand = new("Enum binding example") { colorOption };

        rootCommand.SetAction(parseResult => Console.WriteLine(parseResult.GetValue(colorOption)));

        rootCommand.Parse(args).Invoke();
        // </enum>
        rootCommand.Parse("--color red").Invoke();
        rootCommand.Parse("--color RED").Invoke();
    }

    static void Arrays(string[] args)
    {
        // <arrays>
        Option<string[]> itemsOption = new("--items")
        {
            AllowMultipleArgumentsPerToken = true
        };

        RootCommand command = new("Array binding example") { itemsOption };

        command.SetAction(parseResult =>
        {
            foreach (string item in parseResult.GetValue(itemsOption))
            {
                Console.WriteLine(item);
            }
        });

        command.Parse(args).Invoke();
        // </arrays>
        command.Parse("--items one --items two --items three").Invoke();
        command.Parse("--items one two three").Invoke();
    }

    static void FileSystemInfoExample(string[] args)
    {
        // <filesysteminfo>
        Option<FileSystemInfo> fileOrDirectoryOption = new("--file-or-directory");
        RootCommand command = new() { fileOrDirectoryOption };

        command.SetAction((parseResult) =>
        {
            switch (parseResult.GetValue(fileOrDirectoryOption))
            {
                case FileInfo file:
                    Console.WriteLine($"File name: {file.FullName}");
                    break;
                case DirectoryInfo directory:
                    Console.WriteLine($"Directory name: {directory.FullName}");
                    break;
                default:
                    Console.WriteLine("Not a valid file or directory name.");
                    break;
            }
        });

        command.Parse(args).Invoke();
        // </filesysteminfo>
        command.Parse("--file-or-directory scl.runtimeconfig.json").Invoke();
        command.Parse("--file-or-directory ../net8.0").Invoke();
        command.Parse("--file-or-directory newfile.json").Invoke();
    }

    static void FileInfoExample(string[] args)
    {
        // <fileinfo>
        Option<FileInfo> fileOption = new("--file");
        RootCommand command = new() { fileOption };

        command.SetAction((paseResult) =>
        {
            if (paseResult.GetValue(fileOption) is FileInfo file)
            {
                Console.WriteLine($"File name: {file?.FullName}");
            }
            else
            {
                Console.WriteLine("Not a valid file name.");
            }
        });

        command.Parse(args).Invoke();
        // </fileinfo>
        command.Parse("--file scl.runtimeconfig.json").Invoke();
        command.Parse("--file newfile.json").Invoke();
    }

    static void Uri(string[] args)
    {
        // <uri>
        Option<Uri> endpointOption = new("--endpoint");
        RootCommand command = new() { endpointOption };

        command.SetAction((parseResult) =>
        {
            Console.WriteLine($"URL: {parseResult.GetValue(endpointOption)?.ToString()}");
        });

        command.Parse(args).Invoke();
        // </uri>
        command.Parse("--endpoint https://contoso.com").Invoke();
    }

    static void OnlyTakeExample(string[] args)
    {
        // <onlytake>
        Argument<string[]> arg1 = new("arg1")
        {
            CustomParser = result =>
            {
                result.OnlyTake(2); // System.CommandLine.Parsing.ArgumentResult.OnlyTake
                return result.Tokens.Select(t => t.Value).ToArray();
            }
        };
        Argument<string[]> arg2 = new("arg2");

        RootCommand rootCommand = new() { arg1, arg2 };
        rootCommand.SetAction(parseResult =>
        {
            Console.WriteLine($"arg1 = {String.Concat(parseResult.GetValue(arg1))}");
            Console.WriteLine($"arg2 = {String.Concat(parseResult.GetValue(arg2))}");
        });
        rootCommand.Parse(args).Invoke();
        // </onlytake>
        rootCommand.Parse("1 2 3 4 5").Invoke();
    }
}
