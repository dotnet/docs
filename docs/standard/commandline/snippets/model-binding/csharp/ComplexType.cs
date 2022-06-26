namespace ComplexType;

// <all>
using System.CommandLine;
using System.CommandLine.Binding;

public class Program
{
    internal static async Task Main(string[] args)
    {
        var fileOption = new Option<FileInfo?>(
              name: "--file",
              description: "An option whose argument is parsed as a FileInfo",
              getDefaultValue: () => new FileInfo("scl.runtimeconfig.json"));

        var firstNameOption = new Option<string>(
              name: "--first-name",
              description: "Person.FirstName");

        var lastNameOption = new Option<string>(
              name: "--last-name",
              description: "Person.LastName");

        var rootCommand = new RootCommand();
        rootCommand.Add(fileOption);
        rootCommand.Add(firstNameOption);
        rootCommand.Add(lastNameOption);

        // <sethandler>
        rootCommand.SetHandler((fileOptionValue, person) =>
            {
                DoRootCommand(fileOptionValue, person);
            },
            fileOption, new PersonBinder(firstNameOption, lastNameOption));
        // </sethandler>

        await rootCommand.InvokeAsync(args);
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

    // <personbinder>
    public class PersonBinder : BinderBase<Person>
    {
        private readonly Option<string> _firstNameOption;
        private readonly Option<string> _lastNameOption;

        public PersonBinder(Option<string> firstNameOption, Option<string> lastNameOption)
        {
            _firstNameOption = firstNameOption;
            _lastNameOption = lastNameOption;
        }

        protected override Person GetBoundValue(BindingContext bindingContext) =>
            new Person
            {
                FirstName = bindingContext.ParseResult.GetValueForOption(_firstNameOption),
                LastName = bindingContext.ParseResult.GetValueForOption(_lastNameOption)
            };
    }
    // </personbinder>
}
// </all>
