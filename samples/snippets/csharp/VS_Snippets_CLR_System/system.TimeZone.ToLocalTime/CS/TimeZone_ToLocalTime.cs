using System;
using System.Globalization;

public class tzTestModule
{
   public static void Main()
   {   
      TimeZoneEx tz = new TimeZoneEx();
      
      // Select a PDT date/time
      DateTime dt1 = new DateTime(2006, 09, 14, 6, 32, 45, DateTimeKind.Utc);
      Console.WriteLine("{0} UTC is equivalent to {1} local time.", 
                        dt1, tz.ToLocalTime(dt1));
                        
      // Select a PST date/time
      DateTime dt2 = new DateTime(2006, 12, 9, 11, 12, 45, DateTimeKind.Utc);
      Console.WriteLine("{0} UTC is equivalent to {1} local time.", 
                        dt2, tz.ToLocalTime(dt2));
      Console.WriteLine("DateTime offset is {0}:{1}", 
                        tz.GetUtcOffset(DateTime.Now).Hours, 
                        tz.GetUtcOffset(DateTime.Now).Minutes);
      
      // Select a local time
      DateTime localTime1 = new DateTime(DateTime.Now.Ticks, DateTimeKind.Local);
      Console.WriteLine("{0} is equivalent to {1} UTC time.", 
                        localTime1, tz.ToUniversalTime(localTime1));
   }
}

public class TimeZoneEx : TimeZone
{
   private TimeZone internalTimeZone; 
   
   public TimeZoneEx() : base()
   {
      this.internalTimeZone = TimeZone.CurrentTimeZone;
   }
   
   public override string DaylightName
   {
      get {return this.internalTimeZone.DaylightName;}
   }
   
   public override string StandardName
   {
      get {return internalTimeZone.StandardName;}
   }
   
   public override DaylightTime GetDaylightChanges(int year)
   {
      return internalTimeZone.GetDaylightChanges(year);
   }
   
   public override TimeSpan GetUtcOffset(DateTime time)
   {
     if (time.Kind == DateTimeKind.Utc)
        return new TimeSpan(0, 0, 0);
     else
        return new TimeSpan(14, 0, 0);
   } 
   
   // <Snippet1>
   public override DateTime ToLocalTime(DateTime time)
   {
      if (time.Kind == DateTimeKind.Local)
      {
         return time;
      }
      else if (time.Kind == DateTimeKind.Utc)
      {
         DateTime returnTime = new DateTime(time.Ticks, DateTimeKind.Local);
         returnTime += this.GetUtcOffset(returnTime);
         if (internalTimeZone.IsDaylightSavingTime(returnTime))
            returnTime -= new TimeSpan(1, 0, 0);
         return returnTime;
      }      
      else
      {
         throw new ArgumentException("The source time zone cannot be determined.");
      }      
   }
   // </Snippet1>
}

