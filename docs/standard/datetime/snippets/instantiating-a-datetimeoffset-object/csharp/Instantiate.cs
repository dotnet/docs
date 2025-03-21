using System;
using System.Globalization;

public class Class1
{
   public static void Main()
   {
      Console.WriteLine();
      CallConstructors();
      Console.WriteLine();
      CallDateTimeConstructors();
      Console.WriteLine();
      CallDateTimeWithOffsetConstructors();
      Console.WriteLine();
      CastToDateTimeOffset();
      Console.WriteLine();
      ParseTimeString();
   }

   private static void CallConstructors()
   {
      // <Snippet3>
      DateTimeOffset dateAndTime;

      // Instantiate date and time using years, months, days,
      // hours, minutes, and seconds
      dateAndTime = new DateTimeOffset(2008, 5, 1, 8, 6, 32,
                                       new TimeSpan(1, 0, 0));
      Console.WriteLine(dateAndTime);
      // Instantiate date and time using years, months, days,
      // hours, minutes, seconds, and milliseconds
      dateAndTime = new DateTimeOffset(2008, 5, 1, 8, 6, 32, 545,
                                       new TimeSpan(1, 0, 0));
      Console.WriteLine("{0} {1}", dateAndTime.ToString("G"),
                                   dateAndTime.ToString("zzz"));

      // Instantiate date and time using Persian calendar with years,
      // months, days, hours, minutes, seconds, and milliseconds
      dateAndTime = new DateTimeOffset(1387, 2, 12, 8, 6, 32, 545,
                                       new PersianCalendar(),
                                       new TimeSpan(1, 0, 0));
      // Note that the console output displays the date in the Gregorian
      // calendar, not the Persian calendar.
      Console.WriteLine("{0} {1}", dateAndTime.ToString("G"),
                                   dateAndTime.ToString("zzz"));

      // Instantiate date and time using number of ticks
      // 05/01/2008 8:06:32 AM is 633,452,259,920,000,000 ticks
      dateAndTime = new DateTimeOffset(633452259920000000, new TimeSpan(1, 0, 0));
      Console.WriteLine(dateAndTime);
      // The example displays the following output to the console:
      //       5/1/2008 8:06:32 AM +01:00
      //       5/1/2008 8:06:32 AM +01:00
      //       5/1/2008 8:06:32 AM +01:00
      //       5/1/2008 8:06:32 AM +01:00
      // </Snippet3>
   }

   private static void CallDateTimeConstructors()
   {
      // <Snippet4>
      // Declare date; Kind property is DateTimeKind.Unspecified
      DateTime sourceDate = new DateTime(2008, 5, 1, 8, 30, 0);
      DateTimeOffset targetTime;

      // Instantiate a DateTimeOffset value from a UTC time
      DateTime utcTime = DateTime.SpecifyKind(sourceDate, DateTimeKind.Utc);
      targetTime = new DateTimeOffset(utcTime);
      Console.WriteLine(targetTime);
      // Displays 5/1/2008 8:30:00 AM +00:00
      // Because the Kind property is DateTimeKind.Utc,
      // the offset is TimeSpan.Zero.

      // Instantiate a DateTimeOffset value from a UTC time with a zero offset
      targetTime = new DateTimeOffset(utcTime, TimeSpan.Zero);
      Console.WriteLine(targetTime);
      // Displays 5/1/2008 8:30:00 AM +00:00
      // Because the Kind property is DateTimeKind.Utc,
      // the call to the constructor succeeds

      // Instantiate a DateTimeOffset value from a UTC time with a negative offset
      try
      {
         targetTime = new DateTimeOffset(utcTime, new TimeSpan(-2, 0, 0));
         Console.WriteLine(targetTime);
      }
      catch (ArgumentException)
      {
         Console.WriteLine($"Attempt to create DateTimeOffset value from {targetTime} failed.");
      }
      // Throws exception and displays the following to the console:
      //   Attempt to create DateTimeOffset value from 5/1/2008 8:30:00 AM +00:00 failed.

      // Instantiate a DateTimeOffset value from a local time
      DateTime localTime = DateTime.SpecifyKind(sourceDate, DateTimeKind.Local);
      targetTime = new DateTimeOffset(localTime);
      Console.WriteLine(targetTime);
      // Displays 5/1/2008 8:30:00 AM -07:00
      // Because the Kind property is DateTimeKind.Local,
      // the offset is that of the local time zone.

      // Instantiate a DateTimeOffset value from an unspecified time
      targetTime = new DateTimeOffset(sourceDate);
      Console.WriteLine(targetTime);
      // Displays 5/1/2008 8:30:00 AM -07:00
      // Because the Kind property is DateTimeKind.Unspecified,
      // the offset is that of the local time zone.
      // </Snippet4>
   }

