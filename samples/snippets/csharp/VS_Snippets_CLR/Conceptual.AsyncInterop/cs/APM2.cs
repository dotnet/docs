using System;
using System.Threading.Tasks;

public class Example
{
   // <Snippet7>
   public static Task<String> DownloadStringAsync(Uri url)
   // </Snippet7>
   { return Task.FromResult<String>(String.Empty); }

   // <Snippet8>
   public IAsyncResult BeginDownloadString(Uri url,
                                           AsyncCallback callback,
                                           object state)
   // </Snippet8>
   { return null; }

   // <Snippet9>
   public string EndDownloadString(IAsyncResult asyncResult)
   // </Snippet9>
   { return String.Empty; }
}

public class Example2
{
   // <Snippet10>
   public IAsyncResult BeginDownloadString(Uri url,
                                           AsyncCallback callback,
                                           object state)
   {
      return DownloadStringAsync(url).AsApm(callback, state);
   }

   public string EndDownloadString(IAsyncResult asyncResult)
   {
      return ((Task<string>)asyncResult).Result;
   }
   // </Snippet10>

   public static Task<String> DownloadStringAsync(Uri url)
   { return Task.FromResult<String>(String.Empty); }
}

public static class Library
{
    public static IAsyncResult AsApm<T>(this Task<T> task,
                                        AsyncCallback callback,
                                        object state)
    {
        if (task == null)
            throw new ArgumentNullException("task");

        var tcs = new TaskCompletionSource<T>(state);
        task.ContinueWith(t =>
                          {
                             if (t.IsFaulted)
                                tcs.TrySetException(t.Exception.InnerExceptions);
                             else if (t.IsCanceled)
                                tcs.TrySetCanceled();
                             else
                                tcs.TrySetResult(t.Result);

                             if (callback != null)
                                callback(tcs.Task);
                          }, TaskScheduler.Default);
        return tcs.Task;
    }
}