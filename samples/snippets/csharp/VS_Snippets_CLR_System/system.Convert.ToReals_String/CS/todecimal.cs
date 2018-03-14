//<Snippet1>
// Example of the Convert.ToDecimal( String ) and 
// Convert.ToDecimal( String, IFormatProvider ) methods.
using System;
using System.Globalization;

class ToDecimalProviderDemo
{
    static string formatter = "{0,-22}{1,-20}{2}";

    // Get the exception type name; remove the namespace prefix.
    static string GetExceptionType( Exception ex )
    {
        string exceptionType = ex.GetType( ).ToString( );
        return exceptionType.Substring( 
            exceptionType.LastIndexOf( '.' ) + 1 );
    }

    static void ConvertToDecimal( string numericStr, 
        IFormatProvider provider )
    {
        object defaultValue;
        object providerValue;

        // Convert numericStr to decimal without a format provider.
        try
        {
            defaultValue = Convert.ToDecimal( numericStr );
        }
        catch( Exception ex )
        {
            defaultValue = GetExceptionType( ex );
        }

        // Convert numericStr to decimal with a format provider.
        try
        {
            providerValue = Convert.ToDecimal( numericStr, provider );
        }
        catch( Exception ex )
        {
            providerValue = GetExceptionType( ex );
        }

        Console.WriteLine( formatter, numericStr, defaultValue, 
            providerValue );
    }

    static void Main( )
    {
        // Create a NumberFormatInfo object and set several of its
        // properties that apply to numbers.
        NumberFormatInfo provider = new NumberFormatInfo( );

        provider.NumberDecimalSeparator = ",";
        provider.NumberGroupSeparator = ".";
        provider.NumberGroupSizes = new int[ ] { 3 };

        Console.WriteLine( 
            "This example of\n  Convert.ToDecimal( String ) and \n" +
            "  Convert.ToDecimal( String, IFormatProvider ) \n" +
            "generates the following output when run in the " +
            "[{0}] culture.", 
            CultureInfo.CurrentCulture.Name );
        Console.WriteLine( "\nSeveral " +
            "strings are converted to decimal values, using \n" +
            "default formatting and a NumberFormatInfo object.\n");
        Console.WriteLine( formatter, "String to convert", 
            "Default/exception", "Provider/exception" );
        Console.WriteLine( formatter, "-----------------", 
            "-----------------", "------------------" );

        // Convert strings, with and without an IFormatProvider.
        ConvertToDecimal( "123456789", provider );
        ConvertToDecimal( "12345.6789", provider );
        ConvertToDecimal( "12345,6789", provider );
        ConvertToDecimal( "123,456.789", provider );
        ConvertToDecimal( "123.456,789", provider );
        ConvertToDecimal( "123,456,789.0123", provider );
        ConvertToDecimal( "123.456.789,0123", provider );
    }
}

/*
This example of
  Convert.ToDecimal( String ) and
  Convert.ToDecimal( String, IFormatProvider )
generates the following output when run in the [en-US] culture.

Several strings are converted to decimal values, using
default formatting and a NumberFormatInfo object.

String to convert     Default/exception   Provider/exception
-----------------     -----------------   ------------------
123456789             123456789           123456789
12345.6789            12345.6789          123456789
12345,6789            123456789           12345.6789
123,456.789           123456.789          FormatException
123.456,789           FormatException     123456.789
123,456,789.0123      123456789.0123      FormatException
123.456.789,0123      FormatException     123456789.0123
*/
//</Snippet1>
