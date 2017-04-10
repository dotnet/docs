// <Snippet1>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      CultureInfo ci = CultureInfo.CreateSpecificCulture("ar-EG");
      Console.WriteLine("The current calendar for the {0} culture is {1}",
                        ci.Name, 
                        CalendarUtilities.ShowCalendarName(ci.DateTimeFormat.Calendar));

      CalendarUtilities.ChangeCalendar(ci, new JapaneseCalendar());
      Console.WriteLine("The current calendar for the {0} culture is {1}",
                        ci.Name, 
                        CalendarUtilities.ShowCalendarName(ci.DateTimeFormat.Calendar));
      
      CalendarUtilities.ChangeCalendar(ci, new UmAlQuraCalendar());
      Console.WriteLine("The current calendar for the {0} culture is {1}",
                        ci.Name, 
                        CalendarUtilities.ShowCalendarName(ci.DateTimeFormat.Calendar));
   }
}

public class CalendarUtilities
{
   private Calendar newCal;
   private bool isGregorian;
   
   public static void ChangeCalendar(CultureInfo ci, Calendar cal)
   {
      CalendarUtilities util = new CalendarUtilities(cal);
      
      // Is the new calendar already the current calendar?
      if (util.CalendarExists(ci.DateTimeFormat.Calendar))
         return;

      // Is the new calendar supported?
      if (Array.Exists(ci.OptionalCalendars, util.CalendarExists))
         ci.DateTimeFormat.Calendar = cal;
   }
   
   private CalendarUtilities(Calendar cal)
   {
      newCal = cal;
      
      // Is the new calendar a Gregorian calendar?
      isGregorian = cal.GetType().Name.Contains("Gregorian");
   }
   
   private bool CalendarExists(Calendar cal)
   {
      if (cal.ToString() == newCal.ToString()) {
         if (isGregorian) {
            if (((GregorianCalendar) cal).CalendarType == 
               ((GregorianCalendar) newCal).CalendarType)
               return true;
         }
         else {
            return true;
         }
      }
      return false;
   }

   public static string ShowCalendarName(Calendar cal)
   {
      string calName = cal.ToString().Replace("System.Globalization.", "");
      if (cal is GregorianCalendar)
         calName += ", Type " + ((GregorianCalendar) cal).CalendarType.ToString();

      return calName; 
   }
}
// The example displays the following output:
//    The current calendar for the ar-EG culture is GregorianCalendar, Type Localized
//    The current calendar for the ar-EG culture is GregorianCalendar, Type Localized
//    The current calendar for the ar-EG culture is UmAlQuraCalendar
// </Snippet1>
