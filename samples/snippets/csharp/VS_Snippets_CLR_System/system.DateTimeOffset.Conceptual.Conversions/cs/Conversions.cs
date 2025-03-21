using System;

public class Class1
{
   public static void Main()
   {
      // Conversions from DateTimeOffset to DateTime
      Console.WriteLine("--------------------");
      Console.WriteLine("FROM DATETIMEOFFSET TO DATETIME:");
      Console.WriteLine();
      ConvertUsingDateTime();
      Console.WriteLine();
      ConvertUtcTime();
      Console.WriteLine();
      ConvertLocalTime();
      Console.WriteLine();
      CallConversionFunction();
      Console.WriteLine();
      Console.WriteLine("--------------------");
      Console.WriteLine("FROM DATETIME TO DATETIMEOFFSET:");
      Console.WriteLine();
      ConvertUtcToDateTimeOffset();
      Console.WriteLine();
      ConvertLocalToDateTimeOffset();
      Console.WriteLine();
      ConvertUnspecifiedToDateTimeOffset1();
      Console.WriteLine();
      ConvertUnspecifiedToDateTimeOffset2();
      Console.WriteLine();
      ConvertUsingLocalTimeProperty1();
      Console.WriteLine();
      ConvertUsingLocalTimeProperty2();
      Console.WriteLine();
      PerformUtcAndTypeConversion();
   }

   private static void ConvertUsingDateTime()
   {
      // <Snippet5>
      DateTime baseTime = new DateTime(2008, 6, 19, 7, 0, 0);
      DateTimeOffset sourceTime;
      DateTime targetTime;

      // Convert UTC to DateTime value
      sourceTime = new DateTimeOffset(baseTime, TimeSpan.Zero);
      targetTime = sourceTime.DateTime;
      Console.WriteLine($"{sourceTime} converts to {targetTime} {targetTime.Kind}");

      // Convert local time to DateTime value
      sourceTime = new DateTimeOffset(baseTime,
                                      TimeZoneInfo.Local.GetUtcOffset(baseTime));
      targetTime = sourceTime.DateTime;
      Console.WriteLine($"{sourceTime} converts to {targetTime} {targetTime.Kind}");

      // Convert Central Standard Time to a DateTime value
      try
      {
         TimeSpan offset = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time").GetUtcOffset(baseTime);
         sourceTime = new DateTimeOffset(baseTime, offset);
         targetTime = sourceTime.DateTime;
         Console.WriteLine($"{sourceTime} converts to {targetTime} {targetTime.Kind}");
      }
      catch (TimeZoneNotFoundException)
      {
         Console.WriteLine("Unable to create DateTimeOffset based on U.S. Central Standard Time.");
      }
      // This example displays the following output to the console:
      //    6/19/2008 7:00:00 AM +00:00 converts to 6/19/2008 7:00:00 AM Unspecified
      //    6/19/2008 7:00:00 AM -07:00 converts to 6/19/2008 7:00:00 AM Unspecified
      //    6/19/2008 7:00:00 AM -05:00 converts to 6/19/2008 7:00:00 AM Unspecified
      // </Snippet5>
   }

   private static void ConvertUtcTime()
   {
      // <Snippet6>
      DateTimeOffset utcTime1 = new DateTimeOffset(2008, 6, 19, 7, 0, 0, TimeSpan.Zero);
      DateTime utcTime2 = utcTime1.UtcDateTime;
      Console.WriteLine($"{utcTime1} converted to {utcTime2} {utcTime2.Kind}");
      // The example displays the following output to the console:
      //   6/19/2008 7:00:00 AM +00:00 converted to 6/19/2008 7:00:00 AM Utc
      // </Snippet6>
   }

