//<Snippet2>
// Example of the TimeSpan( int, int, int ) constructor.
using System;

class TimeSpanCtorIIIDemo
{
    // Create a TimeSpan object and display its value.
    static void CreateTimeSpan( int hours, int minutes, 
        int seconds )
    {
        TimeSpan elapsedTime = 
            new TimeSpan( hours, minutes, seconds );

        // Format the constructor for display.
        string ctor = String.Format( "TimeSpan( {0}, {1}, {2} )", 
            hours, minutes, seconds);

        // Display the constructor and its value.
        Console.WriteLine( "{0,-37}{1,16}", 
            ctor, elapsedTime.ToString( ) );
    }
    
    static void Main( )
    {
        Console.WriteLine(
            "This example of the TimeSpan( int, int, int ) " +
            "\nconstructor generates the following output.\n" );
        Console.WriteLine( "{0,-37}{1,16}", "Constructor", "Value" );
        Console.WriteLine( "{0,-37}{1,16}", "-----------", "-----" );

        CreateTimeSpan( 10, 20, 30 );
        CreateTimeSpan( -10, 20, 30 );
        CreateTimeSpan( 0, 0, 37230 );
        CreateTimeSpan( 1000, 2000, 3000 );
        CreateTimeSpan( 1000, -2000, -3000 );
        CreateTimeSpan( 999999, 999999, 999999 );
    } 
} 

/*
This example of the TimeSpan( int, int, int )
constructor generates the following output.

Constructor                                     Value
-----------                                     -----
TimeSpan( 10, 20, 30 )                       10:20:30
TimeSpan( -10, 20, 30 )                     -09:39:30
TimeSpan( 0, 0, 37230 )                      10:20:30
TimeSpan( 1000, 2000, 3000 )              43.02:10:00
TimeSpan( 1000, -2000, -3000 )            40.05:50:00
TimeSpan( 999999, 999999, 999999 )     42372.15:25:39
*/
//</Snippet2>
