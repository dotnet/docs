using System;
using System.Threading.Tasks;

public class Example
{
   public static void Main()
   {
       Console.WriteLine("About to wait two seconds");
       int value = WaitTwoSeconds().Result;
       Console.WriteLine($"Value returned from the async operation: {value}");
       Console.WriteLine("About to exit the program");
   }

   private static async Task<int> WaitTwoSeconds()
   {
      await Task.Delay(2000);
      Console.WriteLine("Returning from an asynchronous method");
      return 100;
   }
}
// The example displays the following output:
//       About to wait two seconds
//       Returning from an asynchronous method
//       Value returned from the async operation: 100
//       About to exit the program
