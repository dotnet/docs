//<Snippet1>
// Example of the TimeSpan.Duration( ) and TimeSpan.Negate( ) methods,
// and the TimeSpan Unary Negation and Unary Plus operators.
using System;

class DuraNegaUnaryDemo
{
    const string dataFmt = "{0,22}{1,22}{2,22}" ;

    static void ShowDurationNegate( TimeSpan interval )
    {
        // Display the TimeSpan value and the results of the 
        // Duration and Negate methods.
        Console.WriteLine( dataFmt, 
            interval, interval.Duration( ), interval.Negate( ) );
    }

    static void Main()
    {
        Console.WriteLine(
            "This example of TimeSpan.Duration( ), " +
            "TimeSpan.Negate( ), \nand the TimeSpan Unary " +
            "Negation and Unary Plus operators \n" +
            "generates the following output.\n" );
        Console.WriteLine( dataFmt, 
            "TimeSpan", "Duration( )", "Negate( )" );
        Console.WriteLine( dataFmt, 
            "--------", "-----------", "---------" );

        // Create TimeSpan objects and apply the Unary Negation
        // and Unary Plus operators to them.
        ShowDurationNegate( new TimeSpan( 1 ) );
        ShowDurationNegate( new TimeSpan( -1234567 ) );
        ShowDurationNegate( 
            + new TimeSpan( 0, 0, 10, -20, -30 ) );
        ShowDurationNegate( 
            + new TimeSpan( 0, -10, 20, -30, 40 ) );
        ShowDurationNegate( 
            - new TimeSpan( 1, 10, 20, 40, 160 ) );
        ShowDurationNegate( 
            - new TimeSpan( -10, -20, -30, -40, -50 ) );
    } 
} 

/*
This example of TimeSpan.Duration( ), TimeSpan.Negate( ),
and the TimeSpan Unary Negation and Unary Plus operators
generates the following output.

              TimeSpan           Duration( )             Negate( )
              --------           -----------             ---------
      00:00:00.0000001      00:00:00.0000001     -00:00:00.0000001
     -00:00:00.1234567      00:00:00.1234567      00:00:00.1234567
      00:09:39.9700000      00:09:39.9700000     -00:09:39.9700000
     -09:40:29.9600000      09:40:29.9600000      09:40:29.9600000
   -1.10:20:40.1600000    1.10:20:40.1600000    1.10:20:40.1600000
   10.20:30:40.0500000   10.20:30:40.0500000  -10.20:30:40.0500000
*/ 
//</Snippet1>
