//<Snippet3>
// Example of the explicit conversions from decimal to short and 
// decimal to ushort.
using System;

class DecimalToU_Int16Demo
{
    const string formatter = "{0,16}{1,19}{2,19}";

    // Get the exception type name; remove the namespace prefix.
    public static string GetExceptionType( Exception ex )
    {
        string exceptionType = ex.GetType( ).ToString( );
        return exceptionType.Substring( 
            exceptionType.LastIndexOf( '.' ) + 1 );
    }

    // Convert the decimal argument; catch exceptions that are thrown.
    public static void DecimalToU_Int16( decimal argument )
    {
        object Int16Value;
        object UInt16Value;

        // Convert the argument to a short value.
        try
        {
            Int16Value = (short)argument;
        }
        catch( Exception ex )
        {
            Int16Value = GetExceptionType( ex );
        }

        // Convert the argument to a ushort value.
        try
        {
            UInt16Value = (ushort)argument;
        }
        catch( Exception ex )
        {
            UInt16Value = GetExceptionType( ex );
        }

        Console.WriteLine( formatter, argument, 
            Int16Value, UInt16Value );
    }

    public static void Main( )
    {
        Console.WriteLine( 
            "This example of the explicit conversions from decimal " +
            "to short \nand decimal to ushort generates the " +
            "following output. It displays \nseveral converted " +
            "decimal values.\n" );
        Console.WriteLine( formatter, "decimal argument", 
            "short/exception", "ushort/exception" );
        Console.WriteLine( formatter, "----------------", 
            "---------------", "----------------" );

        // Convert decimal values and display the results.
        DecimalToU_Int16( 123M );
        DecimalToU_Int16( new decimal( 123000, 0, 0, false, 3 ) );
        DecimalToU_Int16( 123.999M );
        DecimalToU_Int16( 65535.999M );
        DecimalToU_Int16( 65536M );
        DecimalToU_Int16( 32767.999M );
        DecimalToU_Int16( 32768M );
        DecimalToU_Int16( - 0.999M );
        DecimalToU_Int16( - 1M );
        DecimalToU_Int16( - 32768.999M );
        DecimalToU_Int16( - 32769M );
    }
}

/*
This example of the explicit conversions from decimal to short
and decimal to ushort generates the following output. It displays
several converted decimal values.

decimal argument    short/exception   ushort/exception
----------------    ---------------   ----------------
             123                123                123
         123.000                123                123
         123.999                123                123
       65535.999  OverflowException              65535
           65536  OverflowException  OverflowException
       32767.999              32767              32767
           32768  OverflowException              32768
          -0.999                  0                  0
              -1                 -1  OverflowException
      -32768.999             -32768  OverflowException
          -32769  OverflowException  OverflowException
*/
//</Snippet3>
