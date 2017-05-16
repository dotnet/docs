// <Snippet3>
using System;
using System.Threading;
using System.Threading.Tasks;

public class Example
{
   public static void Main()
   {
      Console.WriteLine("Application thread ID: {0}",
                        Thread.CurrentThread.ManagedThreadId);
      var t = Task.Run(() => {  Console.WriteLine("Task thread ID: {0}",
                                   Thread.CurrentThread.ManagedThreadId);
                             } );
      t.Wait();
   }
}
// The example displays the following output:
//       Application thread ID: 1
//       Task thread ID: 3
// </Snippet3>
