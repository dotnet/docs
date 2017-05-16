using System;
using System.Globalization;

public class Class1
{
   public static void Main()
   {
      ShowDateFormats();  
      Console.WriteLine("----------"); 
      ConvertToDateTime();
      Console.WriteLine("----------"); 
      ShowFirstOfMonth();
      Console.WriteLine("----------"); 
      ShowHour();
      Console.WriteLine("----------"); 
      ConvertToLocalTime();
      Console.WriteLine("----------"); 
      ShowMinute();
      Console.WriteLine("----------"); 
      ShowMonth();
      Console.WriteLine("----------"); 
      ShowDay();
      Console.WriteLine("----------"); 
      ShowResolution();
      Console.WriteLine("----------"); 
      ShowMilliseconds();
      Console.WriteLine("----------"); 
      ShowLocalOffset();
      Console.WriteLine("----------"); 
      ShowSeconds();
      Console.WriteLine("----------"); 
      IllustrateTicks();
      Console.WriteLine("----------"); 
      ShowTime();
      Console.WriteLine("----------"); 
      ConvertToUtc();
      Console.WriteLine("----------"); 
      CompareUtcAndLocal();
      Console.WriteLine("----------"); 
      ShowYear();
      Console.WriteLine("----------"); 
  }

   private static void ShowDateFormats()
   {
      // <Snippet1>
      // Illustrate Date property and date formatting
      DateTimeOffset thisDate = new DateTimeOffset(2008, 3, 17, 1, 32, 0, new TimeSpan(-5, 0, 0));
      string fmt;                      // format specifier

      // Display date only using "D" format specifier
      // For en-us culture, displays:
      //   'D' format specifier: Monday, March 17, 2008
      fmt = "D";
      Console.WriteLine("'{0}' format specifier: {1}",  
                        fmt, thisDate.Date.ToString(fmt));
      
      // Display date only using "d" format specifier
      // For en-us culture, displays:
      //   'd' format specifier: 3/17/2008
      fmt = "d";
      Console.WriteLine("'{0}' format specifier: {1}",  
                        fmt, thisDate.Date.ToString(fmt));
      
      // Display date only using "Y" (or "y") format specifier
      // For en-us culture, displays:
      //   'Y' format specifier: March, 2008
      fmt = "Y";
      Console.WriteLine("'{0}' format specifier: {1}",  
                        fmt, thisDate.Date.ToString(fmt));
                        
      // Display date only using custom format specifier
      // For en-us culture, displays:
      //   'dd MMM yyyy' format specifier: 17 Mar 2008
      fmt = "dd MMM yyyy";
      Console.WriteLine("'{0}' format specifier: {1}",  
                        fmt, thisDate.Date.ToString(fmt));
      // </Snippet1>
   }

   private static void ConvertToDateTime()
   {
      // <Snippet2>
      DateTimeOffset offsetDate; 
      DateTime regularDate;
      
      offsetDate = DateTimeOffset.Now;
      regularDate = offsetDate.DateTime;
      Console.WriteLine("{0} converts to {1}, Kind {2}.", 
                        offsetDate.ToString(), 
                        regularDate,  
                        regularDate.Kind);
                     
      offsetDate = DateTimeOffset.UtcNow;
      regularDate = offsetDate.DateTime;
      Console.WriteLine("{0} converts to {1}, Kind {2}.", 
                        offsetDate.ToString(), 
                        regularDate, 
                        regularDate.Kind);
      // If run on 3/6/2007 at 17:11, produces the following output:
      //
      //   3/6/2007 5:11:22 PM -08:00 converts to 3/6/2007 5:11:22 PM, Kind Unspecified.
      //   3/7/2007 1:11:22 AM +00:00 converts to 3/7/2007 1:11:22 AM, Kind Unspecified.                        
      // </Snippet2>                        
   }

