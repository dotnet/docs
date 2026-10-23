Attendee[] attendees =
[
    new("Ben", "Host", 1),
    new("Ada", "Guest", 2)
];

var orderedAttendees = attendees.OrderBy(
    attendee => attendee.Name, StringComparer.Ordinal);

foreach (Attendee attendee in orderedAttendees)
{
    // <ObserveIterator>
    var labels = CreateLabels(attendee);
    Console.WriteLine($"Sequence created: {attendee.Name}");
    foreach (string label in labels)
    {
        Console.WriteLine(label);
    }
    // </ObserveIterator>
}

static IEnumerable<string> CreateLabels(Attendee attendee)
{
    Console.WriteLine($"Iterator started: {attendee.Name}");
    ArgumentOutOfRangeException.ThrowIfNegativeOrZero(attendee.Copies);

    for (int copy = 1; copy <= attendee.Copies; copy++)
    {
        yield return $"{attendee.Name} | {attendee.Role} [{copy}/{attendee.Copies}]";
    }
}

record Attendee(string Name, string Role, int Copies);

// => Sequence created: Ada
// => Iterator started: Ada
// => Ada | Guest [1/2]
// => Ada | Guest [2/2]
// => Sequence created: Ben
// => Iterator started: Ben
// => Ben | Host [1/1]
