//<Snippet4>
// Example of the decimal( ulong ) constructor.
using System;

class DecimalCtorLDemo
{
    // Create a decimal object and display its value.
    public static void CreateDecimal( ulong value, string valToStr )
    {
        decimal decimalNum = new decimal( value );

        // Format the constructor for display.
        string ctor = String.Format( "decimal( {0} )", valToStr );

        // Display the constructor and its value.
        Console.WriteLine( "{0,-35}{1,22}", ctor, decimalNum );
    }
    
    public static void Main( )
    {
        Console.WriteLine( "This example of the decimal( ulong ) " +
            "constructor \ngenerates the following output.\n" );
        Console.WriteLine( "{0,-35}{1,22}", "Constructor", "Value" );
        Console.WriteLine( "{0,-35}{1,22}", "-----------", "-----" );

        // Construct decimal objects from ulong values.
        CreateDecimal( ulong.MinValue, "ulong.MinValue" );
        CreateDecimal( ulong.MaxValue, "ulong.MaxValue" );
        CreateDecimal( long.MaxValue, "long.MaxValue" );
        CreateDecimal( 999999999999999999, "999999999999999999" );
        CreateDecimal( 0x2000000000000000, "0x2000000000000000" );
        CreateDecimal( 0xE000000000000000, "0xE000000000000000" );
    }
}

/*
This example of the decimal( ulong ) constructor
generates the following output.

Constructor                                         Value
-----------                                         -----
decimal( ulong.MinValue )                               0
decimal( ulong.MaxValue )            18446744073709551615
decimal( long.MaxValue )              9223372036854775807
decimal( 999999999999999999 )          999999999999999999
decimal( 0x2000000000000000 )         2305843009213693952
decimal( 0xE000000000000000 )        16140901064495857664
*/
//</Snippet4>