   private static void ShowFirstOfMonth()
   {
      // <Snippet3>
      DateTimeOffset startOfMonth = new DateTimeOffset(2008, 1, 1, 0, 0, 0, 
                                               DateTimeOffset.Now.Offset);
      int year = startOfMonth.Year;
      do 
      {
         Console.WriteLine("{0:MMM d, yyyy} is a {1}.", startOfMonth, startOfMonth.DayOfWeek);
         startOfMonth = startOfMonth.AddMonths(1);
      }
      while (startOfMonth.Year == year);
      // This example writes the following output to the console:
      //    Jan 1, 2008 is a Tuesday.
      //    Feb 1, 2008 is a Friday.
      //    Mar 1, 2008 is a Saturday.
      //    Apr 1, 2008 is a Tuesday.
      //    May 1, 2008 is a Thursday.
      //    Jun 1, 2008 is a Sunday.
      //    Jul 1, 2008 is a Tuesday.
      //    Aug 1, 2008 is a Friday.
      //    Sep 1, 2008 is a Monday.
      //    Oct 1, 2008 is a Wednesday.
      //    Nov 1, 2008 is a Saturday.
      //    Dec 1, 2008 is a Monday.      
      // </Snippet3>   

      // <Snippet4>
      DateTimeOffset displayDate = new DateTimeOffset(2008, 1, 1, 13, 18, 00, 
                                                      DateTimeOffset.Now.Offset);
      Console.WriteLine("{0:D}", displayDate);  // Output: Tuesday, January 01, 2008                     
      Console.WriteLine("{0:d} is a {0:dddd}.", 
                        displayDate);           // Output: 1/1/2008 is a Tuesday.
      // </Snippet4>
      
      // <Snippet5>
      DateTimeOffset thisDate = new DateTimeOffset(2007, 6, 1, 6, 15, 0, 
                                                   DateTimeOffset.Now.Offset);
      string weekdayName = thisDate.ToString("dddd", 
                                             new CultureInfo("fr-fr")); 
      Console.WriteLine(weekdayName);                  // Displays vendredi     
      // </Snippet5>                     
   }

   private static void ShowHour()
   {
      // <Snippet6>
      DateTimeOffset theTime = new DateTimeOffset(2008, 3, 1, 14, 15, 00, 
                                             DateTimeOffset.Now.Offset);
      Console.WriteLine("The hour component of {0} is {1}.", 
                        theTime, theTime.Hour);

      Console.WriteLine("The hour component of {0} is{1}.", 
                        theTime, theTime.ToString(" H"));

      Console.WriteLine("The hour component of {0} is {1}.", 
                        theTime, theTime.ToString("HH"));
      // The example produces the following output:
      //    The hour component of 3/1/2008 2:15:00 PM -08:00 is 14.
      //    The hour component of 3/1/2008 2:15:00 PM -08:00 is 14.
      //    The hour component of 3/1/2008 2:15:00 PM -08:00 is 14.
      // </Snippet6>                              
   }

   private static void ConvertToLocalTime()
   {
      // <Snippet7>
      DateTimeOffset dto;

      // Current time
      dto = DateTimeOffset.Now;
      Console.WriteLine(dto.LocalDateTime);
      // UTC time
      dto = DateTimeOffset.UtcNow;
      Console.WriteLine(dto.LocalDateTime);

     // Transition to DST in local time zone occurs on 3/11/2007 at 2:00 AM
      dto = new DateTimeOffset(2007, 3, 11, 3, 30, 0, new TimeSpan(-7, 0, 0));      
      Console.WriteLine(dto.LocalDateTime);
      dto = new DateTimeOffset(2007, 3, 11, 2, 30, 0, new TimeSpan(-7, 0, 0));
      Console.WriteLine(dto.LocalDateTime);
      // Invalid time in local time zone
      dto = new DateTimeOffset(2007, 3, 11, 2, 30, 0, new TimeSpan(-8, 0, 0));
      Console.WriteLine(TimeZoneInfo.Local.IsInvalidTime(dto.DateTime));
      Console.WriteLine(dto.LocalDateTime);

      // Transition from DST in local time zone occurs on 11/4/07 at 2:00 AM
      // This is an ambiguous time
      dto = new DateTimeOffset(2007, 11, 4, 1, 30, 0, new TimeSpan(-7, 0, 0));
      Console.WriteLine(TimeZoneInfo.Local.IsAmbiguousTime(dto));
      Console.WriteLine(dto.LocalDateTime);
      dto = new DateTimeOffset(2007, 11, 4, 2, 30, 0, new TimeSpan(-7, 0, 0));           
      Console.WriteLine(TimeZoneInfo.Local.IsAmbiguousTime(dto));
      Console.WriteLine(dto.LocalDateTime);
      // This is also an ambiguous time
      dto = new DateTimeOffset(2007, 11, 4, 1, 30, 0, new TimeSpan(-8, 0, 0));           
      Console.WriteLine(TimeZoneInfo.Local.IsAmbiguousTime(dto));
      Console.WriteLine(dto.LocalDateTime);
      // If run on 3/8/2007 at 4:56 PM, the code produces the following
      // output:
      //    3/8/2007 4:56:03 PM
      //    3/8/2007 4:56:03 PM
      //    3/11/2007 3:30:00 AM
      //    3/11/2007 1:30:00 AM
      //    True
      //    3/11/2007 3:30:00 AM
      //    True
      //    11/4/2007 1:30:00 AM
      //    11/4/2007 1:30:00 AM
      //    True
      //    11/4/2007 1:30:00 AM      
      // </Snippet7>
   }
   
