using System;
using System.Threading.Tasks;

class Example
{
   static void Main()
   {
      int result = GetMultiple(6).Result; // Line 8
      Console.WriteLine($"The returned value is {result:N0}");
   }

   static Task<int> GetMultiple(int secondsDelay)
   {
      if (secondsDelay < 0 || secondsDelay > 5)
         throw new ArgumentOutOfRangeException("secondsDelay cannot exceed 5."); // Line 15

      return GetValueAsync();

      async Task<int> GetValueAsync()
      {
         Console.WriteLine("Executing GetValueAsync...");
         await Task.Delay(secondsDelay * 1000);
         return secondsDelay * new Random().Next(2,10);
      }
   }
}
// The example displays the following output:
//    Unhandled Exception: System.ArgumentOutOfRangeException:
//       Specified argument was out of the range of valid values.
//    Parameter name: secondsDelay cannot exceed 5.
//       at Example.GetMultiple(Int32 secondsDelay) in Program.cs:line 15
//       at Example.Main() in Program.cs:line 8
