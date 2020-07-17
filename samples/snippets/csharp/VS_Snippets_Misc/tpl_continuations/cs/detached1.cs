// <Snippet10>
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
                                                                     }, index);
                                             }
                                             Console.WriteLine("Finished launching detached child tasks...");
                                           }, TaskCreationOptions.DenyChildAttach);
      var continuation = t.ContinueWith( (antecedent) => { Console.WriteLine("Executing continuation of Task {0}",
                                                                             antecedent.Id);
                                                         });
      continuation.Wait();
   }
}
// The example displays output like the following:
//       Running antecedent task 1...
//       Launching attached child tasks...
//       Finished launching detached child tasks...
//          Attached child task #1 running
//          Attached child task #2 running
//          Attached child task #5 running
//          Attached child task #3 running
//       Executing continuation of Task 1
//          Attached child task #4 running
// </Snippet10>