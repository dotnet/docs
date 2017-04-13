
//<Snippet5>
// Example of the TimeSpan::FromHours( double ) method.
using namespace System;
void GenTimeSpanFromHours( double hours )
{
   
   // Create a TimeSpan object and TimeSpan string from 
   // a number of hours.
   TimeSpan interval = TimeSpan::FromHours( hours );
   String^ timeInterval = interval.ToString();
   
   // Pad the end of the TimeSpan string with spaces if it 
   // does not contain milliseconds.
   int pIndex = timeInterval->IndexOf( ':' );
   pIndex = timeInterval->IndexOf( '.', pIndex );
   if ( pIndex < 0 )
      timeInterval = String::Concat( timeInterval, "        " );

   Console::WriteLine( "{0,21}{1,26}", hours, timeInterval );
}

int main()
{
   Console::WriteLine( "This example of TimeSpan::FromHours( double )\n"
   "generates the following output.\n" );
   Console::WriteLine( "{0,21}{1,18}", "FromHours", "TimeSpan" );
   Console::WriteLine( "{0,21}{1,18}", "---------", "--------" );
   GenTimeSpanFromHours( 0.0000002 );
   GenTimeSpanFromHours( 0.0000003 );
   GenTimeSpanFromHours( 0.0012345 );
   GenTimeSpanFromHours( 12.3456789 );
   GenTimeSpanFromHours( 123456.7898765 );
   GenTimeSpanFromHours( 0.0002777 );
   GenTimeSpanFromHours( 0.0166666 );
   GenTimeSpanFromHours( 1 );
   GenTimeSpanFromHours( 24 );
   GenTimeSpanFromHours( 500.3389445 );
}

/*
This example of TimeSpan::FromHours( double )
generates the following output.

            FromHours          TimeSpan
            ---------          --------
                2E-07          00:00:00.0010000
                3E-07          00:00:00.0010000
            0.0012345          00:00:04.4440000
           12.3456789          12:20:44.4440000
       123456.7898765     5144.00:47:23.5550000
            0.0002777          00:00:01
            0.0166666          00:01:00
                    1          01:00:00
                   24        1.00:00:00
          500.3389445       20.20:20:20.2000000
*/
//</Snippet5>
