Attendee[] attendees =
[
    new("Ben", "Host", 1),
    new("Ada", "Guest", 2)
];

// <Sort>
var orderedAttendees = attendees.OrderBy(
    attendee => attendee.Name, StringComparer.Ordinal);

foreach (Attendee attendee in orderedAttendees)
{
    Console.WriteLine($"{attendee.Name} | {attendee.Role}");
}
// </Sort>

record Attendee(string Name, string Role, int Copies);

// => Ada | Guest
// => Ben | Host
