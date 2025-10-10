namespace ComplexType;

// <all>
using System.CommandLine;

public class Program
{
    internal static void Main(string[] args)
    {
        Option<FileInfo?> fileOption = new("--file")
        {
            Description = "An option whose argument is parsed as a FileInfo",
            DefaultValueFactory = result => new FileInfo("scl.runtimeconfig.json"),
        };
        Option<string> firstNameOption = new("--first-name")
        {
            Description = "Person.FirstName"
        };
        Option<string> lastNameOption = new("--last-name")
        {
            Description = "Person.LastName"
        };

        RootCommand rootCommand = new()
        {
            fileOption,
            firstNameOption,
            lastNameOption
        };

        // <setaction>
        rootCommand.SetAction(parseResult =>
        {
            Person person = new()
            {
                FirstName = parseResult.GetValue(firstNameOption),
                LastName = parseResult.GetValue(lastNameOption)
            };
            DoRootCommand(parseResult.GetValue(fileOption), person);
        });
        // </setaction>

        rootCommand.Parse(args).Invoke();
    }

    public static void DoRootCommand(FileInfo? aFile, Person aPerson)
    {
        Console.WriteLine($"File = {aFile?.FullName}");
        Console.WriteLine($"Person = {aPerson?.FirstName} {aPerson?.LastName}");
    }

    // <persontype>
    public class Person
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
    // </persontype>
}
// </all>
