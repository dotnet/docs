//<Snippet6>
// Example of the TimeSpan.FromDays( double ) method.
using System;

class FromDaysDemo
{
    static void GenTimeSpanFromDays( double days )
    {
        // Create a TimeSpan object and TimeSpan string from 
        // a number of days.
        TimeSpan interval = TimeSpan.FromDays( days );
        string   timeInterval = interval.ToString( );

        // Pad the end of the TimeSpan string with spaces if it 
        // does not contain milliseconds.
        int pIndex = timeInterval.IndexOf( ':' );
        pIndex = timeInterval.IndexOf( '.', pIndex );
        if( pIndex < 0 )   timeInterval += "        ";

        Console.WriteLine( "{0,21}{1,26}", days, timeInterval );
    } 

    static void Main( )
    {
        Console.WriteLine(
            "This example of TimeSpan.FromDays( double )\n" +
            "generates the following output.\n" );
        Console.WriteLine( "{0,21}{1,18}",
            "FromDays", "TimeSpan" );
        Console.WriteLine( "{0,21}{1,18}", 
            "--------", "--------" );

        GenTimeSpanFromDays( 0.000000006 );
        GenTimeSpanFromDays( 0.000000017 );
        GenTimeSpanFromDays( 0.000123456 );
        GenTimeSpanFromDays( 1.234567898 );
        GenTimeSpanFromDays( 12345.678987654 );
        GenTimeSpanFromDays( 0.000011574 );
        GenTimeSpanFromDays( 0.000694444 );
        GenTimeSpanFromDays( 0.041666666 );
        GenTimeSpanFromDays( 1 );
        GenTimeSpanFromDays( 20.84745602 );
    } 
} 

/*
This example of TimeSpan.FromDays( double )
generates the following output.

             FromDays          TimeSpan
             --------          --------
                6E-09          00:00:00.0010000
              1.7E-08          00:00:00.0010000
          0.000123456          00:00:10.6670000
          1.234567898        1.05:37:46.6660000
      12345.678987654    12345.16:17:44.5330000
           1.1574E-05          00:00:01
          0.000694444          00:01:00
          0.041666666          01:00:00
                    1        1.00:00:00
          20.84745602       20.20:20:20.2000000
*/ 
//</Snippet6>
