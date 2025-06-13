namespace AddValidator;

// <all>
using System.CommandLine;

class Program
{
    internal static void Main(string[] args)
    {
        // <delayOption>
        Option<int> delayOption = new("--delay");
        delayOption.Validators.Add(result =>
        {
            if (result.GetValue(delayOption) < 1)
            {
                result.AddError("Must be greater than 0");
            }
        });
        // </delayoption>

        RootCommand rootCommand = new() { delayOption };
        rootCommand.SetAction((parseResult) =>
        {
            Console.WriteLine($"--delay = {parseResult.GetValue(delayOption)}");
        });

        rootCommand.Parse(args).Invoke();
    }
}
// </all>
