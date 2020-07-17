using System;
using System.Threading.Tasks;

public class Example
{
   public static void Main()
   {
       Console.WriteLine("About to wait two seconds");
       WaitTwoSeconds().Wait();
       Console.WriteLine("About to exit the program");
   }

   private static async Task WaitTwoSeconds()
   {
      await Task.Delay(2000);
      Console.WriteLine("Returning from an asynchronous method");
   }
}
// The example displays the following output:
//       About to wait two seconds
//       Returning from an asynchronous method
//       About to exit the program
