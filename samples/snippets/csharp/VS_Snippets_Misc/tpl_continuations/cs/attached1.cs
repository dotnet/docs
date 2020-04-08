// <Snippet9>
using System;
using System.Threading;
using System.Threading.Tasks;

public class Example
{
   public static void Main()
   {
      var t = Task.Factory.StartNew( () => { Console.WriteLine("Running antecedent task {0}...",
                                                  Task.CurrentId);
                                             Console.WriteLine("Launching attached child tasks...");
                                             for (int ctr = 1; ctr <= 5; ctr++)  {
                                                int index = ctr;
                                                Task.Factory.StartNew( (value) => {
                                                                       Console.WriteLine("   Attached child task #{0} running",
                                                                                         value);
                                                                       Thread.Sleep(1000);
                                                                     }, index, TaskCreationOptions.AttachedToParent);
                                             }
                                             Console.WriteLine("Finished launching attached child tasks...");
                                           });
      var continuation = t.ContinueWith( (antecedent) => { Console.WriteLine("Executing continuation of Task {0}",
                                                                             antecedent.Id);
                                                         });
      continuation.Wait();
   }
}
// The example displays the following output:
//       Running antecedent task 1...
//       Launching attached child tasks...
//       Finished launching attached child tasks...
//          Attached child task #5 running
//          Attached child task #1 running
//          Attached child task #2 running
//          Attached child task #3 running
//          Attached child task #4 running
//       Executing continuation of Task 1
// </Snippet9>