   private static void ShowMinute()
   {
      // <Snippet8>
      DateTimeOffset theTime = new DateTimeOffset(2008, 5, 1, 10, 3, 0, 
                                                 DateTimeOffset.Now.Offset);
      Console.WriteLine("The minute component of {0} is {1}.", 
                        theTime, theTime.Minute);

      Console.WriteLine("The minute component of {0} is{1}.", 
                        theTime, theTime.ToString(" m"));

      Console.WriteLine("The minute component of {0} is {1}.", 
                        theTime, theTime.ToString("mm"));
      // The example produces the following output:
      //    The minute component of 5/1/2008 10:03:00 AM -08:00 is 3.
      //    The minute component of 5/1/2008 10:03:00 AM -08:00 is 3.
      //    The minute component of 5/1/2008 10:03:00 AM -08:00 is 03.
      // </Snippet8>                              
   }

    private static void ShowMonth()
    {
      // <Snippet9>
      DateTimeOffset theTime = new DateTimeOffset(2008, 9, 7, 11, 25, 0, 
                                             DateTimeOffset.Now.Offset);
      Console.WriteLine("The month component of {0} is {1}.", 
                        theTime, theTime.Month);

      Console.WriteLine("The month component of {0} is{1}.", 
                        theTime, theTime.ToString(" M"));

      Console.WriteLine("The month component of {0} is {1}.", 
                        theTime, theTime.ToString("MM"));
      // The example produces the following output:
      //    The month component of 9/7/2008 11:25:00 AM -08:00 is 9.
      //    The month component of 9/7/2008 11:25:00 AM -08:00 is 9.
      //    The month component of 9/7/2008 11:25:00 AM -08:00 is 09.      
      // </Snippet9>                              
   }

    private static void ShowDay()
    {
      // <Snippet10>
      DateTimeOffset theTime = new DateTimeOffset(2007, 5, 1, 16, 35, 0, 
                                                  DateTimeOffset.Now.Offset);
      Console.WriteLine("The day component of {0} is {1}.", 
                        theTime, theTime.Day);

      Console.WriteLine("The day component of {0} is{1}.", 
                        theTime, theTime.ToString(" d"));

      Console.WriteLine("The day component of {0} is {1}.", 
                        theTime, theTime.ToString("dd"));
      // The example produces the following output:
      //    The day component of 5/1/2007 4:35:00 PM -08:00 is 1.
      //    The day component of 5/1/2007 4:35:00 PM -08:00 is 1.
      //    The day component of 5/1/2007 4:35:00 PM -08:00 is 01.
      // </Snippet10>                              
   }

   private static void ShowResolution()
   {
      // <Snippet11>
      DateTimeOffset dto;
      int ctr = 0;
      int ms = 0;
      do {
         dto = DateTimeOffset.Now;
         if (dto.Millisecond != ms)
         {
            ms = dto.Millisecond;
            Console.WriteLine("{0}:{1:d3} ms. {2}", 
                              dto.ToString("M/d/yyyy h:mm:ss"), 
                              ms, dto.ToString("zzz"));
            ctr++;
         }
      } while (ctr < 100);
      // </Snippet11>
   }   

   private static void ShowMilliseconds()
   {
      // <Snippet12>
      DateTimeOffset date1 = new DateTimeOffset(2008, 3, 5, 5, 45, 35, 649, 
                                      new TimeSpan(-7, 0, 0));
      Console.WriteLine("Milliseconds value of {0} is {1}.", 
                        date1.ToString("MM/dd/yyyy hh:mm:ss.fff"), 
                        date1.Millisecond);
      // The example produces the following output:
      //
      // Milliseconds value of 03/05/2008 05:45:35.649 is 649.
      // </Snippet12>                        
   }

   private static void ShowLocalOffset()
   {
      // <Snippet13>
      DateTimeOffset localTime = DateTimeOffset.Now;
      Console.WriteLine("The local time zone is {0} hours and {1} minutes {2} than UTC.", 
                        Math.Abs(localTime.Offset.Hours), 
                        localTime.Offset.Minutes, 
                        localTime.Offset.Hours < 0 ? "earlier" : "later");
      // The example displays output similar to the following for a system in the
      // U.S. Pacific Standard Time zone: 
      //       The local time zone is 8 hours and 0 minutes earlier than UTC.      
      // </Snippet13>
   }

   private static void ShowSeconds()
   {
      // <Snippet14>
      DateTimeOffset theTime = new DateTimeOffset(2008, 6, 12, 21, 16, 32, 
                                   DateTimeOffset.Now.Offset);
      Console.WriteLine("The second component of {0} is {1}.", 
                        theTime, theTime.Second);

      Console.WriteLine("The second component of {0} is{1}.", 
                        theTime, theTime.ToString(" s"));

      Console.WriteLine("The second component of {0} is {1}.", 
                        theTime, theTime.ToString("ss"));
      // The example produces the following output:
      //    The second component of 6/12/2008 9:16:32 PM -07:00 is 32.
      //    The second component of 6/12/2008 9:16:32 PM -07:00 is 32.
      //    The second component of 6/12/2008 9:16:32 PM -07:00 is 32.
      // </Snippet14>                              
   }

