var sessions = new[]
{
    new WorkshopSession("Build a tiny game", 60, 20, 18),
    new WorkshopSession("Explore cloud architecture", 90, 30, 22),
    new WorkshopSession("Debug with confidence", 45, 16, 16),
};

// <PassBehavior>
int maximumMinutes = 60;

var shortSessions = sessions
    .Where(session => session.DurationMinutes <= maximumMinutes)
    .OrderBy(session => session.Title);

foreach (WorkshopSession session in shortSessions)
{
    Console.WriteLine(session.Title);
}
// </PassBehavior>

// <StatementBody>
var descriptions = sessions.Select(session =>
{
    int seatsLeft = session.Capacity - session.Registered;
    string availability = seatsLeft > 0 ? $"{seatsLeft} seats left" : "full";
    return $"{session.Title}: {availability}";
});

Console.WriteLine(string.Join(Environment.NewLine, descriptions));
// </StatementBody>

// <MethodGroup>
var openSessions = sessions.Where(HasOpenSeats);

foreach (WorkshopSession session in openSessions)
{
    Console.WriteLine($"Open: {session.Title}");
}

static bool HasOpenSeats(WorkshopSession session) =>
    session.Registered < session.Capacity;
// </MethodGroup>

record WorkshopSession(
    string Title,
    int DurationMinutes,
    int Capacity,
    int Registered);

