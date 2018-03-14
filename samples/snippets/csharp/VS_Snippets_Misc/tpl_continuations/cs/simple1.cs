// <Snippet1>
using System;
using System.Threading.Tasks;

public class Example
{
   public static void Main()
   {
      // Execute the antecedent.
      Task<DayOfWeek> taskA = Task.Run( () => DateTime.Today.DayOfWeek );

      // Execute the continuation when the antecedent finishes.
      Task continuation = taskA.ContinueWith( antecedent => Console.WriteLine("Today is {0}.", antecedent.Result) );
   }
}
// The example displays output like the following output:
//       Today is Monday.
// </Snippet1>

