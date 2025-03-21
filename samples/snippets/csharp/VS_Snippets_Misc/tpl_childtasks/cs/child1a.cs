// <Snippet3>
using System;
using System.Threading;
using System.Threading.Tasks;

public class Example2
{
   public static void Main()
   {
      var parent = Task.Run(() => {
            Console.WriteLine("Parent task executing.");
            var child = Task.Factory.StartNew(() => {
                  Console.WriteLine("Attached child starting.");
                  Thread.SpinWait(5000000);
                  Console.WriteLine("Attached child completing.");
            }, TaskCreationOptions.AttachedToParent);
      });
      parent.Wait();
      Console.WriteLine("Parent has completed.");
   }
}

// The example displays output like the following:
//       Parent task executing.
//       Parent has completed.
//       Attached child starting.
// </Snippet3>
