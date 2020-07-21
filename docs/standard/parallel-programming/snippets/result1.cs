using System;
using System.Threading.Tasks;

public class Example
{
    public static async Task Main()
    {
       var task = Task.Run(
           () =>
           {
                DateTime date = DateTime.Now;
                return date.Hour > 17
                    ? "evening"
                    : date.Hour > 12
                        ? "afternoon"
                        : "morning";
            });
        
        await task.ContinueWith(
            antecedent =>
            {
                Console.WriteLine($"Good {antecedent.Result}!");
                Console.WriteLine($"And how are you this fine {antecedent.Result}?");
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
   }
}
// The example displays output like the following:
//       Good afternoon!
//       And how are you this fine afternoon?