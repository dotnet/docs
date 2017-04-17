// <Snippet1>
using System;
using System.Threading;
using System.Threading.Tasks;

public class Example
{
   public static void Main()
   {
      var t = new Task( () => { Console.WriteLine("Task {0} running on thread {1}",
                                                  Task.CurrentId, Thread.CurrentThread.ManagedThreadId);
                                for (int ctr = 1; ctr <= 10; ctr++)
                                   Console.WriteLine("   Iteration {0}", ctr); } 
                        );
      t.Start();
      t.Wait();   
   }
}
// The example displays output like the following:
//     Task 1 running on thread 3
//        Iteration 1
//        Iteration 2
//        Iteration 3
//        Iteration 4
//        Iteration 5
//        Iteration 6
//        Iteration 7
//        Iteration 8
//        Iteration 9
//        Iteration 10
// </Snippet1>

