// <Snippet1>
using System;

public class Example
{
   public static void Main()
   {
      DateTimeOffset dto = new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero);
      Console.WriteLine("{0} --> Unix Seconds: {1}", dto, dto.ToUnixTimeSeconds());

      dto = new DateTimeOffset(1969, 12, 31, 23, 59, 0, TimeSpan.Zero);
      Console.WriteLine("{0} --> Unix Seconds: {1}", dto, dto.ToUnixTimeSeconds());

      dto = new DateTimeOffset(1970, 1, 1, 0, 1, 0, TimeSpan.Zero);
      Console.WriteLine("{0} --> Unix Seconds: {1}", dto, dto.ToUnixTimeSeconds());
   }
}
// The example displays the following output:
//    1/1/1970 12:00:00 AM +00:00 --> Unix Seconds: 0
//    12/31/1969 11:59:00 PM +00:00 --> Unix Seconds: -60
//    1/1/1970 12:01:00 AM +00:00 --> Unix Seconds: 60
// </Snippet1>

public class DateTimeOffset2
{
   // Number of days in a non-leap year
   private const int DaysPerYear = 365;
   // Number of days in 4 years
   private const int DaysPer4Years = DaysPerYear * 4 + 1;       // 1461
   // Number of days in 100 years
   private const int DaysPer100Years = DaysPer4Years * 25 - 1;  // 36524
   // Number of days in 400 years
   private const int DaysPer400Years = DaysPer100Years * 4 + 1; // 146097
   // Number of days from 1/1/0001 to 12/31/1969
   internal const int DaysTo1970 = DaysPer400Years * 4 + DaysPer100Years * 3 + DaysPer4Years * 17 + DaysPerYear; // 719,162

   private const long UnixEpochTicks = TimeSpan.TicksPerDay * DaysTo1970; // 621,355,968,000,000,000
   private const long UnixEpochSeconds = UnixEpochTicks / TimeSpan.TicksPerSecond; // 62,135,596,800
   private const long UnixEpochMilliseconds = UnixEpochTicks / TimeSpan.TicksPerMillisecond; // 62,135,596,800,000

   private DateTimeOffset dto;
   
   public DateTimeOffset2(DateTimeOffset dto)
   {
      this.dto = dto;
   }
   
   public long ToUnixTimeSeconds() {
            // Truncate sub-second precision before offsetting by the Unix Epoch to avoid
            // the last digit being off by one for dates that result in negative Unix times.
            //
            // For example, consider the DateTimeOffset 12/31/1969 12:59:59.001 +0
            //   ticks            = 621355967990010000
            //   ticksFromEpoch   = ticks - UnixEpochTicks                   = -9990000
            //   secondsFromEpoch = ticksFromEpoch / TimeSpan.TicksPerSecond = 0
            //
            // Notice that secondsFromEpoch is rounded *up* by the truncation induced by integer division,
            // whereas we actually always want to round *down* when converting to Unix time. This happens
            // automatically for positive Unix time values. Now the example becomes:
            //   seconds          = ticks / TimeSpan.TicksPerSecond = 62135596799
            //   secondsFromEpoch = seconds - UnixEpochSeconds      = -1
            //
            // In other words, we want to consistently round toward the time 1/1/0001 00:00:00,
            // rather than toward the Unix Epoch (1/1/1970 00:00:00).
            long seconds = dto.UtcDateTime.Ticks / TimeSpan.TicksPerSecond;
            return seconds - UnixEpochSeconds;
        }

}

