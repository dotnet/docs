// <Snippet11>
using System;
using System.Threading;
using System.Threading.Tasks;

public class Example
{
   public static void Main()
   {
      ShowThreadInfo("Application");

      var t = Task.Run(() => ShowThreadInfo("Task") );
      t.Wait();
   }

   static void ShowThreadInfo(String s)
   {
      Console.WriteLine("{0} Thread ID: {1}",
                        s, Thread.CurrentThread.ManagedThreadId);
   }
}
// The example displays the following output:
//       Application thread ID: 1
//       Task thread ID: 3
// </Snippet11>
