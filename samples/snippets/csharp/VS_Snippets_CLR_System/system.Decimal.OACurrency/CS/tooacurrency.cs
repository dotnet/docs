//<Snippet1>
// Example of the decimal.ToOACurrency method. 
using System;

class DecimalToOACurrencyDemo
{
    const string dataFmt = "{0,31}{1,27}";

    // Get the exception type name; remove the namespace prefix.
    public static string GetExceptionType( Exception ex )
    {
        string exceptionType = ex.GetType( ).ToString( );
        return exceptionType.Substring( 
            exceptionType.LastIndexOf( '.' ) + 1 );
    }

    // Display the decimal.ToOACurrency parameter and the result 
    // or exception.
    public static void ShowDecimalToOACurrency( decimal Argument )
    {
        // Catch the exception if ToOACurrency( ) throws one.
        try
        {
            long oaCurrency = decimal.ToOACurrency( Argument );
            Console.WriteLine( dataFmt, Argument, oaCurrency );
        }
        catch( Exception ex )
        {
            Console.WriteLine( dataFmt, Argument, 
                GetExceptionType( ex ) );
        }
    }

    public static void Main( )
    {
        Console.WriteLine( "This example of the " +
            "decimal.ToOACurrency( ) method generates \nthe " +
            "following output. It displays the argument as a " +
            "decimal \nand the OLE Automation Currency value " +
            "as a long.\n" );
        Console.WriteLine( dataFmt, "Argument", 
            "OA Currency or Exception" );
        Console.WriteLine( dataFmt, "--------", 
            "------------------------" );

        // Convert decimal values to OLE Automation Currency values.
        ShowDecimalToOACurrency( 0M );
        ShowDecimalToOACurrency( 1M );
        ShowDecimalToOACurrency( 1.0000000000000000000000000000M );
        ShowDecimalToOACurrency( 100000000000000M );
        ShowDecimalToOACurrency( 100000000000000.00000000000000M );
        ShowDecimalToOACurrency( 10000000000000000000000000000M );
        ShowDecimalToOACurrency( 0.000000000123456789M );
        ShowDecimalToOACurrency( 0.123456789M );
        ShowDecimalToOACurrency( 123456789M );
        ShowDecimalToOACurrency( 123456789000000000M );
        ShowDecimalToOACurrency( 4294967295M );
        ShowDecimalToOACurrency( 18446744073709551615M );
        ShowDecimalToOACurrency( -79.228162514264337593543950335M );
        ShowDecimalToOACurrency( -79228162514264.337593543950335M );
    }
}

/*
This example of the decimal.ToOACurrency( ) method generates
the following output. It displays the argument as a decimal
and the OLE Automation Currency value as a long.

                       Argument   OA Currency or Exception
                       --------   ------------------------
                              0                          0
                              1                      10000
 1.0000000000000000000000000000                      10000
                100000000000000        1000000000000000000
 100000000000000.00000000000000        1000000000000000000
  10000000000000000000000000000          OverflowException
           0.000000000123456789                          0
                    0.123456789                       1235
                      123456789              1234567890000
             123456789000000000          OverflowException
                     4294967295             42949672950000
           18446744073709551615          OverflowException
-79.228162514264337593543950335                    -792282
-79228162514264.337593543950335        -792281625142643376
*/
//</Snippet1>
