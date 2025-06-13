namespace ParseArgument;

// <all>
using System.CommandLine;

class Program
{
    internal static void Main(string[] args)
    {
        // <delayOption>
        Option<int> delayOption = new("--delay")
        {
            Description = "An option whose argument is parsed as an int.",
            CustomParser = result =>
            {
                if (!result.Tokens.Any())
                {
                    return 42;
                }

                if (int.TryParse(result.Tokens.Single().Value, out var delay))
                {
                    if (delay < 1)
                    {
                        result.AddError("Must be greater than 0");
                    }
                    return delay;
                }
                else
                {
                    result.AddError("Not an int.");
                    return 0; // Ignored.
                }
            }
        };
        // </delayoption>

        // <personoption>
        Option<Person?> personOption = new("--person")
        {
            Description = "An option whose argument is parsed as a Person",
            CustomParser = result =>
            {
                if (result.Tokens.Count != 2)
                {
                    result.AddError("--person requires two arguments");
                    return null;
                }
                return new Person
                {
                    FirstName = result.Tokens.First().Value,
                    LastName = result.Tokens.Last().Value
                };
            }
        };
        // </personoption>

        RootCommand rootCommand = new() { delayOption, personOption };

        rootCommand.SetAction((parseResult) =>
        {
            Console.WriteLine($"Delay = {parseResult.GetValue(delayOption)}");
            Person? person = parseResult.GetValue(personOption);
            Console.WriteLine($"Person = {person?.FirstName} {person?.LastName}");
        });

        rootCommand.Parse(args).Invoke();
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
