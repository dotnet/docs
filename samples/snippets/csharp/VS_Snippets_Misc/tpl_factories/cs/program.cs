// <snippet1>
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

class Example
{
   static CancellationTokenSource cts = new CancellationTokenSource();
   
   static TaskFactory factory = new TaskFactory(
      cts.Token,
      TaskCreationOptions.PreferFairness,
      TaskContinuationOptions.ExecuteSynchronously,
      new CustomScheduler());

   static void Main()
   {
      var t2 = factory.StartNew(() => DoWork());
      cts.Dispose();
   }

   static void DoWork() {/*...*/ }
}
//</snippet1>

class CustomScheduler : TaskScheduler
{
   protected override IEnumerable<Task> GetScheduledTasks()
   {
      throw new NotImplementedException();
   }

   protected override void QueueTask(Task task)
   {
      throw new NotImplementedException();
   }

   protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
   {
      throw new NotImplementedException();
   }
}
