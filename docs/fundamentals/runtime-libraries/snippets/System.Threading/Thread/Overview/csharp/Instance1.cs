// <Snippet4>
using System;
using System.Threading;

public class Example1
{
   static Object obj = new Object();
   
   public static void Main()
   {
      ThreadPool.QueueUserWorkItem(ShowThreadInformation);
      var th1 = new Thread(ShowThreadInformation);
      th1.Start();
      var th2 = new Thread(ShowThreadInformation);
      th2.IsBackground = true;
      th2.Start();
      Thread.Sleep(500);
      ShowThreadInformation(null); 
   }
   
   private static void ShowThreadInformation(Object state)
   {
      lock (obj) {
         var th  = Thread.CurrentThread;
         Console.WriteLine($"Managed thread #{th.ManagedThreadId}: ");
         Console.WriteLine($"   Background thread: {th.IsBackground}");
         Console.WriteLine($"   Thread pool thread: {th.IsThreadPoolThread}");
         Console.WriteLine($"   Priority: {th.Priority}");
         Console.WriteLine($"   Culture: {th.CurrentCulture.Name}");
         Console.WriteLine($"   UI culture: {th.CurrentUICulture.Name}");
         Console.WriteLine();
      }   
   }
}
// The example displays output like the following:
//       Managed thread #6:
//          Background thread: True
//          Thread pool thread: False
//          Priority: Normal
//          Culture: en-US
//          UI culture: en-US
//       
//       Managed thread #3:
//          Background thread: True
//          Thread pool thread: True
//          Priority: Normal
//          Culture: en-US
//          UI culture: en-US
//       
//       Managed thread #4:
//          Background thread: False
//          Thread pool thread: False
//          Priority: Normal
//          Culture: en-US
//          UI culture: en-US
//       
//       Managed thread #1:
//          Background thread: False
//          Thread pool thread: False
//          Priority: Normal
//          Culture: en-US
//          UI culture: en-US
// </Snippet4>
