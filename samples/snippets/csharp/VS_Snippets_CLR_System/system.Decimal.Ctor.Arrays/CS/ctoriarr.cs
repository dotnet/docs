//<Snippet1>
// Example of the decimal( int[ ] ) constructor.
using System;

class DecimalCtorIArrDemo
{
    // Get the exception type name; remove the namespace prefix.
    public static string GetExceptionType( Exception ex )
    {
        string exceptionType = ex.GetType( ).ToString( );
        return exceptionType.Substring( 
            exceptionType.LastIndexOf( '.' ) + 1 );
    }

    // Create a decimal object and display its value.
    public static void CreateDecimal( int[ ] bits )
    {
        // Format the constructor for display.
        string ctor = String.Format( 
            "decimal( {{ 0x{0:X}", bits[ 0 ] );
        string valOrExc;
        
        for( int index = 1; index < bits.Length; index++ )
            ctor += String.Format( ", 0x{0:X}", bits[ index ] );
        ctor += " } )";

        try
        {
            // Construct the decimal value.
            decimal decimalNum = new decimal( bits );

            // Format the decimal value for display.
            valOrExc = decimalNum.ToString( );
        }
        catch( Exception ex )
        {
            // Save the exception type if an exception was thrown.
            valOrExc = GetExceptionType( ex );
        }

        // Display the constructor and decimal value or exception.
        int ctorLen = 76 - valOrExc.Length;

        // Display the data on one line if it will fit.
        if( ctorLen > ctor.Length )
            Console.WriteLine( "{0}{1}", ctor.PadRight( ctorLen ), 
                valOrExc );

        // Otherwise, display the data on two lines.
        else
        {
            Console.WriteLine( "{0}", ctor );
            Console.WriteLine( "{0,76}", valOrExc );
        }
    }
    
    public static void Main( )
    {
        Console.WriteLine( 
            "This example of the decimal( int[ ] ) constructor " +
            "\ngenerates the following output.\n" );
        Console.WriteLine( "{0,-38}{1,38}", "Constructor", 
            "Value or Exception" );
        Console.WriteLine( "{0,-38}{1,38}", "-----------", 
            "------------------" );

        // Construct decimal objects from integer arrays.
        CreateDecimal( new int[ ] { 0, 0, 0, 0 } );
        CreateDecimal( new int[ ] { 0, 0, 0 } );
        CreateDecimal( new int[ ] { 0, 0, 0, 0, 0 } );
        CreateDecimal( new int[ ] { 1000000000, 0, 0, 0 } );
        CreateDecimal( new int[ ] { 0, 1000000000, 0, 0 } );
        CreateDecimal( new int[ ] { 0, 0, 1000000000, 0 } );
        CreateDecimal( new int[ ] { 0, 0, 0, 1000000000 } );
        CreateDecimal( new int[ ] { -1, -1, -1, 0 } );
        CreateDecimal( new int[ ] 
            { -1, -1, -1, unchecked( (int)0x80000000 ) } );
        CreateDecimal( new int[ ] { -1, 0, 0, 0x100000 } );
        CreateDecimal( new int[ ] { -1, 0, 0, 0x1C0000 } );
        CreateDecimal( new int[ ] { -1, 0, 0, 0x1D0000 } );
        CreateDecimal( new int[ ] { -1, 0, 0, 0x1C0001 } );
        CreateDecimal( new int[ ] 
            { 0xF0000, 0xF0000, 0xF0000, 0xF0000 } );
    }
}

/*
This example of the decimal( int[ ] ) constructor
generates the following output.

Constructor                                               Value or Exception
-----------                                               ------------------
decimal( { 0x0, 0x0, 0x0, 0x0 } )                                          0
decimal( { 0x0, 0x0, 0x0 } )                               ArgumentException
decimal( { 0x0, 0x0, 0x0, 0x0, 0x0 } )                     ArgumentException
decimal( { 0x3B9ACA00, 0x0, 0x0, 0x0 } )                          1000000000
decimal( { 0x0, 0x3B9ACA00, 0x0, 0x0 } )                 4294967296000000000
decimal( { 0x0, 0x0, 0x3B9ACA00, 0x0 } )       18446744073709551616000000000
decimal( { 0x0, 0x0, 0x0, 0x3B9ACA00 } )                   ArgumentException
decimal( { 0xFFFFFFFF, 0xFFFFFFFF, 0xFFFFFFFF, 0x0 } )
                                               79228162514264337593543950335
decimal( { 0xFFFFFFFF, 0xFFFFFFFF, 0xFFFFFFFF, 0x80000000 } )
                                              -79228162514264337593543950335
decimal( { 0xFFFFFFFF, 0x0, 0x0, 0x100000 } )             0.0000004294967295
decimal( { 0xFFFFFFFF, 0x0, 0x0, 0x1C0000 } ) 0.0000000000000000004294967295
decimal( { 0xFFFFFFFF, 0x0, 0x0, 0x1D0000 } )              ArgumentException
decimal( { 0xFFFFFFFF, 0x0, 0x0, 0x1C0001 } )              ArgumentException
decimal( { 0xF0000, 0xF0000, 0xF0000, 0xF0000 } )
                                                 18133887298.441562272235520
*/
//</Snippet1>
