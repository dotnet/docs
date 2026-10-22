// <Start>
Attendee[] attendees =
[
    new("Ben", "Host", 1),
    new("Ada", "Guest", 2)
];

foreach (Attendee attendee in attendees)
{
    Console.WriteLine($"{attendee.Name} | {attendee.Role}");
}

record Attendee(string Name, string Role, int Copies);
// </Start>

// => Ben | Host
// => Ada | Guest
