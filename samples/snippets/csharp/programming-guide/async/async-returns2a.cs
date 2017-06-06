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
      // <Snippet1>
      Task wait = WaitAndApologize();
      
      string output = $"Today is {DateTime.Now:D}\n" + 
                      $"The current time is {DateTime.Now.TimeOfDay:t}\n" +
                      $"The current temperature is 76 degrees.\n";
      await wait;
      Console.WriteLine(output);
      // </Snippet1>
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

