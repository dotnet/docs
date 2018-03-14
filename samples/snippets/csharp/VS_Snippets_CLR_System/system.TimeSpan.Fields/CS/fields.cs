//<Snippet1>
// Example of the TimeSpan fields.
using System;

class TimeSpanFieldsDemo
{
    // Pad the end of a TimeSpan string with spaces if it does not 
    // contain milliseconds.
    static string Align( TimeSpan interval )
    {
        string  intervalStr = interval.ToString( );
        int     pointIndex = intervalStr.IndexOf( ':' );

        pointIndex = intervalStr.IndexOf( '.', pointIndex );
        if( pointIndex < 0 ) intervalStr += "        ";
        return intervalStr;
    } 

    static void Main( )
    {
        const string numberFmt = "{0,-22}{1,18:N0}" ;
        const string timeFmt = "{0,-22}{1,26}" ;

        Console.WriteLine( 
            "This example of the fields of the TimeSpan class" +
            "\ngenerates the following output.\n" );
        Console.WriteLine( numberFmt, "Field", "Value" );
        Console.WriteLine( numberFmt, "-----", "-----" );

        // Display the maximum, minimum, and zero TimeSpan values.
        Console.WriteLine( timeFmt, "Maximum TimeSpan", 
            Align( TimeSpan.MaxValue ) );
        Console.WriteLine( timeFmt, "Minimum TimeSpan", 
            Align( TimeSpan.MinValue ) );
        Console.WriteLine( timeFmt, "Zero TimeSpan", 
            Align( TimeSpan.Zero ) );
        Console.WriteLine( );

        // Display the ticks-per-time-unit fields.
        Console.WriteLine( numberFmt, "Ticks per day", 
            TimeSpan.TicksPerDay );
        Console.WriteLine( numberFmt, "Ticks per hour", 
            TimeSpan.TicksPerHour );
        Console.WriteLine( numberFmt, "Ticks per minute", 
            TimeSpan.TicksPerMinute );
        Console.WriteLine( numberFmt, "Ticks per second", 
            TimeSpan.TicksPerSecond );
        Console.WriteLine( numberFmt, "Ticks per millisecond", 
            TimeSpan.TicksPerMillisecond );
    }
} 

/*
This example of the fields of the TimeSpan class
generates the following output.

Field                              Value
-----                              -----
Maximum TimeSpan       10675199.02:48:05.4775807
Minimum TimeSpan      -10675199.02:48:05.4775808
Zero TimeSpan                   00:00:00

Ticks per day            864,000,000,000
Ticks per hour            36,000,000,000
Ticks per minute             600,000,000
Ticks per second              10,000,000
Ticks per millisecond             10,000
*/
//</Snippet1>
