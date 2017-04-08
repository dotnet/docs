// The following code example demonstrates how to determine the GregorianCalendar version supported by the culture.


// <snippet1>
using System;
using System.Globalization;


public class SamplesCultureInfo  {

   public static void Main()  {

      // Gets the calendars supported by the ar-SA culture.
      Calendar[] myOptCals = new CultureInfo("ar-SA").OptionalCalendars;

      // Checks which ones are GregorianCalendar then determines the GregorianCalendar version.
      Console.WriteLine( "The ar-SA culture supports the following calendars:" );
      foreach ( Calendar cal in myOptCals )  {
         if ( cal.GetType() == typeof( GregorianCalendar ) )  {
            GregorianCalendar myGreCal = (GregorianCalendar) cal;
            GregorianCalendarTypes calType = myGreCal.CalendarType;
            Console.WriteLine( "   {0} ({1})", cal, calType );
         }
         else  {
            Console.WriteLine( "   {0}", cal );
         }
      }

   }

}

/*
This code produces the following output.

The ar-SA culture supports the following calendars:
   System.Globalization.HijriCalendar
   System.Globalization.GregorianCalendar (USEnglish)
   System.Globalization.GregorianCalendar (MiddleEastFrench)
   System.Globalization.GregorianCalendar (Arabic)
   System.Globalization.GregorianCalendar (Localized)
   System.Globalization.GregorianCalendar (TransliteratedFrench)

*/
// </snippet1>

