// <Snippet2>
using System;
using System.Threading;

public class Example
{
   public static void Main()
   {
      int worker = 0;
      int io = 0;
      ThreadPool.GetAvailableThreads(out worker, out io);
      
      Console.WriteLine("Thread pool threads available at startup: ");
      Console.WriteLine("   Worker threads: {0:N0}", worker);
      Console.WriteLine("   Asynchronous I/O threads: {0:N0}", io);
   }
}
// The example displays output like the following:
//    Thread pool threads available at startup:
//       Worker threads: 32,767
//       Asynchronous I/O threads: 1,000
// </Snippet2>
