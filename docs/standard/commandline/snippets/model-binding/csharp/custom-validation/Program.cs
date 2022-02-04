// <all>
using System.CommandLine;

class Program
{
    static async Task Main(string[] args)
    {
        // <fileoption>
        var fileOption = new Option<FileInfo?>(
              name: "--file",
              description: "An option whose argument is parsed as a FileInfo",
              isDefault: true,
              parseArgument: result =>
              {
                  if (!result.Tokens.Any())
                  {
                      return new FileInfo("scl.runtimeconfig.json");
                  }

                  var filePath = result.Tokens.Single().Value;

                  if (!File.Exists(filePath))
                  {
                      result.ErrorMessage = "File does not exist";
                      return null;
                  }
                  else
                  {
                      return new FileInfo(filePath);
                  }
              });
        // </fileoption>

        // <personoption>
        var personOption = new Option<Person?>(
              name: "--person",
              description: "An option whose argument is parsed as a Person",
              parseArgument: result =>
              {
                  if (result.Tokens.Count != 2)
                  {
                      result.ErrorMessage = "--person requires two arguments";
                      return null;
                  }
                  return new Person
                  {
                      FirstName = result.Tokens.First().Value,
                      LastName = result.Tokens.Last().Value
                  };
              })
        {
            Arity = ArgumentArity.OneOrMore,
            AllowMultipleArgumentsPerToken = true
        };
        // </personoption>

        var rootCommand = new RootCommand();
        rootCommand.Add(fileOption);
        rootCommand.Add(personOption);

        rootCommand.SetHandler((FileInfo fileOptionValue, Person personOptionValue) =>
        {
            DoRootCommand(fileOptionValue, personOptionValue);
        },
        fileOption, personOption);

        await rootCommand.InvokeAsync("--file scl.runtimeconfig.json --person Nancy Davolio");
    }

    public static void DoRootCommand(FileInfo aFile, Person aPerson)
    {
        Console.WriteLine($"File = {aFile?.FullName}");
        Console.WriteLine($"Person = {aPerson.FirstName} {aPerson.LastName}");
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
