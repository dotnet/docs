//<Snippet2>
// Example of the explicit conversions from decimal to int and 
// decimal to uint.
using System;

class DecimalToU_Int32Demo
{
    const string formatter = "{0,17}{1,19}{2,19}";

    // Get the exception type name; remove the namespace prefix.
    public static string GetExceptionType( Exception ex )
    {
        string exceptionType = ex.GetType( ).ToString( );
        return exceptionType.Substring( 
            exceptionType.LastIndexOf( '.' ) + 1 );
    }

    // Convert the decimal argument; catch exceptions that are thrown.
    public static void DecimalToU_Int32( decimal argument )
    {
        object Int32Value;
        object UInt32Value;

        // Convert the argument to an int value.
        try
        {
            Int32Value = (int)argument;
        }
        catch( Exception ex )
        {
            Int32Value = GetExceptionType( ex );
        }

        // Convert the argument to a uint value.
        try
        {
            UInt32Value = (uint)argument;
        }
        catch( Exception ex )
        {
            UInt32Value = GetExceptionType( ex );
        }

        Console.WriteLine( formatter, argument, 
            Int32Value, UInt32Value );
    }

    public static void Main( )
    {
        Console.WriteLine( 
            "This example of the explicit conversions from decimal " +
            "to int \nand decimal to uint generates the following " +
            "output. It displays \nseveral converted decimal " +
            "values.\n" );
        Console.WriteLine( formatter, "decimal argument", 
            "int/exception", "uint/exception" );
        Console.WriteLine( formatter, "----------------", 
            "-------------", "--------------" );

        // Convert decimal values and display the results.
        DecimalToU_Int32( 123M );
        DecimalToU_Int32( new decimal( 123000, 0, 0, false, 3 ) );
        DecimalToU_Int32( 123.999M );
        DecimalToU_Int32( 4294967295.999M );
        DecimalToU_Int32( 4294967296M );
        DecimalToU_Int32( 2147483647.999M );
        DecimalToU_Int32( 2147483648M );
        DecimalToU_Int32( - 0.999M );
        DecimalToU_Int32( - 1M );
        DecimalToU_Int32( - 2147483648.999M );
        DecimalToU_Int32( - 2147483649M );
    }
}

/*
This example of the explicit conversions from decimal to int
and decimal to uint generates the following output. It displays
several converted decimal values.

 decimal argument      int/exception     uint/exception
 ----------------      -------------     --------------
              123                123                123
          123.000                123                123
          123.999                123                123
   4294967295.999  OverflowException         4294967295
       4294967296  OverflowException  OverflowException
   2147483647.999         2147483647         2147483647
       2147483648  OverflowException         2147483648
           -0.999                  0                  0
               -1                 -1  OverflowException
  -2147483648.999        -2147483648  OverflowException
      -2147483649  OverflowException  OverflowException
*/
//</Snippet2>
