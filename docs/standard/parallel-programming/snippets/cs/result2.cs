using System;
using System.Threading.Tasks;

public class ResultTwoExample
{
    public static async Task Main() =>
        await Task.Run(
            () =>
            {
                DateTime date = DateTime.Now;
                return date.Hour > 17
                   ? "evening"
                   : date.Hour > 12
                       ? "afternoon"
                       : "morning";
            })
            .ContinueWith(
                antecedent =>
                {
                    if (antecedent.Status == TaskStatus.RanToCompletion)
                    {
                        Console.WriteLine($"Good {antecedent.Result}!");
                        Console.WriteLine($"And how are you this fine {antecedent.Result}?");
                    }
                    else if (antecedent.Status == TaskStatus.Faulted)
                    {
                        Console.WriteLine(antecedent.Exception.GetBaseException().Message);
                    }
                });
}
// The example displays output like the following:
//       Good afternoon!
//       And how are you this fine afternoon?