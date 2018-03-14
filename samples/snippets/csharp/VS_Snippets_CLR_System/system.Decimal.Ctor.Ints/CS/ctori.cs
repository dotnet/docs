//<Snippet1>
// Example of the decimal( int ) constructor.
using System;

class DecimalCtorIDemo
{
    // Create a decimal object and display its value.
    public static void CreateDecimal( int value, string valToStr )
    {
        decimal decimalNum = new decimal( value );

        // Format the constructor for display.
        string ctor = String.Format( "decimal( {0} )", valToStr );

        // Display the constructor and its value.
        Console.WriteLine( "{0,-30}{1,16}", ctor, decimalNum );
    }
    
    public static void Main( )
    {
        Console.WriteLine( "This example of the decimal( int ) " +
            "constructor \ngenerates the following output.\n" );
        Console.WriteLine( "{0,-30}{1,16}", "Constructor", "Value" );
        Console.WriteLine( "{0,-30}{1,16}", "-----------", "-----" );

        // Construct decimal objects from int values.
        CreateDecimal( int.MinValue, "int.MinValue" );
        CreateDecimal( int.MaxValue, "int.MaxValue" );
        CreateDecimal( 0, "0" );
        CreateDecimal( 999999999, "999999999" );
        CreateDecimal( 0x40000000, "0x40000000" );
        CreateDecimal( unchecked( (int)0xC0000000 ), 
            "(int)0xC0000000" );
    }
}

/*
This example of the decimal( int ) constructor
generates the following output.

Constructor                              Value
-----------                              -----
decimal( int.MinValue )            -2147483648
decimal( int.MaxValue )             2147483647
decimal( 0 )                                 0
decimal( 999999999 )                 999999999
decimal( 0x40000000 )               1073741824
decimal( (int)0xC0000000 )         -1073741824
*/
//</Snippet1>
