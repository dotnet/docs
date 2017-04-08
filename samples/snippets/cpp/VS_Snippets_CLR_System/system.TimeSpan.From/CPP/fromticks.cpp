
//<Snippet1>
// Example of the TimeSpan::FromTicks( __int64 ) method.
using namespace System;
void GenTimeSpanFromTicks( __int64 ticks )
{
   
   // Create a TimeSpan object and TimeSpan string from 
   // a number of ticks.
   TimeSpan interval = TimeSpan::FromTicks( ticks );
   String^ timeInterval = interval.ToString();
   
   // Pad the end of the TimeSpan string with spaces if it 
   // does not contain milliseconds.
   int pIndex = timeInterval->IndexOf( ':' );
   pIndex = timeInterval->IndexOf( '.', pIndex );
   if ( pIndex < 0 )
      timeInterval = String::Concat( timeInterval, "        " );

   Console::WriteLine( "{0,21}{1,26}", ticks, timeInterval );
}

int main()
{
   Console::WriteLine( "This example of TimeSpan::FromTicks( __int64 )\n"
   "generates the following output.\n" );
   Console::WriteLine( "{0,21}{1,18}", "FromTicks", "TimeSpan" );
   Console::WriteLine( "{0,21}{1,18}", "---------", "--------" );
   GenTimeSpanFromTicks( 1 );
   GenTimeSpanFromTicks( 12345 );
   GenTimeSpanFromTicks( 123456789 );
   GenTimeSpanFromTicks( 1234567898765 );
   GenTimeSpanFromTicks( 12345678987654321 );
   GenTimeSpanFromTicks( 10000000 );
   GenTimeSpanFromTicks( 600000000 );
   GenTimeSpanFromTicks( 36000000000 );
   GenTimeSpanFromTicks( 864000000000 );
   GenTimeSpanFromTicks( 18012202000000 );
}

/*
This example of TimeSpan::FromTicks( __int64 )
generates the following output.

            FromTicks          TimeSpan
            ---------          --------
                    1          00:00:00.0000001
                12345          00:00:00.0012345
            123456789          00:00:12.3456789
        1234567898765        1.10:17:36.7898765
    12345678987654321    14288.23:31:38.7654321
             10000000          00:00:01
            600000000          00:01:00
          36000000000          01:00:00
         864000000000        1.00:00:00
       18012202000000       20.20:20:20.2000000
*/
//</Snippet1>
