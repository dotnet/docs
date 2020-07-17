// <Snippet6>
using System;
using System.Threading.Tasks;

public class Example
{
   public static void Main()
   {
      var task1 = Task<int>.Run( () => { Console.WriteLine("Executing task {0}",
                                                           Task.CurrentId);
                                         return 54; });
      var continuation = task1.ContinueWith( (antecedent) =>
                                             { Console.WriteLine("Executing continuation task {0}",
                                                                 Task.CurrentId);
                                               Console.WriteLine("Value from antecedent: {0}",
                                                                 antecedent.Result);
                                               throw new InvalidOperationException();
                                            } );

      try {
         task1.Wait();
         continuation.Wait();
      }
      catch (AggregateException ae) {
          foreach (var ex in ae.InnerExceptions)
              Console.WriteLine(ex.Message);
      }
   }
}
// The example displays the following output:
//       Executing task 1
//       Executing continuation task 2
//       Value from antecedent: 54
//       Operation is not valid due to the current state of the object.
// </Snippet6>