   private static void IllustrateTicks()
   {
      // <Snippet15>
      // Attempt to initialize date to number of ticks
      // in July 1, 2008 1:23:07.      
      //
      // There are 10,000,000 100-nanosecond intervals in a second
      const long NSPerSecond = 10000000;
      long ticks; 
      ticks = 7 * NSPerSecond;                        // Ticks in a 7 seconds 
      ticks += 23 * 60 * NSPerSecond;                 // Ticks in 23 minutes
      ticks += 1 * 60 * 60 * NSPerSecond;             // Ticks in 1 hour
      ticks += 60 * 60 * 24 * NSPerSecond;            // Ticks in 1 day
      ticks += 181 * 60 * 60 * 24 * NSPerSecond;      // Ticks in 6 months 
      ticks += 2007 * 60 * 60 * 24 * 365L * NSPerSecond;   // Ticks in 2007 years 
      ticks += 486 * 60 * 60 * 24 * NSPerSecond;      // Adjustment for leap years      
      DateTimeOffset dto = new DateTimeOffset( 
                               ticks, 
                               DateTimeOffset.Now.Offset);
      Console.WriteLine("There are {0:n0} ticks in {1}.", 
                        dto.Ticks, 
                        dto.ToString());
      // The example displays the following output:
      //       There are 633,504,721,870,000,000 ticks in 7/1/2008 1:23:07 AM -08:00.      
      // </Snippet15>
   }

   private static void ShowTime()
   {
      // <Snippet16>
      DateTimeOffset currentDate = new DateTimeOffset(2008, 5, 10, 5, 32, 16, 
                                            DateTimeOffset.Now.Offset); 
      TimeSpan currentTime = currentDate.TimeOfDay;
      Console.WriteLine("The current time is {0}.", currentTime.ToString());
      // The example produces the following output: 
      //       The current time is 05:32:16.
      // </Snippet16>
   }  

   private static void ConvertToUtc()
   {
      // <Snippet17>
      DateTimeOffset offsetTime = new DateTimeOffset(2007, 11, 25, 11, 14, 00, 
                                  new TimeSpan(3, 0, 0));
      Console.WriteLine("{0} is equivalent to {1} {2}", 
                        offsetTime.ToString(), 
                        offsetTime.UtcDateTime.ToString(), 
                        offsetTime.UtcDateTime.Kind.ToString());      
      // The example displays the following output:
      //       11/25/2007 11:14:00 AM +03:00 is equivalent to 11/25/2007 8:14:00 AM Utc      
      // </Snippet17>
   }

   private static void CompareUtcAndLocal()
   {
      // <Snippet18> 
      DateTimeOffset localTime = DateTimeOffset.Now;
      DateTimeOffset utcTime = DateTimeOffset.UtcNow;
      
      Console.WriteLine("Local Time:          {0}", localTime.ToString("T"));
      Console.WriteLine("Difference from UTC: {0}", localTime.Offset.ToString());
      Console.WriteLine("UTC:                 {0}", utcTime.ToString("T"));
      // If run on a particular date at 1:19 PM, the example produces
      // the following output:
      //    Local Time:          1:19:43 PM
      //    Difference from UTC: -07:00:00
      //    UTC:                 8:19:43 PM      
      // </Snippet18>
   }   
   
   private static void ShowYear()
   {
      // <Snippet19>
      DateTimeOffset theTime = new DateTimeOffset(2008, 2, 17, 9, 0, 0, 
                                   DateTimeOffset.Now.Offset);
      Console.WriteLine("The year component of {0} is {1}.", 
                        theTime, theTime.Year);

      Console.WriteLine("The year component of {0} is{1}.", 
                        theTime, theTime.ToString(" y"));

      Console.WriteLine("The year component of {0} is {1}.", 
                        theTime, theTime.ToString("yy"));
                        
      Console.WriteLine("The year component of {0} is {1}.", 
                        theTime, theTime.ToString("yyyy"));
      // The example produces the following output:
      //    The year component of 2/17/2008 9:00:00 AM -07:00 is 2008.
      //    The year component of 2/17/2008 9:00:00 AM -07:00 is 8.
      //    The year component of 2/17/2008 9:00:00 AM -07:00 is 08.
      //    The year component of 2/17/2008 9:00:00 AM -07:00 is 2008.
      // </Snippet19>                              
   }
}
