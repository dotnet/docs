//<Snippet2>
// Example of the Convert.ToInt32( string ) and 
// Convert.ToInt32( string, IFormatProvider ) methods.
using System;
using System.Globalization;

class ToInt32ProviderDemo
{
    static string format = "{0,-20}{1,-20}{2}";

     // Get the exception type name; remove the namespace prefix.
    static string GetExceptionType( Exception ex )
    {
        string exceptionType = ex.GetType( ).ToString( );
        return exceptionType.Substring( 
            exceptionType.LastIndexOf( '.' ) + 1 );
    }

    static void ConvertToInt32( string numericStr, 
        IFormatProvider provider )
    {
        object defaultValue;
        object providerValue;

        // Convert numericStr to Int32 without a format provider.
        try
        {
            defaultValue = Convert.ToInt32( numericStr );
        }
        catch( Exception ex )
        {
            defaultValue = GetExceptionType( ex );
        }

        // Convert numericStr to Int32 with a format provider.
        try
        {
            providerValue = Convert.ToInt32( numericStr, provider );
        }
        catch( Exception ex )
        {
            providerValue = GetExceptionType( ex );
        }

        Console.WriteLine( format, numericStr, 
            defaultValue, providerValue );
    }

    public static void Main( )
    {
        // Create a NumberFormatInfo object and set several of its
        // properties that apply to numbers.
        NumberFormatInfo provider = new NumberFormatInfo();

        // These properties affect the conversion.
        provider.NegativeSign = "neg ";
        provider.PositiveSign = "pos ";

        // These properties do not affect the conversion.
        // The input string cannot have decimal and group separators.
        provider.NumberDecimalSeparator = ".";
        provider.NumberGroupSeparator = ",";
        provider.NumberGroupSizes = new int[ ] { 3 };
        provider.NumberNegativePattern = 0;

        Console.WriteLine("This example of\n" +
            "  Convert.ToInt32( string ) and \n" +
            "  Convert.ToInt32( string, IFormatProvider ) " +
            "\ngenerates the following output. It converts " +
            "several strings to \nint values, using " +
            "default formatting or a NumberFormatInfo object.\n" );
        Console.WriteLine( format, "String to convert", 
            "Default/exception", "Provider/exception" );
        Console.WriteLine( format, "-----------------", 
            "-----------------", "------------------" );

        // Convert strings, with and without an IFormatProvider.
        ConvertToInt32( "123456789", provider );
        ConvertToInt32( "+123456789", provider );
        ConvertToInt32( "pos 123456789", provider );
        ConvertToInt32( "-123456789", provider );
        ConvertToInt32( "neg 123456789", provider );
        ConvertToInt32( "123456789.", provider );
        ConvertToInt32( "123,456,789", provider );
        ConvertToInt32( "(123456789)", provider );
        ConvertToInt32( "2147483648", provider );
        ConvertToInt32( "-2147483649", provider );
    }
}

/*
This example of
  Convert.ToInt32( string ) and
  Convert.ToInt32( string, IFormatProvider )
generates the following output. It converts several strings to
int values, using default formatting or a NumberFormatInfo object.

String to convert   Default/exception   Provider/exception
-----------------   -----------------   ------------------
123456789           123456789           123456789
+123456789          123456789           FormatException
pos 123456789       FormatException     123456789
-123456789          -123456789          FormatException
neg 123456789       FormatException     -123456789
123456789.          FormatException     FormatException
123,456,789         FormatException     FormatException
(123456789)         FormatException     FormatException
2147483648          OverflowException   OverflowException
-2147483649         OverflowException   FormatException
*/ 
//</Snippet2>
