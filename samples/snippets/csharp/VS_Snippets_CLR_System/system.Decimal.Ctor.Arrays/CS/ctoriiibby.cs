//<Snippet2>
// Example of the decimal( int, int, int, bool, byte ) constructor.
using System;

class DecimalCtorIIIBByDemo
{
    // Get the exception type name; remove the namespace prefix.
    public static string GetExceptionType( Exception ex )
    {
        string exceptionType = ex.GetType( ).ToString( );
        return exceptionType.Substring( 
            exceptionType.LastIndexOf( '.' ) + 1 );
    }

    // Create a decimal object and display its value.
    public static void CreateDecimal( int low, int mid, int high, 
        bool isNeg, byte scale )
    {
        // Format the constructor for display.
        string ctor = String.Format( 
            "decimal( {0}, {1}, {2}, {3}, {4} )", 
            low, mid, high, isNeg, scale );
        string valOrExc;

        try
        {
            // Construct the decimal value.
            decimal decimalNum = new decimal( 
                low, mid, high, isNeg, scale );

            // Format and save the decimal value.
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
        if ( ctorLen > ctor.Length )
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

        Console.WriteLine( "This example of the decimal( int, int, " +
            "int, bool, byte ) \nconstructor " +
            "generates the following output.\n" );
        Console.WriteLine( "{0,-38}{1,38}", "Constructor", 
            "Value or Exception" );
        Console.WriteLine( "{0,-38}{1,38}", "-----------", 
            "------------------" );

        // Construct decimal objects from the component fields.
        CreateDecimal( 0, 0, 0, false, 0 );
        CreateDecimal( 0, 0, 0, false, 27 );
        CreateDecimal( 0, 0, 0, true, 0 );
        CreateDecimal( 1000000000, 0, 0, false, 0 );
        CreateDecimal( 0, 1000000000, 0, false, 0 );
        CreateDecimal( 0, 0, 1000000000, false, 0 );
        CreateDecimal( 1000000000, 1000000000, 1000000000, false, 0 );
        CreateDecimal( -1, -1, -1, false, 0 );
        CreateDecimal( -1, -1, -1, true, 0 );
        CreateDecimal( -1, -1, -1, false, 15 );
        CreateDecimal( -1, -1, -1, false, 28 );
        CreateDecimal( -1, -1, -1, false, 29 );
        CreateDecimal( int.MaxValue, 0, 0, false, 18 );
        CreateDecimal( int.MaxValue, 0, 0, false, 28 );
        CreateDecimal( int.MaxValue, 0, 0, true, 28 );
    }
}

/*
This example of the decimal( int, int, int, bool, byte )
constructor generates the following output.

Constructor                                               Value or Exception
-----------                                               ------------------
decimal( 0, 0, 0, False, 0 )                                               0
decimal( 0, 0, 0, False, 27 )                                              0
decimal( 0, 0, 0, True, 0 )                                                0
decimal( 1000000000, 0, 0, False, 0 )                             1000000000
decimal( 0, 1000000000, 0, False, 0 )                    4294967296000000000
decimal( 0, 0, 1000000000, False, 0 )          18446744073709551616000000000
decimal( 1000000000, 1000000000, 1000000000, False, 0 )
                                               18446744078004518913000000000
decimal( -1, -1, -1, False, 0 )                79228162514264337593543950335
decimal( -1, -1, -1, True, 0 )                -79228162514264337593543950335
decimal( -1, -1, -1, False, 15 )              79228162514264.337593543950335
decimal( -1, -1, -1, False, 28 )              7.9228162514264337593543950335
decimal( -1, -1, -1, False, 29 )                 ArgumentOutOfRangeException
decimal( 2147483647, 0, 0, False, 18 )                  0.000000002147483647
decimal( 2147483647, 0, 0, False, 28 )        0.0000000000000000002147483647
decimal( 2147483647, 0, 0, True, 28 )        -0.0000000000000000002147483647
*/
//</Snippet2>
