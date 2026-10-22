// <Complete>
Attendee[] attendees =
[
    new("Ben", "Host", 1),
    new("Ada", "Guest", 2)
];

// <PrintAndCount>
int expected = attendees.Sum(attendee => attendee.Copies);
int printed = 0;

var orderedAttendees = attendees.OrderBy(
    attendee => attendee.Name, StringComparer.Ordinal);

foreach (Attendee attendee in orderedAttendees)
{
    foreach (string label in CreateLabels(attendee))
    {
        Console.WriteLine(label);
        printed++;
    }
}

if (printed != expected)
{
    throw new InvalidOperationException("Label count doesn't match the request.");
}

Console.WriteLine($"Printed {printed} of {expected} requested labels.");
// </PrintAndCount>

// <CreateLabels>
static IEnumerable<string> CreateLabels(Attendee attendee)
{
    ArgumentOutOfRangeException.ThrowIfNegativeOrZero(attendee.Copies);

    string message = attendee.Role switch
    {
        "Guest" => "Welcome!",
        "Host" => "Ask me for help",
        _ => throw new ArgumentException(
            $"Unsupported role: {attendee.Role}.", nameof(attendee))
    };

    for (int copy = 1; copy <= attendee.Copies; copy++)
    {
        yield return FormatLabel(
            attendee.Name, attendee.Role, message, copy, attendee.Copies);
    }

    static string FormatLabel(
        string name, string role, string message, int copy, int total) =>
        $"{name} | {role} | {message} [{copy}/{total}]";
}
// </CreateLabels>

record Attendee(string Name, string Role, int Copies);
// </Complete>

// => Ada | Guest | Welcome! [1/2]
// => Ada | Guest | Welcome! [2/2]
// => Ben | Host | Ask me for help [1/1]
// => Printed 3 of 3 requested labels.
