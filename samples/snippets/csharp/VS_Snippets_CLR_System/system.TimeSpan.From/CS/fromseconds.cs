//<Snippet3>
// Example of the TimeSpan.FromSeconds( double ) method.
using System;

class FromSecondsDemo
{
    static void GenTimeSpanFromSeconds( double seconds )
    {
        // Create a TimeSpan object and TimeSpan string from 
        // a number of seconds.
        TimeSpan    interval = TimeSpan.FromSeconds( seconds );
        string      timeInterval = interval.ToString( );

        // Pad the end of the TimeSpan string with spaces if it 
        // does not contain milliseconds.
        int pIndex = timeInterval.IndexOf( ':' );
        pIndex = timeInterval.IndexOf( '.', pIndex );
        if( pIndex < 0 )   timeInterval += "        ";

        Console.WriteLine( "{0,21}{1,26}", seconds, timeInterval );
    } 

    static void Main( )
    {
        Console.WriteLine(
            "This example of TimeSpan.FromSeconds( double )\n" +
            "generates the following output.\n" );
        Console.WriteLine( "{0,21}{1,18}",
            "FromSeconds", "TimeSpan" );
        Console.WriteLine( "{0,21}{1,18}", 
            "-----------", "--------" );

        GenTimeSpanFromSeconds( 0.001 );
        GenTimeSpanFromSeconds( 0.0015 );
        GenTimeSpanFromSeconds( 12.3456 );
        GenTimeSpanFromSeconds( 123456.7898 );
        GenTimeSpanFromSeconds( 1234567898.7654 );
        GenTimeSpanFromSeconds( 1 );
        GenTimeSpanFromSeconds( 60 );
        GenTimeSpanFromSeconds( 3600 );
        GenTimeSpanFromSeconds( 86400 );
        GenTimeSpanFromSeconds( 1801220.2 );
    } 
} 

/*
This example of TimeSpan.FromSeconds( double )
generates the following output.

          FromSeconds          TimeSpan
          -----------          --------
                0.001          00:00:00.0010000
               0.0015          00:00:00.0020000
              12.3456          00:00:12.3460000
          123456.7898        1.10:17:36.7900000
      1234567898.7654    14288.23:31:38.7650000
                    1          00:00:01
                   60          00:01:00
                 3600          01:00:00
                86400        1.00:00:00
            1801220.2       20.20:20:20.2000000
*/ 
//</Snippet3>
