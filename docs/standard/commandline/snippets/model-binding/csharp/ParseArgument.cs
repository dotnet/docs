namespace ParseArgument;

// <all>
using System.CommandLine;
using System.Security.AccessControl;

class Program
{
    internal static async Task Main(string[] args)
    {
        // <delayOption>
        var delayOption = new Option<int>(
              name: "--delay",
              description: "An option whose argument is parsed as an int.",
              isDefault: true,
              parseArgument: result =>
              {
                  if (!result.Tokens.Any())
                  {
                      return 42;
                  }

                  if (int.TryParse(result.Tokens.Single().Value, out var delay))
                  {
                      if (delay < 1)
                      {
                          result.ErrorMessage = "Must be greater than 0";
                      }
                      return delay;
                  }
                  else
                  {
                      result.ErrorMessage = "Not an int.";
                      return 0; // Ignored.
                  }
              });
        // </delayoption>

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
        rootCommand.Add(delayOption);
        rootCommand.Add(personOption);

        rootCommand.SetHandler((delayOptionValue, personOptionValue) =>
            {
                Console.WriteLine($"Delay = {delayOptionValue}");
                Console.WriteLine($"Person = {personOptionValue?.FirstName} {personOptionValue?.LastName}");
            },
            delayOption, personOption);

        await rootCommand.InvokeAsync(args);
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
