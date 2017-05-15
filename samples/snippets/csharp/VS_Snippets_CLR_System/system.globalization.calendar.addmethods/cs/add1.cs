using System;
using System.Globalization;

public class Example
{
   static DateTime date1 = DateTime.SpecifyKind(new DateTime(2009, 6, 1, 7, 42, 0), DateTimeKind.Local);
   static DateTime time, returnTime;
   
   public static void Main()
   {
      Calendar[] calendars = { new ChineseLunisolarCalendar(),
                               new GregorianCalendar(),
                               new HebrewCalendar(),
                               new HijriCalendar(),
                               new JapaneseCalendar(),
                               new JapaneseLunisolarCalendar(),
                               new JulianCalendar(),
                               new KoreanCalendar(),
                               new KoreanLunisolarCalendar(),
                               new PersianCalendar(),
                               new TaiwanCalendar(),
                               new TaiwanLunisolarCalendar(),
                               new ThaiBuddhistCalendar(),
                               new UmAlQuraCalendar() };
      foreach (Calendar cal in calendars)
      {
         Console.WriteLine("Calling AddDays...");
         AddDays(cal);
         Console.WriteLine("Calling AddHours...");
         AddHours(cal);
         Console.WriteLine("Calling AddMilliseconds...");
         AddMilliseconds(cal);
         Console.WriteLine("Calling AddMinutes...");
         AddMinutes(cal);
         Console.WriteLine("Calling AddMonths...");
         AddMonths(cal);
         Console.WriteLine("Calling AddSeconds...");
         AddSeconds(cal);
         Console.WriteLine("Calling AddWeeks...");
         AddWeeks(cal);
         Console.WriteLine("Calling AddYears...");
         AddYears(cal);
      }
   }
   
   private static void AddDays(Calendar cal)
   {
      int days = 3;
      Example.time = date1;
            
      // <Snippet1>
      returnTime = DateTime.SpecifyKind(cal.AddDays(time, days), time.Kind);
      // </Snippet1>
      Console.WriteLine(returnTime.Kind == time.Kind);
   }
   
   private static void AddHours(Calendar cal)
   {
      int hours = 3;
      Example.time = date1;

      // <Snippet2>
      returnTime = DateTime.SpecifyKind(cal.AddHours(time, hours), time.Kind);
      // </Snippet2>
   }
   
   private static void AddMilliseconds(Calendar cal)
   {
      int milliseconds = 100000;
      Example.time = date1;

      // <Snippet3>
      returnTime = DateTime.SpecifyKind(cal.AddMilliseconds(time, milliseconds), time.Kind);
      // </Snippet3>
      Console.WriteLine(returnTime.Kind == time.Kind);
   }
   
   private static void AddMinutes(Calendar cal)
   {
      int minutes = 90;
      Example.time = date1;

      // <Snippet4>
      returnTime = DateTime.SpecifyKind(cal.AddMinutes(time, minutes), time.Kind);
      // </Snippet4>
      Console.WriteLine(returnTime.Kind == time.Kind);
   }
   
   private static void AddMonths(Calendar cal)
   {
      int months = 11;
      Example.time = date1;

      // <Snippet5>
      returnTime = DateTime.SpecifyKind(cal.AddMonths(time, months), time.Kind);
      // </Snippet5>
      Console.WriteLine(returnTime.Kind == time.Kind);
   }
   
   private static void AddSeconds(Calendar cal)
   {
      int seconds = 90;
      Example.time = date1;

      // <Snippet6>
      returnTime = DateTime.SpecifyKind(cal.AddSeconds(time, seconds), time.Kind);
      // </Snippet6>
      Console.WriteLine(returnTime.Kind == time.Kind);
   }
   
   private static void AddWeeks(Calendar cal)
   {
      int weeks = 12;
      Example.time = date1;

      // <Snippet7>
      returnTime = DateTime.SpecifyKind(cal.AddWeeks(time, weeks), time.Kind);
      // </Snippet7>
      Console.WriteLine(returnTime.Kind == time.Kind);
   }
   
   private static void AddYears(Calendar cal)
   {
      int years = 12;
      Example.time = date1;

      // <Snippet8>
      returnTime = DateTime.SpecifyKind(cal.AddYears(time, years), time.Kind);
      // </Snippet8>
      Console.WriteLine(returnTime.Kind == time.Kind);
   }
}

