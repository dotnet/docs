// <Snippet6>
using System;

public class Example
{
   static Random rnd = new Random();
   
   public static void Main()
   {
      TimeSpan timeSpent = TimeSpan.Zero;

      timeSpent += GetTimeBeforeLunch();
      timeSpent += GetTimeAfterLunch();

      Console.WriteLine("Total time: {0}", timeSpent);
   }

   private static TimeSpan GetTimeBeforeLunch()
   {
      return new TimeSpan(rnd.Next(3, 6), 0, 0);
   }
   
   private static TimeSpan GetTimeAfterLunch()
   {
      return new TimeSpan(rnd.Next(3, 6), 0, 0);
   }
}
// The example displays output like the following:
//        Total time: 08:00:00
// </Snippet6>
