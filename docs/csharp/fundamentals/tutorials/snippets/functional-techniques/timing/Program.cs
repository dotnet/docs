Attendee[] attendees =
[
    new("Ben", "Host", 1),
    new("Ada", "Guest", 2)
];

// <ObserveExecution>
Console.WriteLine("Before query definition.");

var orderedAttendees = attendees.OrderBy(
    attendee =>
    {
        Console.WriteLine($"Sort key: {attendee.Name}");
        return attendee.Name;
    }, StringComparer.Ordinal);

Console.WriteLine("After query definition.");

foreach (Attendee attendee in orderedAttendees)
{
    Console.WriteLine($"{attendee.Name} | {attendee.Role}");
}
// </ObserveExecution>

record Attendee(string Name, string Role, int Copies);

// => Before query definition.
// => After query definition.
// => Sort key: Ben
// => Sort key: Ada
// => Ada | Guest
// => Ben | Host
