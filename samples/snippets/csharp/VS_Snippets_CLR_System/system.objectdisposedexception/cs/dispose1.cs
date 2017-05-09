// <Snippet1>
using System;
using System.Threading;

public class Example
{
   public static void Main()
   {
      Timer t = new Timer(TimerNotification, null, 
                         100, Timeout.Infinite);
      Thread.Sleep(2000);
      t.Dispose();
      
      t.Change(200, 1000);                   
      Thread.Sleep(3000);
   }

   private static void TimerNotification(Object obj)
   {
      Console.WriteLine("Timer event fired at {0:F}", DateTime.Now);
   }
}
// The example displays output like the following:
//    Timer event fired at Monday, July 14, 2014 11:54:08 AM
//    
//    Unhandled Exception: System.ObjectDisposedException: Cannot access a disposed object.
//       at System.Threading.TimerQueueTimer.Change(UInt32 dueTime, UInt32 period)
//       at Example.Main()
// </Snippet1>
