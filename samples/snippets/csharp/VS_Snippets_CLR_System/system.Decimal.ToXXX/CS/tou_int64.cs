//<Snippet1>
// Example of the decimal.ToInt64 and decimal.ToUInt64 methods.
using System;

class DecimalToU_Int64Demo
{
    const string formatter = "{0,25}{1,22}{2,22}";

    // Get the exception type name; remove the namespace prefix.
    public static string GetExceptionType( Exception ex )
    {
        string exceptionType = ex.GetType( ).ToString( );
        return exceptionType.Substring( 
            exceptionType.LastIndexOf( '.' ) + 1 );
    }

    // Convert the decimal argument; catch exceptions that are thrown.
    public static void DecimalToU_Int64( decimal argument )
    {
        object Int64Value;
        object UInt64Value;

        // Convert the argument to a long value.
        try
        {
            Int64Value = decimal.ToInt64( argument );
        }
        catch( Exception ex )
        {
            Int64Value = GetExceptionType( ex );
        }

        // Convert the argument to a ulong value.
        try
        {
            UInt64Value = decimal.ToUInt64( argument );
        }
        catch( Exception ex )
        {
            UInt64Value = GetExceptionType( ex );
        }

        Console.WriteLine( formatter, argument, 
            Int64Value, UInt64Value );
    }

    public static void Main( )
    {
        Console.WriteLine( "This example of the \n" +
            "  decimal.ToInt64( decimal ) and \n" +
            "  decimal.ToUInt64( decimal ) \nmethods " +
            "generates the following output. It \ndisplays " +
            "several converted decimal values.\n" );
        Console.WriteLine( formatter, "decimal argument", 
            "long/exception", "ulong/exception" );
        Console.WriteLine( formatter, "----------------", 
            "--------------", "---------------" );

        // Convert decimal values and display the results.
        DecimalToU_Int64( 123M );
        DecimalToU_Int64( new decimal( 123000, 0, 0, false, 3 ) );
        DecimalToU_Int64( 123.999M );
        DecimalToU_Int64( 18446744073709551615.999M );
        DecimalToU_Int64( 18446744073709551616M );
        DecimalToU_Int64( 9223372036854775807.999M );
        DecimalToU_Int64( 9223372036854775808M );
        DecimalToU_Int64( - 0.999M );
        DecimalToU_Int64( - 1M );
        DecimalToU_Int64( - 9223372036854775808.999M );
        DecimalToU_Int64( - 9223372036854775809M );
    }
}

/*
This example of the
  decimal.ToInt64( decimal ) and
  decimal.ToUInt64( decimal )
methods generates the following output. It
displays several converted decimal values.

         decimal argument        long/exception       ulong/exception
         ----------------        --------------       ---------------
                      123                   123                   123
                  123.000                   123                   123
                  123.999                   123                   123
 18446744073709551615.999     OverflowException  18446744073709551615
     18446744073709551616     OverflowException     OverflowException
  9223372036854775807.999   9223372036854775807   9223372036854775807
      9223372036854775808     OverflowException   9223372036854775808
                   -0.999                     0                     0
                       -1                    -1     OverflowException
 -9223372036854775808.999  -9223372036854775808     OverflowException
     -9223372036854775809     OverflowException     OverflowException
*/
//</Snippet1>
