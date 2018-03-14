// The following code example prints a DateTime using a GregorianCalendar that is localized.


// <snippet1>
using System;
using System.Globalization;


public class SamplesGregorianCalendar  {

   public static void Main()  {

      // Creates and initializes four different CultureInfo objects.
      CultureInfo myCIdeDE = new CultureInfo("de-DE", false);
      CultureInfo myCIenUS = new CultureInfo("en-US", false);
      CultureInfo myCIfrFR = new CultureInfo("fr-FR", false);
      CultureInfo myCIruRU = new CultureInfo("ru-RU", false);

      // Creates a Localized GregorianCalendar.
      // GregorianCalendarTypes.Localized is the default when using the GregorianCalendar constructor without parameters.
      Calendar myCal = new GregorianCalendar();

      // Sets the DateTimeFormatInfo.Calendar property to a Localized GregorianCalendar.
      // Localized GregorianCalendar is the default calendar for de-DE, en-US, and fr-FR,
      myCIruRU.DateTimeFormat.Calendar = myCal;

      // Creates a DateTime.
      DateTime myDT = new DateTime( 2002, 1, 3, 13, 30, 45 );

      // Displays the DateTime.
      Console.WriteLine( "de-DE: {0}", myDT.ToString( "F", myCIdeDE ) );
      Console.WriteLine( "en-US: {0}", myDT.ToString( "F", myCIenUS ) );
      Console.WriteLine( "fr-FR: {0}", myDT.ToString( "F", myCIfrFR ) );
      Console.WriteLine( "ru-RU: {0}", myDT.ToString( "F", myCIruRU ) );
   }
}
/*
The example displays the following output:
   de-DE: Donnerstag, 3. Januar 2002 13:30:45
   en-US: Thursday, January 03, 2002 1:30:45 PM
   fr-FR: jeudi 3 janvier 2002 13:30:45
   ru-RU: 3 января 2002 г. 13:30:45
*/
// </snippet1>
