//<Snippet1>
// Example of the TimeSpan relational operators.
using System;

class TSRelationalOpsDemo
{
    const string dataFmt = "{0,34}    {1}" ;

    // Compare TimeSpan parameters, and display them with the results.
    static void CompareTimeSpans( TimeSpan Left, TimeSpan Right, 
        string RightText )
    {
        Console.WriteLine( );
        Console.WriteLine( dataFmt, "Right: " + RightText, Right );
        Console.WriteLine( dataFmt, "Left == Right", Left == Right );
        Console.WriteLine( dataFmt, "Left >  Right", Left > Right );
        Console.WriteLine( dataFmt, "Left >= Right", Left >= Right );
        Console.WriteLine( dataFmt, "Left != Right", Left != Right );
        Console.WriteLine( dataFmt, "Left <  Right", Left < Right );
        Console.WriteLine( dataFmt, "Left <= Right", Left <= Right );
    }

    static void Main( )
    {
        TimeSpan Left = new TimeSpan( 2, 0, 0 );

        Console.WriteLine(
            "This example of the TimeSpan relational operators " +
            "generates \nthe following output. It creates several " +
            "different TimeSpan \nobjects and compares them with " +
            "a 2-hour TimeSpan.\n" );
        Console.WriteLine( dataFmt, 
            "Left: TimeSpan( 2, 0, 0 )", Left );

        // Create objects to compare with a 2-hour TimeSpan.
        CompareTimeSpans( Left, new TimeSpan( 0, 120, 0 ), 
            "TimeSpan( 0, 120, 0 )" );
        CompareTimeSpans( Left, new TimeSpan( 2, 0, 1 ), 
            "TimeSpan( 2, 0, 1 )" );
        CompareTimeSpans( Left, new TimeSpan( 2, 0, -1 ), 
            "TimeSpan( 2, 0, -1 )" );
        CompareTimeSpans( Left, TimeSpan.FromDays( 1.0 / 12D ), 
            "TimeSpan.FromDays( 1 / 12 )" );
    } 
} 

/*
This example of the TimeSpan relational operators generates
the following output. It creates several different TimeSpan
objects and compares them with a 2-hour TimeSpan.

         Left: TimeSpan( 2, 0, 0 )    02:00:00

      Right: TimeSpan( 0, 120, 0 )    02:00:00
                     Left == Right    True
                     Left >  Right    False
                     Left >= Right    True
                     Left != Right    False
                     Left <  Right    False
                     Left <= Right    True

        Right: TimeSpan( 2, 0, 1 )    02:00:01
                     Left == Right    False
                     Left >  Right    False
                     Left >= Right    False
                     Left != Right    True
                     Left <  Right    True
                     Left <= Right    True

       Right: TimeSpan( 2, 0, -1 )    01:59:59
                     Left == Right    False
                     Left >  Right    True
                     Left >= Right    True
                     Left != Right    True
                     Left <  Right    False
                     Left <= Right    False

Right: TimeSpan.FromDays( 1 / 12 )    02:00:00
                     Left == Right    True
                     Left >  Right    False
                     Left >= Right    True
                     Left != Right    False
                     Left <  Right    False
                     Left <= Right    True
*/ 
//</Snippet1>
