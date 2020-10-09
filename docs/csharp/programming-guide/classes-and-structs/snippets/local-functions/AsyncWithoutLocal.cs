using System;
using System.Threading.Tasks;

public class AsyncWithoutLocalExample
{
   public static async Task Main()
   {
      var t = GetMultipleAsync(6);
      Console.WriteLine("Got the task");
      
      var result = await t;  // line 11
      Console.WriteLine($"The returned value is {result:N0}");
   }

   static async Task<int> GetMultipleAsync(int delayInSeconds)
   {
      if (delayInSeconds < 0 || delayInSeconds > 5)
         throw new ArgumentOutOfRangeException(nameof(delayInSeconds), "Delay cannot exceed 5 seconds.");

      await Task.Delay(delayInSeconds * 1000);
      return delayInSeconds * new Random().Next(2,10);
   }
}
// The example displays the output like this:
//
// Got the task
// Unhandled exception. System.ArgumentOutOfRangeException: Delay cannot exceed 5 seconds. (Parameter 'delayInSeconds')
//   at AsyncWithoutLocalExample.GetMultipleAsync(Int32 delayInSeconds) in AsyncWithoutLocal.cs:line 18
//   at AsyncWithoutLocalExample.Main() in AsyncWithoutLocal.cs:line 11
