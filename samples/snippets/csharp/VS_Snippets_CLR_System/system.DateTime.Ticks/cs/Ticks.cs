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
      // If run on December 14, 2007, at 15:23, this example displays the
      // following output to the console:
      //    Elapsed from the beginning of the century to Friday, December 14, 2007 3:23 PM:
      //          219,338,580,000,000,000 nanoseconds
      //          2,193,385,800,000,000 ticks
      //          219,338,580.00 seconds
      //          3,655,643.00 minutes
      //          2,538 days, 15 hours, 23 minutes, 0 seconds
      // </Snippet1>
   }
}
