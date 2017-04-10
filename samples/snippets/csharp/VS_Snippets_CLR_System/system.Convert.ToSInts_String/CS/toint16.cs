//<Snippet3>
// Example of the Convert.ToInt16( string ) and 
// Convert.ToInt16( string, IFormatProvider ) methods.
using System;
using System.Globalization;

class ToInt16ProviderDemo
{
    static string format = "{0,-20}{1,-20}{2}";

     // Get the exception type name; remove the namespace prefix.
    static string GetExceptionType( Exception ex )
    {
        string exceptionType = ex.GetType( ).ToString( );
        return exceptionType.Substring( 
            exceptionType.LastIndexOf( '.' ) + 1 );
    }

    static void ConvertToInt16( string numericStr, 
        IFormatProvider provider )
    {
        object defaultValue;
        object providerValue;

        // Convert numericStr to Int16 without a format provider.
        try
        {
            defaultValue = Convert.ToInt16( numericStr );
        }
        catch( Exception ex )
        {
            defaultValue = GetExceptionType( ex );
        }

        // Convert numericStr to Int16 with a format provider.
        try
        {
            providerValue = Convert.ToInt16( numericStr, provider );
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
            "  Convert.ToInt16( string ) and \n" +
            "  Convert.ToInt16( string, IFormatProvider ) " +
            "\ngenerates the following output. It converts " +
            "several strings to \nshort values, using " +
            "default formatting or a NumberFormatInfo object.\n" );
        Console.WriteLine( format, "String to convert", 
            "Default/exception", "Provider/exception" );
        Console.WriteLine( format, "-----------------", 
            "-----------------", "------------------" );

        // Convert strings, with and without an IFormatProvider.
        ConvertToInt16( "12345", provider );
        ConvertToInt16( "+12345", provider );
        ConvertToInt16( "pos 12345", provider );
        ConvertToInt16( "-12345", provider );
        ConvertToInt16( "neg 12345", provider );
        ConvertToInt16( "12345.", provider );
        ConvertToInt16( "12,345", provider );
        ConvertToInt16( "(12345)", provider );
        ConvertToInt16( "32768", provider );
        ConvertToInt16( "-32769", provider );
    }
}

/*
This example of
  Convert.ToInt16( string ) and
  Convert.ToInt16( string, IFormatProvider )
generates the following output. It converts several strings to
short values, using default formatting or a NumberFormatInfo object.

String to convert   Default/exception   Provider/exception
-----------------   -----------------   ------------------
12345               12345               12345
+12345              12345               FormatException
pos 12345           FormatException     12345
-12345              -12345              FormatException
neg 12345           FormatException     -12345
12345.              FormatException     FormatException
12,345              FormatException     FormatException
(12345)             FormatException     FormatException
32768               OverflowException   OverflowException
-32769              OverflowException   FormatException
*/ 
//</Snippet3>
