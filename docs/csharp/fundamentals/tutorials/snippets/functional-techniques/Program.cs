// <Complete>
// <Controls>
#define BADGE_SORT
#define BADGE_COPIES
#define BADGE_FORMAT
#define BADGE_COUNT
// #define BADGE_DIAGNOSTICS
// #define BADGE_REPEAT
// #define BADGE_SNAPSHOT
// </Controls>

// <Input>
Attendee[] attendees =
[
    new("Ben", "Host", 1),
    new("Ada", "Guest", 2)
];
// </Input>

// <ObserveExecution>
#if BADGE_SORT
#if BADGE_DIAGNOSTICS
Console.WriteLine("Before query definition.");
#endif
// <Sort>
var orderedAttendees = attendees.OrderBy(
#if BADGE_DIAGNOSTICS
    attendee =>
    {
        Console.WriteLine($"Sort key: {attendee.Name}");
        return attendee.Name;
    }, StringComparer.Ordinal);
#else
    attendee => attendee.Name, StringComparer.Ordinal);
#endif
// </Sort>
#if BADGE_DIAGNOSTICS
Console.WriteLine("After query definition.");
#endif
#else
var orderedAttendees = attendees;
#endif
// </ObserveExecution>

// <Enumeration>
#if BADGE_SNAPSHOT
var attendeesToPrint = orderedAttendees.ToList();
#else
var attendeesToPrint = orderedAttendees;
#endif

int passes = 1;
#if BADGE_REPEAT
passes = 2;
#endif
// </Enumeration>

for (int pass = 0; pass < passes; pass++)
{
// <CountSetup>
#if BADGE_COUNT
    int expected = attendees.Sum(attendee => attendee.Copies);
    int printed = 0;
#endif
// </CountSetup>

// <PrintLabels>
    foreach (Attendee attendee in attendeesToPrint)
    {
#if BADGE_COPIES
        var labels = CreateLabels(attendee);
#if BADGE_DIAGNOSTICS
        Console.WriteLine($"Sequence created: {attendee.Name}");
#endif
        foreach (string label in labels)
        {
            Console.WriteLine(label);
#if BADGE_COUNT
            printed++;
#endif
        }
#else
        Console.WriteLine($"{attendee.Name} | {attendee.Role}");
#endif
    }
// </PrintLabels>

// <CountCheck>
#if BADGE_COUNT
    if (printed != expected)
    {
        throw new InvalidOperationException("Label count doesn't match the request.");
    }

    Console.WriteLine($"Printed {printed} of {expected} requested labels.");
#endif
// </CountCheck>
}

// <CreateLabels>
#if BADGE_COPIES
static IEnumerable<string> CreateLabels(Attendee attendee)
{
#if BADGE_DIAGNOSTICS
    Console.WriteLine($"Iterator started: {attendee.Name}");
#endif
    ArgumentOutOfRangeException.ThrowIfNegativeOrZero(attendee.Copies);

// <Message>
#if BADGE_FORMAT
    string message = attendee.Role switch
    {
        "Guest" => "Welcome!",
        "Host" => "Ask me for help",
        _ => throw new ArgumentException(
            $"Unsupported role: {attendee.Role}.", nameof(attendee))
    };
#endif
// </Message>

    for (int copy = 1; copy <= attendee.Copies; copy++)
    {
#if BADGE_FORMAT
        yield return FormatLabel(
            attendee.Name, attendee.Role, message, copy, attendee.Copies);
#else
        yield return $"{attendee.Name} | {attendee.Role} [{copy}/{attendee.Copies}]";
#endif
    }

// <FormatLabel>
#if BADGE_FORMAT
    static string FormatLabel(
        string name, string role, string message, int copy, int total) =>
        $"{name} | {role} | {message} [{copy}/{total}]";
#endif
// </FormatLabel>
}
#endif
// </CreateLabels>

record Attendee(string Name, string Role, int Copies);
// </Complete>

// => Ada | Guest | Welcome! [1/2]
// => Ada | Guest | Welcome! [2/2]
// => Ben | Host | Ask me for help [1/1]
// => Printed 3 of 3 requested labels.
