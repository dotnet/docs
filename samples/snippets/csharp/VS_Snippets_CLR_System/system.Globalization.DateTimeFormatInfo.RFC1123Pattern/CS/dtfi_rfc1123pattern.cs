// The following code example displays the value of RFC1123Pattern for selected cultures.


// <snippet1>
using System;
using System.Globalization;


public class SamplesDTFI  {

   public static void Main()  {

      // Displays the values of the pattern properties.
      Console.WriteLine( " CULTURE    PROPERTY VALUE" );
      PrintPattern( "en-US" );
      PrintPattern( "ja-JP" );
      PrintPattern( "fr-FR" );

   }

   public static void PrintPattern( String myCulture )  {

      DateTimeFormatInfo myDTFI = new CultureInfo( myCulture, false ).DateTimeFormat;
      Console.WriteLine( "  {0}     {1}", myCulture, myDTFI.RFC1123Pattern );

   }

}

/*
This code produces the following output.

 CULTURE    PROPERTY VALUE
  en-US     ddd, dd MMM yyyy HH':'mm':'ss 'GMT'
  ja-JP     ddd, dd MMM yyyy HH':'mm':'ss 'GMT'
  fr-FR     ddd, dd MMM yyyy HH':'mm':'ss 'GMT'

*/
// </snippet1>
