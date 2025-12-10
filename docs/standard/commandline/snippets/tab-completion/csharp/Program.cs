// <all>
using System.CommandLine;
using System.CommandLine.Completions;

var rootCommand = new RootCommand("Sample app with tab completion")
{
    new DateCommand()
};

await rootCommand.Parse(args).InvokeAsync();

//new DateCommand().Parse(args).Invoke();

class DateCommand : Command
{
    private readonly Argument<string> _subjectArgument = new("subject")
    {
        Description = "The subject of the appointment."
    };
    private readonly Option<DateTime> _dateOption = new("--date")
    {
        Description = "The day of week to schedule. Should be within one week."
    };

    public DateCommand() : base("schedule", "Makes an appointment for sometime in the next week.")
    {
        this.Arguments.Add(_subjectArgument);
        this.Options.Add(_dateOption);

        // <dateoption>
        _dateOption.CompletionSources.Add(ctx => {
            DateTime today = DateTime.Today;
            List<CompletionItem> dates = [];
            foreach (int i in Enumerable.Range(1, 7))
            {
                DateTime date = today.AddDays(i);
                // <completionitem>
                dates.Add(new CompletionItem(
                    label: date.ToShortDateString(),
                    sortText: $"{i:2}"));
                // </completionitem>
            }
            return dates;
        });
        // </dateoption>

        this.SetAction(parseResult =>
        {
            Console.WriteLine($"Scheduled \"{parseResult.GetValue(_subjectArgument)}\" for {parseResult.GetValue(_dateOption)}");
        });
    }
}
// </all>
