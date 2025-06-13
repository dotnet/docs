// <all>
using System.CommandLine;
using System.CommandLine.Completions;
using System.CommandLine.Parsing;

new DateCommand().Parse(args).Invoke();

class DateCommand : Command
{
    private Argument<string> subjectArgument = new("subject")
    {
        Description = "The subject of the appointment."
    };
    private Option<DateTime> dateOption = new("--date")
    {
        Description = "The day of week to schedule. Should be within one week."
    };

    public DateCommand() : base("schedule", "Makes an appointment for sometime in the next week.")
    {
        this.Arguments.Add(subjectArgument);
        this.Options.Add(dateOption);

        // <dateoption>
        dateOption.CompletionSources.Add(ctx => {
            var today = System.DateTime.Today;
            List<CompletionItem> dates = new();
            foreach (var i in Enumerable.Range(1, 7))
            {
                var date = today.AddDays(i);
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
            Console.WriteLine($"Scheduled \"{parseResult.GetValue(subjectArgument)}\" for {parseResult.GetValue(dateOption)}");
        });
    }
}
// </all>
