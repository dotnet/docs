 // <Snippet3>
using System;
using System.Threading.Tasks;
using System.Timers;

class Example
{
   static void Main()
   {
      Timer timer = new Timer(1000);
      timer.Elapsed += async ( sender, e ) => await HandleTimer();
      timer.Start();
      Console.Write("Press any key to exit... ");
      Console.ReadKey();
   }

   private static Task HandleTimer()
   {
     Console.WriteLine("\nHandler not implemented..." );
     throw new NotImplementedException();
   }
}
// The example displays output like the following:
//   Press any key to exit...
//   Handler not implemented...
//   
//   Unhandled Exception: System.NotImplementedException: The method or operation is not implemented.
//      at Example.HandleTimer()
//      at Example.<<Main>b__0>d__2.MoveNext()
//   --- End of stack trace from previous location where exception was thrown ---
//      at System.Runtime.CompilerServices.AsyncMethodBuilderCore.<>c__DisplayClass2.<ThrowAsync>b__5(Object state)
//      at System.Threading.ExecutionContext.RunInternal(ExecutionContext executionContext, ContextCallback callback, Object state, Boolean preserveSyncCtx)
//      at System.Threading.ExecutionContext.Run(ExecutionContext executionContext, ContextCallback callback, Object state, Boolean preserveSyncCtx)
//      at System.Threading.QueueUserWorkItemCallback.System.Threading.IThreadPoolWorkItem.ExecuteWorkItem()
//      at System.Threading.ThreadPoolWorkQueue.Dispatch()
// </Snippet3>


