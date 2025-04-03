namespace ExampleProject;

//<CustomProvider>
public class MoonLandingTimeProviderPST: TimeProvider
{
    // July 20, 1969, at 20:17:40 UTC
    private readonly DateTimeOffset _specificDateTime = new(1969, 7, 20, 20, 17, 40, TimeZoneInfo.Utc.BaseUtcOffset);

    public override DateTimeOffset GetUtcNow() => _specificDateTime;

    public override TimeZoneInfo LocalTimeZone => TimeZoneInfo.FindSystemTimeZoneById("PST");
}
//</CustomProvider>
