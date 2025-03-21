// <Snippet22>
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Example.Iterations;

class CustomData
{
   public long CreationTime;
   public int Name;
   public int ThreadNum;
}

public class IterationTwo
{
   public static void Main()
   {
      // Create the task object by using an Action(Of Object) to pass in the loop
      // counter. This produces an unexpected result.
      Task[] taskArray = new Task[10];
      for (int i = 0; i < taskArray.Length; i++) {
         taskArray[i] = Task.Factory.StartNew( (Object obj) => {
                                                 var data = new CustomData() {Name = i, CreationTime = DateTime.Now.Ticks};
                                                 data.ThreadNum = Thread.CurrentThread.ManagedThreadId;
                                                 Console.WriteLine($"Task #{data.Name} created at {data.CreationTime} on thread #{data.ThreadNum}.");
                                               },
                                              i );
      }
      Task.WaitAll(taskArray);
   }
}
// The example displays output like the following:
//       Task #10 created at 635116418427727841 on thread #4.
//       Task #10 created at 635116418427737842 on thread #4.
//       Task #10 created at 635116418427737842 on thread #4.
//       Task #10 created at 635116418427737842 on thread #4.
//       Task #10 created at 635116418427737842 on thread #4.
//       Task #10 created at 635116418427737842 on thread #4.
//       Task #10 created at 635116418427727841 on thread #3.
//       Task #10 created at 635116418427747843 on thread #3.
//       Task #10 created at 635116418427747843 on thread #3.
//       Task #10 created at 635116418427737842 on thread #4.
// </Snippet22>