   private static void CallDateTimeWithOffsetConstructors()
   {
      // <Snippet5>
      DateTime sourceDate = new DateTime(2008, 5, 1, 8, 30, 0);
      DateTimeOffset targetTime;

      // Instantiate a DateTimeOffset value from a UTC time with a zero offset.
      DateTime utcTime = DateTime.SpecifyKind(sourceDate, DateTimeKind.Utc);
      targetTime = new DateTimeOffset(utcTime, TimeSpan.Zero);
      Console.WriteLine(targetTime);
      // Displays 5/1/2008 8:30:00 AM +00:00
      // Because the Kind property is DateTimeKind.Utc,
      // the call to the constructor succeeds

      // Instantiate a DateTimeOffset value from a UTC time with a non-zero offset.
      try
      {
         targetTime = new DateTimeOffset(utcTime, new TimeSpan(-2, 0, 0));
         Console.WriteLine(targetTime);
      }
      catch (ArgumentException)
      {
         Console.WriteLine($"Attempt to create DateTimeOffset value from {utcTime} failed.");
      }
      // Throws exception and displays the following to the console:
      //   Attempt to create DateTimeOffset value from 5/1/2008 8:30:00 AM failed.

      // Instantiate a DateTimeOffset value from a local time with
      // the offset of the local time zone
      DateTime localTime = DateTime.SpecifyKind(sourceDate, DateTimeKind.Local);
      targetTime = new DateTimeOffset(localTime,
                                      TimeZoneInfo.Local.GetUtcOffset(localTime));
      Console.WriteLine(targetTime);
      // Displays 5/1/2008 8:30:00 AM -07:00
      // Because the Kind property is DateTimeKind.Local and the offset matches
      // that of the local time zone, the call to the constructor succeeds.

      // Instantiate a DateTimeOffset value from a local time with a zero offset.
      try
      {
         targetTime = new DateTimeOffset(localTime, TimeSpan.Zero);
         Console.WriteLine(targetTime);
      }
      catch (ArgumentException)
      {
         Console.WriteLine($"Attempt to create DateTimeOffset value from {localTime} failed.");
      }
      // Throws exception and displays the following to the console:
      //   Attempt to create DateTimeOffset value from 5/1/2008 8:30:00 AM failed.

      // Instantiate a DateTimeOffset value with an arbitrary time zone.
      string timeZoneName = "Central Standard Time";
      TimeSpan offset = TimeZoneInfo.FindSystemTimeZoneById(timeZoneName).
                               GetUtcOffset(sourceDate);
      targetTime = new DateTimeOffset(sourceDate, offset);
      Console.WriteLine(targetTime);
      // Displays 5/1/2008 8:30:00 AM -05:00
      // </Snippet5>
   }

   private static void CastToDateTimeOffset()
   {
      // <Snippet6>
      DateTimeOffset targetTime;

      // The Kind property of sourceDate is DateTimeKind.Unspecified
      DateTime sourceDate = new DateTime(2008, 5, 1, 8, 30, 0);
      targetTime = sourceDate;
      Console.WriteLine(targetTime);
      // Displays 5/1/2008 8:30:00 AM -07:00

      // define a UTC time (Kind property is DateTimeKind.Utc)
      DateTime utcTime = DateTime.SpecifyKind(sourceDate, DateTimeKind.Utc);
      targetTime = utcTime;
      Console.WriteLine(targetTime);
      // Displays 5/1/2008 8:30:00 AM +00:00

      // Define a local time (Kind property is DateTimeKind.Local)
      DateTime localTime = DateTime.SpecifyKind(sourceDate, DateTimeKind.Local);
      targetTime = localTime;
      Console.WriteLine(targetTime);
      // Displays 5/1/2008 8:30:00 AM -07:00
      // </Snippet6>
   }

   private static void ParseTimeString()
   {
      // <Snippet7>
      string timeString;
      DateTimeOffset targetTime;

      timeString = "05/01/2008 8:30 AM +01:00";
      try
      {
         targetTime = DateTimeOffset.Parse(timeString);
         Console.WriteLine(targetTime);
      }
      catch (FormatException)
      {
         Console.WriteLine($"Unable to parse {timeString}.");
      }

      timeString = "05/01/2008 8:30 AM";
      if (DateTimeOffset.TryParse(timeString, out targetTime))
         Console.WriteLine(targetTime);
      else
         Console.WriteLine($"Unable to parse {timeString}.");

      timeString = "Thursday, 01 May 2008 08:30";
      try
      {
         targetTime = DateTimeOffset.ParseExact(timeString, "f",
                      CultureInfo.InvariantCulture);
         Console.WriteLine(targetTime);
      }
      catch (FormatException)
      {
         Console.WriteLine($"Unable to parse {timeString}.");
      }

      timeString = "Thursday, 01 May 2008 08:30 +02:00";
      string formatString;
      formatString = CultureInfo.InvariantCulture.DateTimeFormat.LongDatePattern +
                      " " +
                      CultureInfo.InvariantCulture.DateTimeFormat.ShortTimePattern +
                      " zzz";
      if (DateTimeOffset.TryParseExact(timeString,
                                      formatString,
                                      CultureInfo.InvariantCulture,
                                      DateTimeStyles.AllowLeadingWhite,
                                      out targetTime))
         Console.WriteLine(targetTime);
      else
         Console.WriteLine($"Unable to parse {timeString}.");
      // The example displays the following output to the console:
      //    5/1/2008 8:30:00 AM +01:00
      //    5/1/2008 8:30:00 AM -07:00
      //    5/1/2008 8:30:00 AM -07:00
      //    5/1/2008 8:30:00 AM +02:00
      // </Snippet7>
   }
}
