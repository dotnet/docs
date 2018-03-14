//<Snippet1>
// Example of the Convert.ToString( DateTime ) and 
// Convert.ToString( DateTime, IFormatProvider ) methods.
using System;
using System.Globalization;

class DateTimeIFormatProviderDemo
{
    static void DisplayDateNCultureName( DateTime testDate, 
        string cultureName )
    {
        // Create the CultureInfo object for the specified culture,
        // and use it as the IFormatProvider when converting the date.
        CultureInfo culture = new CultureInfo( cultureName );
        string      dateString = Convert.ToString( testDate, culture );

        // Bracket the culture name, and display the name and date.
        Console.WriteLine("   {0,-12}{1}", 
            String.Concat( "[", cultureName, "]" ), dateString );
    }

    static void Main( )
    {
        // Specify the date to be formatted under various cultures.
        DateTime tDate = new DateTime( 2003, 4, 15, 20, 30, 40, 333 );

        Console.WriteLine( "This example of \n" +
            "   Convert.ToString( DateTime ) and \n" +
            "   Convert.ToString( DateTime, IFormatProvider )\n" +
            "generates the following output. It creates " +
            "CultureInfo objects \nfor several cultures " +
            "and formats a DateTime value with each.\n" );

        // Format the date without an IFormatProvider.
        Console.WriteLine( "   {0,-12}{1}", 
            null, "No IFormatProvider" );
        Console.WriteLine( "   {0,-12}{1}", 
            null, "------------------" );
        Console.WriteLine( "   {0,-12}{1}\n", 
            String.Concat( "[", CultureInfo.CurrentCulture.Name, "]" ), 
            Convert.ToString( tDate ) );

        // Format the date with IFormatProvider for several cultures.
        Console.WriteLine( "   {0,-12}{1}", 
            "Culture", "With IFormatProvider" );
        Console.WriteLine( "   {0,-12}{1}", 
            "-------", "--------------------" );
        
        DisplayDateNCultureName( tDate, "" );
        DisplayDateNCultureName( tDate, "en-US" );
        DisplayDateNCultureName( tDate, "es-AR" );
        DisplayDateNCultureName( tDate, "fr-FR" );
        DisplayDateNCultureName( tDate, "hi-IN" );
        DisplayDateNCultureName( tDate, "ja-JP" );
        DisplayDateNCultureName( tDate, "nl-NL" );
        DisplayDateNCultureName( tDate, "ru-RU" );
        DisplayDateNCultureName( tDate, "ur-PK" );
    }
}

/*
This example of
   Convert.ToString( DateTime ) and
   Convert.ToString( DateTime, IFormatProvider )
generates the following output. It creates CultureInfo objects
for several cultures and formats a DateTime value with each.

               No IFormatProvider
               ------------------
   [en-US]     4/15/2003 8:30:40 PM

   Culture     With IFormatProvider
   -------     --------------------
   []          04/15/2003 20:30:40
   [en-US]     4/15/2003 8:30:40 PM
   [es-AR]     15/04/2003 08:30:40 p.m.
   [fr-FR]     15/04/2003 20:30:40
   [hi-IN]     15-04-2003 20:30:40
   [ja-JP]     2003/04/15 20:30:40
   [nl-NL]     15-4-2003 20:30:40
   [ru-RU]     15.04.2003 20:30:40
   [ur-PK]     15/04/2003 8:30:40 PM
*/ 
//</Snippet1>
