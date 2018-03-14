//<Snippet2>
// Example of the TimeSpan.FromMilliseconds( double ) method.
using System;

class FromMillisecDemo
{
    static void GenTimeSpanFromMillisec( Double millisec )
    {
        // Create a TimeSpan object and TimeSpan string from 
        // a number of milliseconds.
        TimeSpan    interval = TimeSpan.FromMilliseconds( millisec );
        string      timeInterval = interval.ToString( );

        // Pad the end of the TimeSpan string with spaces if it 
        // does not contain milliseconds.
        int pIndex = timeInterval.IndexOf( ':' );
        pIndex = timeInterval.IndexOf( '.', pIndex );
        if( pIndex < 0 )   timeInterval += "        ";

        Console.WriteLine( "{0,21}{1,26}", millisec, timeInterval );
    } 

    static void Main( )
    {
        Console.WriteLine(
            "This example of TimeSpan.FromMilliseconds( " +
            "double )\ngenerates the following output.\n" );
        Console.WriteLine( "{0,21}{1,18}", 
            "FromMilliseconds", "TimeSpan" );
        Console.WriteLine( "{0,21}{1,18}", 
            "----------------", "--------" );

        GenTimeSpanFromMillisec( 1 );
        GenTimeSpanFromMillisec( 1.5 );
        GenTimeSpanFromMillisec( 12345.6 );
        GenTimeSpanFromMillisec( 123456789.8 );
        GenTimeSpanFromMillisec( 1234567898765.4 );
        GenTimeSpanFromMillisec( 1000 );
        GenTimeSpanFromMillisec( 60000 );
        GenTimeSpanFromMillisec( 3600000 );
        GenTimeSpanFromMillisec( 86400000 );
        GenTimeSpanFromMillisec( 1801220200 );
    } 
} 

/*
This example of TimeSpan.FromMilliseconds( double )
generates the following output.

     FromMilliseconds          TimeSpan
     ----------------          --------
                    1          00:00:00.0010000
                  1.5          00:00:00.0020000
              12345.6          00:00:12.3460000
          123456789.8        1.10:17:36.7900000
      1234567898765.4    14288.23:31:38.7650000
                 1000          00:00:01
                60000          00:01:00
              3600000          01:00:00
             86400000        1.00:00:00
           1801220200       20.20:20:20.2000000
*/
//</Snippet2>
