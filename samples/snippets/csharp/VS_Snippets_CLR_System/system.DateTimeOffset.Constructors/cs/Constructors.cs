using System;
using System.Globalization;

public class Class1
{
   public static void Main()
   {
      ConstructWithDateTime();
      Console.WriteLine();
      ConstructWithTicks();
      Console.WriteLine();
      ConstructWithDateAndOffset();
      Console.WriteLine();
      ConstructNonLocalWithLocalTicks();
      Console.WriteLine();
      ConstructWithDateElements();
      Console.WriteLine();
      ConstructWithDateElements2();
      Console.WriteLine();
      ConstructWithDateElements3();
      Console.WriteLine();
      ConstructWithCalendar();
   }

   private static void ConstructWithDateTime()
   {
      // <Snippet1>
      DateTime localNow = DateTime.Now;
      DateTimeOffset localOffset = new DateTimeOffset(localNow);
      Console.WriteLine(localOffset.ToString());
      
      DateTime utcNow = DateTime.UtcNow;
      DateTimeOffset utcOffset = new DateTimeOffset(utcNow);
      Console.WriteLine(utcOffset.ToString());
      
      DateTime unspecifiedNow = DateTime.SpecifyKind(DateTime.Now, 
                                     DateTimeKind.Unspecified);
      DateTimeOffset unspecifiedOffset = new DateTimeOffset(unspecifiedNow);
      Console.WriteLine(unspecifiedOffset.ToString());
      //
      // The code produces the following output if run on Feb. 23, 2007, on
      // a system 8 hours earlier than UTC:
      //   2/23/2007 4:21:58 PM -08:00
      //   2/24/2007 12:21:58 AM +00:00
      //   2/23/2007 4:21:58 PM -08:00      
      // </Snippet1> 
   }

   private static void ConstructWithTicks()
   {
      // <Snippet2>
      DateTime dateWithoutOffset = new DateTime(2007, 7, 16, 13, 32, 00);
      DateTimeOffset timeFromTicks = new DateTimeOffset(dateWithoutOffset.Ticks, 
                                     new TimeSpan(-5, 0, 0));
      Console.WriteLine(timeFromTicks.ToString());
      // The code produces the following output:
      //    7/16/2007 1:32:00 PM -05:00
      // </Snippet2>
   }
   
   private static void ConstructWithDateAndOffset()
   {
      // <Snippet3>
      DateTime localTime = new DateTime(2007, 07, 12, 06, 32, 00); 
      DateTimeOffset dateAndOffset = new DateTimeOffset(localTime, 
                               TimeZoneInfo.Local.GetUtcOffset(localTime));
      Console.WriteLine(dateAndOffset);
      // The code produces the following output:
      //    7/12/2007 6:32:00 AM -07:00
      // </Snippet3>
   }
   
   private static void ConstructNonLocalWithLocalTicks()
   {
      // <Snippet4>
      DateTime localTime = DateTime.Now;
      DateTimeOffset nonLocalDateWithOffset = new DateTimeOffset(localTime.Ticks, 
                                        new TimeSpan(2, 0, 0));
      Console.WriteLine(nonLocalDateWithOffset); 
      //
      // The code produces the following output if run on Feb. 23, 2007:
      //    2/23/2007 4:37:50 PM +02:00
      // </Snippet4>
   }
   
   private static void ConstructWithDateElements()
   {
      // <Snippet5>
         DateTime specificDate = new DateTime(2008, 5, 1, 06, 32, 00); 
         DateTimeOffset offsetDate = new DateTimeOffset(specificDate.Year, 
                                         specificDate.Month, 
                                         specificDate.Day, 
                                         specificDate.Hour, 
                                         specificDate.Minute, 
                                         specificDate.Second, 
                                         new TimeSpan(-5, 0, 0));
         Console.WriteLine("Current time: {0}", offsetDate);
         Console.WriteLine("Corresponding UTC time: {0}", offsetDate.UtcDateTime);                                              
      // The code produces the following output:
      //    Current time: 5/1/2008 6:32:00 AM -05:00
      //    Corresponding UTC time: 5/1/2008 11:32:00 AM      
      // </Snippet5>
   }
   
   private static void ConstructWithDateElements2()
   {
      // <Snippet6>
      DateTime specificDate = new DateTime(2008, 5, 1, 6, 32, 05); 
      DateTimeOffset offsetDate = new DateTimeOffset(specificDate.Year - 1, 
                                              specificDate.Month, 
                                              specificDate.Day, 
                                              specificDate.Hour, 
                                              specificDate.Minute, 
                                              specificDate.Second, 
                                              0, 
                                              new TimeSpan(-5, 0, 0));
      Console.WriteLine("Current time: {0}", offsetDate);
      Console.WriteLine("Corresponding UTC time: {0}", offsetDate.UtcDateTime);                                              
      // The code produces the following output:
      //    Current time: 5/1/2007 6:32:05 AM -05:00
      //    Corresponding UTC time: 5/1/2007 11:32:05 AM      
      // </Snippet6>
   }

   private static void ConstructWithDateElements3()
   {
      // <Snippet7>
      string fmt = "dd MMM yyyy HH:mm:ss";
      DateTime thisDate = new DateTime(2007, 06, 12, 19, 00, 14, 16);
      DateTimeOffset offsetDate = new DateTimeOffset(thisDate.Year, 
                                                     thisDate.Month, 
                                                     thisDate.Day, 
                                                     thisDate.Hour,
                                                     thisDate.Minute,
                                                     thisDate.Second,
                                                     thisDate.Millisecond, 
                                                     new TimeSpan(2, 0, 0));  
      Console.WriteLine("Current time: {0}:{1}", offsetDate.ToString(fmt), offsetDate.Millisecond);
      // The code produces the following output:
      //    Current time: 12 Jun 2007 19:00:14:16      
     // </Snippet7>
   }

   private static void ConstructWithCalendar()
   {
      // <Snippet8>
      CultureInfo fmt;
      int year; 
      Calendar cal;
      DateTimeOffset dateInCal;
      
      // Instantiate DateTimeOffset with Hebrew calendar
      year = 5770;
      cal = new HebrewCalendar();
      fmt = new CultureInfo("he-IL");
      fmt.DateTimeFormat.Calendar = cal;      
      dateInCal = new DateTimeOffset(year, 7, 12, 
                                     15, 30, 0, 0, 
                                     cal, 
                                     new TimeSpan(2, 0, 0));
      // Display the date in the Hebrew calendar
      Console.WriteLine("Date in Hebrew Calendar: {0:g}", 
                         dateInCal.ToString(fmt));
      // Display the date in the Gregorian calendar                         
      Console.WriteLine("Date in Gregorian Calendar: {0:g}", dateInCal);
      Console.WriteLine();

      // Instantiate DateTimeOffset with Hijri calendar
      year = 1431;
      cal = new HijriCalendar();
      fmt = new CultureInfo("ar-SA");
      fmt.DateTimeFormat.Calendar = cal;
      dateInCal = new DateTimeOffset(year, 7, 12, 
                                     15, 30, 0, 0, 
                                     cal, 
                                     new TimeSpan(2, 0, 0));
      // Display the date in the Hijri calendar
      Console.WriteLine("Date in Hijri Calendar: {0:g}", 
                         dateInCal.ToString(fmt));
      // Display the date in the Gregorian calendar                         
      Console.WriteLine("Date in Gregorian Calendar: {0:g}", dateInCal);
      Console.WriteLine();
      // </Snippet8>
   }
}
