
//<Snippet4>
// Example of the TimeSpan( int, int, int, int, int ) constructor. 
using namespace System;

// Create a TimeSpan object and display its value.
void CreateTimeSpan( int days, int hours, int minutes, int seconds, int millisec )
{
   TimeSpan elapsedTime = TimeSpan(days,hours,minutes,seconds,millisec);
   
   // Format the constructor for display.
   array<Object^>^boxedParams = gcnew array<Object^>(5);
   boxedParams[ 0 ] = days;
   boxedParams[ 1 ] = hours;
   boxedParams[ 2 ] = minutes;
   boxedParams[ 3 ] = seconds;
   boxedParams[ 4 ] = millisec;
   String^ ctor = String::Format( "TimeSpan( {0}, {1}, {2}, {3}, {4} )", boxedParams );
   
   // Display the constructor and its value.
   Console::WriteLine( "{0,-48}{1,24}", ctor, elapsedTime.ToString() );
}

int main()
{
   Console::WriteLine( "This example of the TimeSpan( int, int, int, int, int ) "
   "\nconstructor generates the following output.\n" );
   Console::WriteLine( "{0,-48}{1,16}", "Constructor", "Value" );
   Console::WriteLine( "{0,-48}{1,16}", "-----------", "-----" );
   CreateTimeSpan( 10, 20, 30, 40, 50 );
   CreateTimeSpan(  -10, 20, 30, 40, 50 );
   CreateTimeSpan( 0, 0, 0, 0, 937840050 );
   CreateTimeSpan( 1111, 2222, 3333, 4444, 5555 );
   CreateTimeSpan( 1111, -2222, -3333, -4444, -5555 );
   CreateTimeSpan( 99999, 99999, 99999, 99999, 99999 );
}

/*
This example of the TimeSpan( int, int, int, int, int )
constructor generates the following output.

Constructor                                                Value
-----------                                                -----
TimeSpan( 10, 20, 30, 40, 50 )                       10.20:30:40.0500000
TimeSpan( -10, 20, 30, 40, 50 )                      -9.03:29:19.9500000
TimeSpan( 0, 0, 0, 0, 937840050 )                    10.20:30:40.0500000
TimeSpan( 1111, 2222, 3333, 4444, 5555 )           1205.22:47:09.5550000
TimeSpan( 1111, -2222, -3333, -4444, -5555 )       1016.01:12:50.4450000
TimeSpan( 99999, 99999, 99999, 99999, 99999 )    104236.05:27:18.9990000
*/
//</Snippet4>
