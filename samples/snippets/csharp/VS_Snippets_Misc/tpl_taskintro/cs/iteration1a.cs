// <Snippet21>
using System;
using System.Threading;
using System.Threading.Tasks;

class CustomData
{
   public long CreationTime;
   public int Name;
   public int ThreadNum;
}

public class IterationOne
{
   public static void Main()
   {
      // Create the task object by using an Action(Of Object) to pass in custom data
      // to the Task constructor. This is useful when you need to capture outer variables
      // from within a loop.
      Task[] taskArray = new Task[10];
      for (int i = 0; i < taskArray.Length; i++) {
         taskArray[i] = Task.Factory.StartNew( (Object obj ) => {
                                                  CustomData data = obj as CustomData;
                                                  if (data == null)
                                                     return;

                                                  data.ThreadNum = Thread.CurrentThread.ManagedThreadId;
                                                  Console.WriteLine("Task #{0} created at {1} on thread #{2}.",
                                                                   data.Name, data.CreationTime, data.ThreadNum);
                                               },
                                               new CustomData() {Name = i, CreationTime = DateTime.Now.Ticks} );
      }
      Task.WaitAll(taskArray);
   }
}
// The example displays output like the following:
//       Task #0 created at 635116412924597583 on thread #3.
//       Task #1 created at 635116412924607584 on thread #4.
//       Task #3 created at 635116412924607584 on thread #4.
//       Task #4 created at 635116412924607584 on thread #4.
//       Task #2 created at 635116412924607584 on thread #3.
//       Task #6 created at 635116412924607584 on thread #3.
//       Task #5 created at 635116412924607584 on thread #4.
//       Task #8 created at 635116412924607584 on thread #4.
//       Task #7 created at 635116412924607584 on thread #3.
//       Task #9 created at 635116412924607584 on thread #4.
// </Snippet21>