   private static void ConvertLocalTime()
   {
      // <Snippet7>
      DateTime sourceDate = new DateTime(2008, 6, 19, 7, 0, 0);
      DateTimeOffset utcTime1 = new DateTimeOffset(sourceDate,
                                TimeZoneInfo.Local.GetUtcOffset(sourceDate));
      DateTime utcTime2 = utcTime1.DateTime;
      if (utcTime1.Offset.Equals(TimeZoneInfo.Local.GetUtcOffset(utcTime1.DateTime)))
         utcTime2 = DateTime.SpecifyKind(utcTime2, DateTimeKind.Local);

      Console.WriteLine($"{utcTime1} converted to {utcTime2} {utcTime2.Kind}");
      // The example displays the following output to the console:
      //   6/19/2008 7:00:00 AM -07:00 converted to 6/19/2008 7:00:00 AM Local
      // </Snippet7>
   }

   // <Snippet8>
   static DateTime ConvertFromDateTimeOffset(DateTimeOffset dateTime)
   {
      if (dateTime.Offset.Equals(TimeSpan.Zero))
         return dateTime.UtcDateTime;
      else if (dateTime.Offset.Equals(TimeZoneInfo.Local.GetUtcOffset(dateTime.DateTime)))
         return DateTime.SpecifyKind(dateTime.DateTime, DateTimeKind.Local);
      else
         return dateTime.DateTime;
   }
   // </Snippet8>

