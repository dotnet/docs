// <all>
using System.CommandLine;
using System.CommandLine.Completions;
using System.CommandLine.Parsing;

await new DateCommand().InvokeAsync(args);

class DateCommand : Command
{
    private Argument<string> subjectArgument = 
        new ("subject", "The subject of the appointment.");
    private Option<DateTime> dateOption = 
        new ("--date", "The day of week to schedule. Should be within one week.");
    
    public DateCommand() : base("schedule", "Makes an appointment for sometime in the next week.")
    {
        this.AddArgument(subjectArgument);
        this.AddOption(dateOption);

        // <dateoption>
        dateOption.AddCompletions((ctx) => {
            var today = System.DateTime.Today;
            var dates = new List<CompletionItem>();
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

        this.SetHandler((subject, date) =>
            {
                Console.WriteLine($"Scheduled \"{subject}\" for {date}");
            },
            subjectArgument, dateOption);
    }
}
// </all>
