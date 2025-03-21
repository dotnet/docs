// <Snippet8>
using System;
using System.Threading;
using System.Threading.Tasks;

public class Child
{
   public static void Main()
   {
      var parent = Task.Factory.StartNew(() => {
                      Console.WriteLine("Parent task beginning.");
                      for (int ctr = 0; ctr < 10; ctr++) {
                         int taskNo = ctr;
                         Task.Factory.StartNew((x) => {
                                                  Thread.SpinWait(5000000);
                                                  Console.WriteLine($"Attached child #{x} completed.");
                                               },
                                               taskNo, TaskCreationOptions.AttachedToParent);
                      }
                   });

      parent.Wait();
      Console.WriteLine("Parent task completed.");
   }
}
// The example displays output like the following:
//       Parent task beginning.
//       Attached child #9 completed.
//       Attached child #0 completed.
//       Attached child #8 completed.
//       Attached child #1 completed.
//       Attached child #7 completed.
//       Attached child #2 completed.
//       Attached child #6 completed.
//       Attached child #3 completed.
//       Attached child #5 completed.
//       Attached child #4 completed.
//       Parent task completed.
// </Snippet8>
