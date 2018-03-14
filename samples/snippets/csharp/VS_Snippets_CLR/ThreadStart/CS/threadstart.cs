//<Snippet1>
using System;
using System.Threading;

public class ThreadWork 
{
   public static void DoWork()
   {
      for(int i = 0; i<3;i++) {
         Console.WriteLine("Working thread...");
         Thread.Sleep(100);
      }
   }
}
class ThreadTest
{
   public static void Main()
   {
      Thread thread1 = new Thread(ThreadWork.DoWork);
      thread1.Start();
      for (int i = 0; i<3; i++) {
         Console.WriteLine("In main.");
         Thread.Sleep(100);
      }
   }
}
// The example displays output like the following:
//       In main.
//       Working thread...
//       In main.
//       Working thread...
//       In main.
//       Working thread...
//</Snippet1>