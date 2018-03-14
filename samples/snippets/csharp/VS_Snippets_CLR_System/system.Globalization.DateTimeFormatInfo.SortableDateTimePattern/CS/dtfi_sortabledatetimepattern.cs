// The following code example displays the value of SortableDateTimePattern for selected cultures.


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
      Console.WriteLine( "  {0}     {1}", myCulture, myDTFI.SortableDateTimePattern );

   }

}

/*
This code produces the following output.

 CULTURE    PROPERTY VALUE
  en-US     yyyy'-'MM'-'dd'T'HH':'mm':'ss
  ja-JP     yyyy'-'MM'-'dd'T'HH':'mm':'ss
  fr-FR     yyyy'-'MM'-'dd'T'HH':'mm':'ss

*/
// </snippet1>
