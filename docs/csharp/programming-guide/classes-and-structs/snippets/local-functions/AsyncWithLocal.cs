using System;
using System.Threading.Tasks;

public class AsyncWithLocalExample
{
   public static async Task Main()
   {
      var t = GetMultiple(6);  // line 8
      Console.WriteLine("Got the task");
      
      var result = await t;
      Console.WriteLine($"The returned value is {result:N0}");
   }

   static Task<int> GetMultiple(int delayInSeconds)
   {
      if (delayInSeconds < 0 || delayInSeconds > 5)
         throw new ArgumentOutOfRangeException(nameof(delayInSeconds), "Delay cannot exceed 5 seconds.");

      return GetValueAsync();

      async Task<int> GetValueAsync()
      {
         await Task.Delay(delayInSeconds * 1000);
         return delayInSeconds * new Random().Next(2,10);
      }
   }
}
// The example displays the output like this:
//
// Unhandled exception. System.ArgumentOutOfRangeException: Delay cannot exceed 5 seconds. (Parameter 'delayInSeconds')
//   at AsyncWithLocalExample.GetMultiple(Int32 delayInSeconds) in AsyncWithLocal.cs:line 18
//   at AsyncWithLocalExample.Main() in AsyncWithLocal.cs:line 8
