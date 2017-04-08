using System;
using System.IO;
using System.Threading.Tasks;

public static class Wrapper
{
    // <Snippet5>
    public static Task<int> ReadAsync(this Stream stream, 
                                      byte [] buffer, int offset, 
                                      int count)
    {
       if (stream == null) 
           throw new ArgumentNullException("stream");

       var tcs = new TaskCompletionSource<int>();
       stream.BeginRead(buffer, offset, count, iar =>
                        {
                           try { 
                              tcs.TrySetResult(stream.EndRead(iar)); 
                           }
                           catch(OperationCanceledException) { 
                              tcs.TrySetCanceled(); 
                           }
                           catch(Exception exc) { 
                              tcs.TrySetException(exc); 
                           }
                        }, null);
       return tcs.Task;
   }
   // </Snippet5>
}
