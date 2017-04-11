
//<Snippet4>
// Example of the TimeSpan::FromMinutes( double ) method.
using namespace System;
void GenTimeSpanFromMinutes( double minutes )
{
   
   // Create a TimeSpan object and TimeSpan string from 
   // a number of minutes.
   TimeSpan interval = TimeSpan::FromMinutes( minutes );
   String^ timeInterval = interval.ToString();
   
   // Pad the end of the TimeSpan string with spaces if it 
   // does not contain milliseconds.
   int pIndex = timeInterval->IndexOf( ':' );
   pIndex = timeInterval->IndexOf( '.', pIndex );
   if ( pIndex < 0 )
      timeInterval = String::Concat( timeInterval, "        " );

   Console::WriteLine( "{0,21}{1,26}", minutes, timeInterval );
}

int main()
{
   Console::WriteLine( "This example of TimeSpan::FromMinutes( double )\n"
   "generates the following output.\n" );
   Console::WriteLine( "{0,21}{1,18}", "FromMinutes", "TimeSpan" );
   Console::WriteLine( "{0,21}{1,18}", "-----------", "--------" );
   GenTimeSpanFromMinutes( 0.00001 );
   GenTimeSpanFromMinutes( 0.00002 );
   GenTimeSpanFromMinutes( 0.12345 );
   GenTimeSpanFromMinutes( 1234.56789 );
   GenTimeSpanFromMinutes( 12345678.98765 );
   GenTimeSpanFromMinutes( 0.01666 );
   GenTimeSpanFromMinutes( 1 );
   GenTimeSpanFromMinutes( 60 );
   GenTimeSpanFromMinutes( 1440 );
   GenTimeSpanFromMinutes( 30020.33667 );
}

/*
This example of TimeSpan::FromMinutes( double )
generates the following output.

          FromMinutes          TimeSpan
          -----------          --------
                1E-05          00:00:00.0010000
                2E-05          00:00:00.0010000
              0.12345          00:00:07.4070000
           1234.56789          20:34:34.0730000
       12345678.98765     8573.09:18:59.2590000
              0.01666          00:00:01
                    1          00:01:00
                   60          01:00:00
                 1440        1.00:00:00
          30020.33667       20.20:20:20.2000000
*/
//</Snippet4>
