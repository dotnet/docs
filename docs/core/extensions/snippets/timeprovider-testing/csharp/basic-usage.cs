using Microsoft.Extensions.Time.Testing;

// <BasicUsage>
var fakeTimeProvider = new FakeTimeProvider();

// Get the current time (defaults to January 1, 2000, midnight UTC).
Console.WriteLine($"Start time: {fakeTimeProvider.GetUtcNow()}");
// </BasicUsage>

// <InitializeSpecificTime>
DateTimeOffset startTime = new(2025, 10, 20, 12, 0, 0, TimeSpan.Zero);
fakeTimeProvider = new FakeTimeProvider(startTime);

Console.WriteLine($"Started at: {fakeTimeProvider.GetUtcNow()}");
// </InitializeSpecificTime>

// Advance time by 1 hour.
fakeTimeProvider.Advance(TimeSpan.FromHours(1));
Console.WriteLine($"After advancing 1 hour: {fakeTimeProvider.GetUtcNow()}");

// Set a specific time.
var specificTime = new DateTimeOffset(2025, 6, 15, 10, 30, 0, TimeSpan.Zero);
fakeTimeProvider.SetUtcNow(specificTime);
Console.WriteLine($"After setting specific time: {fakeTimeProvider.GetUtcNow()}");

// </AdvanceTime>
// Advance time by 30 minutes.
fakeTimeProvider.Advance(TimeSpan.FromMinutes(30));
Console.WriteLine($"After advancing 30 minutes: {fakeTimeProvider.GetUtcNow()}");
// </AdvanceTime>

// <ConfigureTimeZone>
var timeZoneId = OperatingSystem.IsWindows() ? "Pacific Standard Time" : "America/Los_Angeles";
var pacificTimeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
fakeTimeProvider.SetLocalTimeZone(pacificTimeZone);

var localTime = fakeTimeProvider.GetLocalNow();
Console.WriteLine($"Local time: {localTime}");
// </ConfigureTimeZone>
