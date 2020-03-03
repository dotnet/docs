using System;

public class Class1
{
   public static void Main()
   {
      // <Snippet1>
      DateTime centuryBegin = new DateTime(2001, 1, 1);
      DateTime currentDate = DateTime.Now;
      
      long elapsedTicks = currentDate.Ticks - centuryBegin.Ticks;
      TimeSpan elapsedSpan = new TimeSpan(elapsedTicks);
      
      Console.WriteLine("Elapsed from the beginning of the century to {0:f}:", 
                         currentDate);
      Console.WriteLine("   {0:N0} nanoseconds", elapsedTicks * 100);
      Console.WriteLine("   {0:N0} ticks", elapsedTicks);
      Console.WriteLine("   {0:N2} seconds", elapsedSpan.TotalSeconds);
      Console.WriteLine("   {0:N2} minutes", elapsedSpan.TotalMinutes);
      Console.WriteLine("   {0:N0} days, {1} hours, {2} minutes, {3} seconds", 
                        elapsedSpan.Days, elapsedSpan.Hours, 
                        elapsedSpan.Minutes, elapsedSpan.Seconds);

      // This example displays an output similar to the following:
      // 
      // Elapsed from the beginning of the century to Thursday, 14 November 2019 18:21:
      //    595,448,498,171,000,000 nanoseconds
      //    5,954,484,981,710,000 ticks
      //    595,448,498.17 seconds
      //    9,924,141.64 minutes
      //    6,891 days, 18 hours, 21 minutes, 38 seconds
      // </Snippet1>
   }
}