   private static void CallConversionFunction()
   {
      // <Snippet9>
      DateTime timeComponent = new DateTime(2008, 6, 19, 7, 0, 0);
      DateTime returnedDate;

      // Convert UTC time
      DateTimeOffset utcTime = new DateTimeOffset(timeComponent, TimeSpan.Zero);
      returnedDate = ConvertFromDateTimeOffset(utcTime);
      Console.WriteLine($"{utcTime} converted to {returnedDate} {returnedDate.Kind}");

      // Convert local time
      DateTimeOffset localTime = new DateTimeOffset(timeComponent,
                                 TimeZoneInfo.Local.GetUtcOffset(timeComponent));
      returnedDate = ConvertFromDateTimeOffset(localTime);
      Console.WriteLine($"{localTime} converted to {returnedDate} {returnedDate.Kind}");

      // Convert Central Standard Time
      DateTimeOffset cstTime = new DateTimeOffset(timeComponent,
                     TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time").GetUtcOffset(timeComponent));
      returnedDate = ConvertFromDateTimeOffset(cstTime);
      Console.WriteLine($"{cstTime} converted to {returnedDate} {returnedDate.Kind}");
      // The example displays the following output to the console:
      //    6/19/2008 7:00:00 AM +00:00 converted to 6/19/2008 7:00:00 AM Utc
      //    6/19/2008 7:00:00 AM -07:00 converted to 6/19/2008 7:00:00 AM Local
      //    6/19/2008 7:00:00 AM -05:00 converted to 6/19/2008 7:00:00 AM Unspecified
      // </Snippet9>
   }

   private static void ConvertUtcToDateTimeOffset()
   {
      // <Snippet1>
      DateTime utcTime1 = new DateTime(2008, 6, 19, 7, 0, 0);
      utcTime1 = DateTime.SpecifyKind(utcTime1, DateTimeKind.Utc);
      DateTimeOffset utcTime2 = utcTime1;
      Console.WriteLine($"Converted {utcTime1} {utcTime1.Kind} to a DateTimeOffset value of {utcTime2}");
      // This example displays the following output to the console:
      //    Converted 6/19/2008 7:00:00 AM Utc to a DateTimeOffset value of 6/19/2008 7:00:00 AM +00:00
      // </Snippet1>
   }

   private static void ConvertLocalToDateTimeOffset()
   {
      // <Snippet2>
      DateTime localTime1 = new DateTime(2008, 6, 19, 7, 0, 0);
      localTime1 = DateTime.SpecifyKind(localTime1, DateTimeKind.Local);
      DateTimeOffset localTime2 = localTime1;
      Console.WriteLine($"Converted {localTime1} {localTime1.Kind} to a DateTimeOffset value of {localTime2}");
      // This example displays the following output to the console:
      //    Converted 6/19/2008 7:00:00 AM Local to a DateTimeOffset value of 6/19/2008 7:00:00 AM -07:00
      // </Snippet2>
   }

   private static void ConvertUnspecifiedToDateTimeOffset1()
   {
      // <Snippet3>
      DateTime time1 = new DateTime(2008, 6, 19, 7, 0, 0);  // Kind is DateTimeKind.Unspecified
      DateTimeOffset time2 = time1;
      Console.WriteLine($"Converted {time1} {time1.Kind} to a DateTimeOffset value of {time2}");
      // This example displays the following output to the console:
      //    Converted 6/19/2008 7:00:00 AM Unspecified to a DateTimeOffset value of 6/19/2008 7:00:00 AM -07:00
      // </Snippet3>
   }

   private static void ConvertUnspecifiedToDateTimeOffset2()
   {
      // <Snippet4>
      DateTime time1 = new DateTime(2008, 6, 19, 7, 0, 0);     // Kind is DateTimeKind.Unspecified
      try
      {
         DateTimeOffset time2 = new DateTimeOffset(time1,
                        TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time").GetUtcOffset(time1));
         Console.WriteLine($"Converted {time1} {time1.Kind} to a DateTime value of {time2}");
      }
      // Handle exception if time zone is not defined in registry
      catch (TimeZoneNotFoundException)
      {
         Console.WriteLine("Unable to identify target time zone for conversion.");
      }
      // This example displays the following output to the console:
      //    Converted 6/19/2008 7:00:00 AM Unspecified to a DateTime value of 6/19/2008 7:00:00 AM -05:00
      // </Snippet4>
   }

   private static void ConvertUsingLocalTimeProperty1()
   {
      // <Snippet10>
      DateTime sourceDate = new DateTime(2008, 6, 19, 7, 0, 0);
      DateTimeOffset localTime1 = new DateTimeOffset(sourceDate,
                                TimeZoneInfo.Local.GetUtcOffset(sourceDate));
      DateTime localTime2 = localTime1.LocalDateTime;

      Console.WriteLine($"{localTime1} converted to {localTime2} {localTime2.Kind}");
      // The example displays the following output to the console:
      //   6/19/2008 7:00:00 AM -07:00 converted to 6/19/2008 7:00:00 AM Local
      // </Snippet10>
   }

   private static void ConvertUsingLocalTimeProperty2()
   {
     // <Snippet11>
      DateTimeOffset originalDate;
      DateTime localDate;

      // Convert time originating in a different time zone
      originalDate = new DateTimeOffset(2008, 6, 18, 7, 0, 0,
                                        new TimeSpan(-5, 0, 0));
      localDate = originalDate.LocalDateTime;
      Console.WriteLine($"{originalDate} converted to {localDate} {localDate.Kind}");
      // Convert time originating in a different time zone
      // so local time zone's adjustment rules are applied
      originalDate = new DateTimeOffset(2007, 11, 4, 4, 0, 0,
                                        new TimeSpan(-5, 0, 0));
      localDate = originalDate.LocalDateTime;
      Console.WriteLine($"{originalDate} converted to {localDate} {localDate.Kind}");
      // The example displays the following output to the console,
      // when you run it on a machine that is set to Pacific Time (US & Canada):
      //       6/18/2008 7:00:00 AM -05:00 converted to 6/18/2008 5:00:00 AM Local
      //       11/4/2007 4:00:00 AM -05:00 converted to 11/4/2007 1:00:00 AM Local
      // </Snippet11>
   }

   private static void PerformUtcAndTypeConversion()
   {
      // <Snippet12>
      DateTimeOffset originalTime = new DateTimeOffset(2008, 6, 19, 7, 0, 0, new TimeSpan(5, 0, 0));
      DateTime utcTime = originalTime.UtcDateTime;
      Console.WriteLine($"{originalTime} converted to {utcTime} {utcTime.Kind}");
      // The example displays the following output to the console:
      //       6/19/2008 7:00:00 AM +05:00 converted to 6/19/2008 2:00:00 AM Utc
      // </Snippet12>
   }
}
