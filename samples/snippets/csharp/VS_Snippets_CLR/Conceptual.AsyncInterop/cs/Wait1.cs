using System;
using System.Threading;
using System.Threading.Tasks;

public static class Example
{
    // <Snippet12>
    public static Task WaitOneAsync(this WaitHandle waitHandle)
    {
        if (waitHandle == null)
            throw new ArgumentNullException("waitHandle");

        var tcs = new TaskCompletionSource<bool>();
        var rwh = ThreadPool.RegisterWaitForSingleObject(waitHandle,
            delegate { tcs.TrySetResult(true); }, null, -1, true);
        var t = tcs.Task;
        t.ContinueWith( (antecedent) => rwh.Unregister(null));
        return t;
    }
   // </Snippet12>

   public static void MethodA()
   {
     var task = Task.Run( () => { Thread.Sleep(1000); } );
     // <Snippet14>
     WaitHandle wh = ((IAsyncResult)task).AsyncWaitHandle;
     // </Snippet14>
   }
}
