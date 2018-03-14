//<Snippet4>
// Example of the decimal.ToSByte and decimal.ToByte methods.
using System;

class DecimalToS_ByteDemo
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
    public static void DecimalToS_Byte( decimal argument )
    {
        object SByteValue;
        object ByteValue;

        // Convert the argument to an sbyte value.
        try
        {
            SByteValue = decimal.ToSByte( argument );
        }
        catch( Exception ex )
        {
            SByteValue = GetExceptionType( ex );
        }

        // Convert the argument to a byte value.
        try
        {
            ByteValue = decimal.ToByte( argument );
        }
        catch( Exception ex )
        {
            ByteValue = GetExceptionType( ex );
        }

        Console.WriteLine( formatter, argument, 
            SByteValue, ByteValue );
    }

    public static void Main( )
    {
        Console.WriteLine( "This example of the \n" +
            "  decimal.ToSByte( decimal ) and \n" +
            "  decimal.ToByte( decimal ) \nmethods " +
            "generates the following output. It \ndisplays " +
            "several converted decimal values.\n" );
        Console.WriteLine( formatter, "decimal argument", 
            "sbyte/exception", "byte/exception" );
        Console.WriteLine( formatter, "----------------", 
            "---------------", "--------------" );

        // Convert decimal values and display the results.
        DecimalToS_Byte( 78M );
        DecimalToS_Byte( new decimal( 78000, 0, 0, false, 3 ) );
        DecimalToS_Byte( 78.999M );
        DecimalToS_Byte( 255.999M );
        DecimalToS_Byte( 256M );
        DecimalToS_Byte( 127.999M );
        DecimalToS_Byte( 128M );
        DecimalToS_Byte( -0.999M );
        DecimalToS_Byte( -1M );
        DecimalToS_Byte( -128.999M );
        DecimalToS_Byte( -129M );
    }
}

/*
This example of the
  decimal.ToSByte( decimal ) and
  decimal.ToByte( decimal )
methods generates the following output. It
displays several converted decimal values.

decimal argument    sbyte/exception     byte/exception
----------------    ---------------     --------------
              78                 78                 78
          78.000                 78                 78
          78.999                 78                 78
         255.999  OverflowException                255
             256  OverflowException  OverflowException
         127.999                127                127
             128  OverflowException                128
          -0.999                  0                  0
              -1                 -1  OverflowException
        -128.999               -128  OverflowException
            -129  OverflowException  OverflowException
*/
//</Snippet4>
