//<Snippet3>
// Example of the decimal( long ) constructor.
using System;

class DecimalCtorLDemo
{
    // Create a decimal object and display its value.
    public static void CreateDecimal( long value, string valToStr )
    {
        decimal decimalNum = new decimal( value );

        // Format the constructor for display.
        string ctor = String.Format( "decimal( {0} )", valToStr );

        // Display the constructor and its value.
        Console.WriteLine( "{0,-35}{1,22}", ctor, decimalNum );
    }
    
    public static void Main( )
    {
        Console.WriteLine( "This example of the decimal( long ) " +
            "constructor \ngenerates the following output.\n" );
        Console.WriteLine( "{0,-35}{1,22}", "Constructor", "Value" );
        Console.WriteLine( "{0,-35}{1,22}", "-----------", "-----" );

        // Construct decimal objects from long values.
        CreateDecimal( long.MinValue, "long.MinValue" );
        CreateDecimal( long.MaxValue, "long.MaxValue" );
        CreateDecimal( 0L, "0L" );
        CreateDecimal( 999999999999999999, "999999999999999999" );
        CreateDecimal( 0x2000000000000000, "0x2000000000000000" );
        CreateDecimal( unchecked( (long)0xE000000000000000 ), 
            "(long)0xE000000000000000" );
    }
}

/*
This example of the decimal( long ) constructor
generates the following output.

Constructor                                         Value
-----------                                         -----
decimal( long.MinValue )             -9223372036854775808
decimal( long.MaxValue )              9223372036854775807
decimal( 0 )                                            0
decimal( 999999999999999999 )          999999999999999999
decimal( 0x2000000000000000 )         2305843009213693952
decimal( (long)0xE000000000000000 )  -2305843009213693952
*/
//</Snippet3>
