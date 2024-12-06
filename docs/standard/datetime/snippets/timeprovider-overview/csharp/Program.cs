using ExampleProject;

Console.WriteLine(@"_./-==--======- getlocal -======--==-\._");

//<GetLocal>
Console.WriteLine($"Local: {TimeProvider.System.GetLocalNow()}");
Console.WriteLine($"Utc:   {TimeProvider.System.GetUtcNow()}");

/* This example produces output similar to the following:
 *
 * Local: 12/5/2024 10:41:14 AM -08:00
 * Utc:   12/5/2024 6:41:14 PM +00:00
*/
//</GetLocal>

Console.WriteLine(@"_./-==--======- timestamp -======--==-\._");

//<Timestamp>
long stampStart = TimeProvider.System.GetTimestamp();
Console.WriteLine($"Starting timestamp: {stampStart}");

long stampEnd = TimeProvider.System.GetTimestamp();
Console.WriteLine($"Ending timestamp:   {stampEnd}");

Console.WriteLine($"Elapsed time: {TimeProvider.System.GetElapsedTime(stampStart, stampEnd)}");
Console.WriteLine($"Nanoseconds: {TimeProvider.System.GetElapsedTime(stampStart, stampEnd).TotalNanoseconds}"); 

/* This example produces output similar to the following:
 *
 * Starting timestamp: 55185546133
 * Ending timestamp:   55185549929
 * Elapsed time: 00:00:00.0003796
 * Nanoseconds: 379600
*/
//</Timestamp>

Console.WriteLine(@"_./-==--======- greeting-normal -======--==-\._");

//<GreetingNormal>
CalendarHelper.SendGreeting(TimeProvider.System, "Eric Solomon");

/* This example produces output similar to the following:
 *
 * Good morning, Eric Solomon! 
 * The date is 12/5/2024 and the day is Thursday. 
 * I hope you enjoy your day! 
*/
//</GreetingNormal>

Console.WriteLine(@"_./-==--======- greeting-moon -======--==-\._");

//<GreetingMoon>
CalendarHelper.SendGreeting(new MoonLandingTimeProviderPST(), "Eric Solomon");

/* This example produces output similar to the following:
 *
 * Good morning, Eric Solomon!
 * The date is 7/20/1969 and the day is Sunday.
 * Did you know that on this day in 1969 humans landed on the Moon?
 * I hope you enjoy your day!
*/
//</GreetingMoon>
