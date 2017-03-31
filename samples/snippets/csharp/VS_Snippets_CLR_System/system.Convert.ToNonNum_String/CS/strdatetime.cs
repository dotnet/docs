//<Snippet1>
// Example of Convert.ToDateTime( String, IFormatProvider ).
using System;
using System.Globalization;

class StringToDateTimeDemo
{
    const string lineFmt = "{0,-18}{1,-12}{2}";
    
    // Get the exception type name; remove the namespace prefix.
    public static string GetExceptionType( Exception ex )
    {
        string exceptionType = ex.GetType( ).ToString( );
        return exceptionType.Substring( 
            exceptionType.LastIndexOf( '.' ) + 1 );
    }

    public static void StringToDateTime( string cultureName )
    {
        string[ ] dateStrings = {         "01/02/03", 
            "2001/02/03",  "01/2002/03",  "01/02/2003", 
            "21/02/03",    "01/22/03",    "01/02/23" };
        CultureInfo culture = new CultureInfo( cultureName );
            
        Console.WriteLine( );

        // Convert each string in the dateStrings array.
        foreach( string dateStr in dateStrings )
        {
            DateTime dateTimeValue;

            // Display the first part of the output line.
            Console.Write( lineFmt, dateStr, cultureName, null );

            try
            {
                // Convert the string to a DateTime object.
                dateTimeValue = Convert.ToDateTime( dateStr, culture );

                // Display the DateTime object in a fixed format 
                // if Convert succeeded.
                Console.WriteLine( "{0:yyyy-MMM-dd}", dateTimeValue );
            }
            catch( Exception ex )
            {
                // Display the exception type if Parse failed.
                Console.WriteLine( "{0}", GetExceptionType( ex ) );
            }
        }
    }
    
    public static void Main( )
    {
        Console.WriteLine( "This example of " +
            "Convert.ToDateTime( String, IFormatProvider ) " +
            "\ngenerates the following output. Several strings are " +
            "converted \nto DateTime objects using formatting " +
            "information from different \ncultures, and then the " +
            "strings are displayed in a \nculture-invariant form.\n" );
        Console.WriteLine( lineFmt, "Date String", "Culture", 
            "DateTime or Exception" );
        Console.WriteLine( lineFmt, "-----------", "-------", 
            "---------------------" );

        StringToDateTime( "en-US" );
        StringToDateTime( "ru-RU" );
        StringToDateTime( "ja-JP" );
    }
}

/*
This example of Convert.ToDateTime( String, IFormatProvider )
generates the following output. Several strings are converted
to DateTime objects using formatting information from different
cultures, and then the strings are displayed in a
culture-invariant form.

Date String       Culture     DateTime or Exception
-----------       -------     ---------------------

01/02/03          en-US       2003-Jan-02
2001/02/03        en-US       2001-Feb-03
01/2002/03        en-US       2002-Jan-03
01/02/2003        en-US       2003-Jan-02
21/02/03          en-US       FormatException
01/22/03          en-US       2003-Jan-22
01/02/23          en-US       2023-Jan-02

01/02/03          ru-RU       2003-Feb-01
2001/02/03        ru-RU       2001-Feb-03
01/2002/03        ru-RU       2002-Jan-03
01/02/2003        ru-RU       2003-Feb-01
21/02/03          ru-RU       2003-Feb-21
01/22/03          ru-RU       FormatException
01/02/23          ru-RU       2023-Feb-01

01/02/03          ja-JP       2001-Feb-03
2001/02/03        ja-JP       2001-Feb-03
01/2002/03        ja-JP       2002-Jan-03
01/02/2003        ja-JP       2003-Jan-02
21/02/03          ja-JP       2021-Feb-03
01/22/03          ja-JP       FormatException
01/02/23          ja-JP       2001-Feb-23
*/
//</Snippet1>
