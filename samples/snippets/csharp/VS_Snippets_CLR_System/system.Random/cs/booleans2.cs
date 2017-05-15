// <Snippet20>
using System;

public class Example
{
   private static Random rnd = new Random();

   public static void Main()
   {
      int totalTrue = 0, totalFalse = 0;
      
      // Generate 1,0000 random Booleans, and keep a running total.
      for (int ctr = 0; ctr < 1000000; ctr++) {
          bool value = NextBoolean();
          if (value)
             totalTrue++;
          else
             totalFalse++;
      }
      Console.WriteLine("Number of true values:  {0,7:N0} ({1:P3})", 
                        totalTrue, 
                        ((double) totalTrue)/(totalTrue + totalFalse));
      Console.WriteLine("Number of false values: {0,7:N0} ({1:P3})", 
                        totalFalse, 
                        ((double) totalFalse)/(totalTrue + totalFalse));
   }

   public static bool NextBoolean()
   {
      return Convert.ToBoolean(rnd.Next(0, 2));
   }
}
// The example displays output like the following:
//       Number of true values:  499,777 (49.978 %)
//       Number of false values: 500,223 (50.022 %)
// </Snippet20>

