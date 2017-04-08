// <Snippet3>
using System;
using System.Globalization;
using System.IO;

public class Example
{
   public static void Main()
   {
      DateTime date1 = new DateTime(2011, 8, 7);
      CultureInfo ci = CultureInfo.CreateSpecificCulture("ar-SY");
      StreamWriter sw = new StreamWriter(@".\arSYCalendars.txt"); 

      sw.WriteLine("{0,-32} {1,-21} {2}\n", 
                   "Calendar", "Long Date Pattern", "Example Date");
      foreach (var cal in ci.OptionalCalendars) {
         ci.DateTimeFormat.Calendar = cal;
         sw.WriteLine("{0,-32} {1,-21} {2}", GetCalendarName(cal), 
                                             ci.DateTimeFormat.LongDatePattern,
                                             date1.ToString("D", ci));
      }     
      sw.Close();
   }

   private static string GetCalendarName(Calendar cal)
   {
      string calName;
      calName = cal.GetType().Name.Substring(0, cal.GetType().Name.IndexOf("Cal"));
      if (calName.Equals("Gregorian")) {
         GregorianCalendar grCal = cal as GregorianCalendar;
         calName += String.Format("-{0}", grCal.CalendarType);    
      }
      return calName;
   }
}
// The example generates the following output:
//    Calendar                         Long Date Pattern     Example Date
//    
//    Gregorian-Localized              dd MMMM, yyyy         07 آب, 2011
//    UmAlQura                         dd/MMMM/yyyy          07/رمضان/1432
//    Hijri                            dd/MM/yyyy            08/09/1432
//    Gregorian-USEnglish              dddd, MMMM dd, yyyy   Sunday, August 07, 2011
//    Gregorian-MiddleEastFrench       dddd, MMMM dd, yyyy   dimanche, août 07, 2011
//    Gregorian-TransliteratedEnglish  dddd, MMMM dd, yyyy   الأحد, أغسطس 07, 2011
//    Gregorian-TransliteratedFrench   dddd, MMMM dd, yyyy   الأحد, أوت 07, 2011
// </Snippet3>
