Attendee[] attendees =
[
    new("Ben", "Host", 1),
    new("Ada", "Guest", 2)
];

// <PrintCopies>
var orderedAttendees = attendees.OrderBy(
    attendee => attendee.Name, StringComparer.Ordinal);

foreach (Attendee attendee in orderedAttendees)
{
    foreach (string label in CreateLabels(attendee))
    {
        Console.WriteLine(label);
    }
}
// </PrintCopies>

// <CreateCopies>
static IEnumerable<string> CreateLabels(Attendee attendee)
{
    ArgumentOutOfRangeException.ThrowIfNegativeOrZero(attendee.Copies);

    for (int copy = 1; copy <= attendee.Copies; copy++)
    {
        yield return $"{attendee.Name} | {attendee.Role} [{copy}/{attendee.Copies}]";
    }
}
// </CreateCopies>

record Attendee(string Name, string Role, int Copies);

// => Ada | Guest [1/2]
// => Ada | Guest [2/2]
// => Ben | Host [1/1]
