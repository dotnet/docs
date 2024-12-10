namespace ExampleProject;

//<CalendarHelper>
public static class CalendarHelper
{
    static readonly DateTimeOffset MoonLandingDateTime = new(1969, 7, 20, 20, 17, 40, TimeZoneInfo.Utc.BaseUtcOffset);
    
    public static void SendGreeting(TimeProvider currentTime, string name)
    {
        DateTimeOffset localTime = currentTime.GetLocalNow();

        Console.WriteLine($"Good morning, {name}!");
        Console.WriteLine($"The date is {localTime.Date:d} and the day is {localTime.Date.DayOfWeek}.");

        if (localTime.Date.Month == MoonLandingDateTime.Date.Month
            && localTime.Date.Day == MoonLandingDateTime.Date.Day)
        {
            Console.WriteLine("Did you know that on this day in 1969 humans landed on the Moon?");
        }

        Console.WriteLine($"I hope you enjoy your day!");
    }
}
//</CalendarHelper>
