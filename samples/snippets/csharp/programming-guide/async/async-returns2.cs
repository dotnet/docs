using System;
using System.Threading.Tasks;

public class Example
{
   public static void Main()
   {
      DisplayCurrentInfo().Wait();
   }

   static async Task DisplayCurrentInfo()
   {
      await WaitAndApologize();
      Console.WriteLine($"Today is {DateTime.Now:D}");
      Console.WriteLine($"The current time is {DateTime.Now.TimeOfDay:t}");
      Console.WriteLine("The current temperature is 76 degrees.");
   }

   static async Task WaitAndApologize()
   {
      // Task.Delay is a placeholder for actual work.  
      await Task.Delay(2000);  
      // Task.Delay delays the following line by two seconds.  
      Console.WriteLine("\nSorry for the delay. . . .\n");  
   }
}
// The example displays the following output:
//       Sorry for the delay. . . .
//       
//       Today is Wednesday, May 24, 2017
//       The current time is 15:25:16.2935649
//       The current temperature is 76 degrees.

