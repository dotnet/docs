// The following code example displays the value of MonthDayPattern for selected cultures.


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
      Console.WriteLine( "  {0}     {1}", myCulture, myDTFI.MonthDayPattern );

   }

}

/*
This code produces the following output.  The question marks take the place of native script characters.

 CULTURE    PROPERTY VALUE
  en-US     MMMM dd
  ja-JP     M'?'d'?'
  fr-FR     d MMMM

*/
// </snippet1>
