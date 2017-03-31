//<Snippet1>
// Example of selected TimeZone class elements.
using System;
using System.Globalization;

class TimeZoneDemo
{
    static void Main( )
    {
        const string dataFmt = "{0,-30}{1}";
        const string timeFmt = "{0,-30}{1:yyyy-MM-dd HH:mm}";

        Console.WriteLine(
            "This example of selected TimeZone class " +
            "elements generates the following \n" +
            "output, which varies depending on the " +
            "time zone in which it is run.\n" );

        // Get the local time zone and the current local time and year.
        TimeZone localZone = TimeZone.CurrentTimeZone;
        DateTime currentDate = DateTime.Now;
        int      currentYear = currentDate.Year;

        // Display the names for standard time and daylight saving 
        // time for the local time zone.
        Console.WriteLine( dataFmt, "Standard time name:", 
            localZone.StandardName );
        Console.WriteLine( dataFmt, "Daylight saving time name:", 
            localZone.DaylightName );

        // Display the current date and time and show if they occur 
        // in daylight saving time.
        Console.WriteLine( "\n" + timeFmt, "Current date and time:",
            currentDate );
        Console.WriteLine( dataFmt, "Daylight saving time?", 
            localZone.IsDaylightSavingTime( currentDate ) );

        // Get the current Coordinated Universal Time (UTC) and UTC 
        // offset.
        DateTime currentUTC = 
            localZone.ToUniversalTime( currentDate );
        TimeSpan currentOffset = 
            localZone.GetUtcOffset( currentDate );

        Console.WriteLine( timeFmt, "Coordinated Universal Time:", 
            currentUTC );
        Console.WriteLine( dataFmt, "UTC offset:", currentOffset );

        // Get the DaylightTime object for the current year.
        DaylightTime daylight = 
            localZone.GetDaylightChanges( currentYear );

        // Display the daylight saving time range for the current year.
        Console.WriteLine( 
            "\nDaylight saving time for year {0}:", currentYear );
        Console.WriteLine( "{0:yyyy-MM-dd HH:mm} to " +
            "{1:yyyy-MM-dd HH:mm}, delta: {2}", 
            daylight.Start, daylight.End, daylight.Delta );
    } 
} 

/*
This example of selected TimeZone class elements generates the following
output, which varies depending on the time zone in which it is run.

Standard time name:           Pacific Standard Time
Daylight saving time name:    Pacific Daylight Time

Current date and time:        2006-01-06 16:47
Daylight saving time?         False
Coordinated Universal Time:   2006-01-07 00:47
UTC offset:                   -08:00:00

Daylight saving time for year 2006:
2006-04-02 02:00 to 2006-10-29 02:00, delta: 01:00:00
*/ 
//</Snippet1>
