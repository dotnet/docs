//<Snippet1>
// Example for the SByte.ToString( ) methods.
using System;
using System.Globalization;

public class SByteToStringDemo  
{
    static void RunToStringDemo( )
    {	
        SByte smallValue = -99;
        SByte largeValue = 123;

        // Format the SByte values without and with format strings.
        Console.WriteLine( "\nIFormatProvider is not used:" );
        Console.WriteLine( "   {0,-20}{1,10}{2,10}", 
            "No format string:", smallValue.ToString( ), 
            largeValue.ToString( ) );
        Console.WriteLine( "   {0,-20}{1,10}{2,10}", 
            "'X2' format string:", smallValue.ToString( "X2" ), 
            largeValue.ToString( "X2" ) );

        // Get the NumberFormatInfo object from the 
        // invariant culture.
        CultureInfo         culture = new CultureInfo( "" );
        NumberFormatInfo    numInfo = culture.NumberFormat;

        // Set decimal digits to 0. Set the negative pattern to ( ).
        numInfo.NumberDecimalDigits = 0;
        numInfo.NumberNegativePattern = 0;

        // Use the NumberFormatInfo object for an IFormatProvider.
        Console.WriteLine( "\nA NumberFormatInfo " +
            "object with negative pattern = ( ) and \nno " +
            "decimal digits is used for the IFormatProvider:" );
        Console.WriteLine( "   {0,-20}{1,10}{2,10}", 
            "No format string:", smallValue.ToString( numInfo ), 
            largeValue.ToString( numInfo ) );
        Console.WriteLine( "   {0,-20}{1,10}{2,10}", 
            "'N' format string:", 
            smallValue.ToString( "N", numInfo ), 
            largeValue.ToString( "N", numInfo ) );
    }

    static void Main( )
    {	
        Console.WriteLine( 
            "This example of\n   SByte.ToString( ),\n" +
            "   SByte.ToString( string ),\n" +
            "   SByte.ToString( IFormatProvider ), and\n" +
            "   SByte.ToString( string, IFormatProvider )\n" +
            "generates the following output when formatting " +
            "SByte values \nwith combinations of format " +
            "strings and IFormatProvider." );
    	
        RunToStringDemo( );
    } 
} 

/*
This example of
   SByte.ToString( ),
   SByte.ToString( string ),
   SByte.ToString( IFormatProvider ), and
   SByte.ToString( string, IFormatProvider )
generates the following output when formatting SByte values
with combinations of format strings and IFormatProvider.

IFormatProvider is not used:
   No format string:          -99       123
   'X2' format string:         9D        7B

A NumberFormatInfo object with negative pattern = ( ) and
no decimal digits is used for the IFormatProvider:
   No format string:          -99       123
   'N' format string:        (99)       123
*/
//</Snippet1>
