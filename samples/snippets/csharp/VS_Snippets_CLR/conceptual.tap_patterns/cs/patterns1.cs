using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;

public static class StaticPattern
{
    // <Snippet1>
    public static Task<int> ReadTask(this Stream stream, byte[] buffer, int offset, int count, object state)
    {
        var tcs = new TaskCompletionSource<int>();
        stream.BeginRead(buffer, offset, count, ar =>
        {
            try { tcs.SetResult(stream.EndRead(ar)); }
            catch (Exception exc) { tcs.SetException(exc); }
        }, state);
        return tcs.Task;
    }
    // </Snippet1>

    // <Snippet4>
    public static Task<DateTimeOffset> Delay(int millisecondsTimeout)
    {
        TaskCompletionSource<DateTimeOffset> tcs = null;
        Timer timer = null;
 
        timer = new Timer(delegate
        {
            timer.Dispose();
            tcs.TrySetResult(DateTimeOffset.UtcNow);
        }, null, Timeout.Infinite, Timeout.Infinite);
 
        tcs = new TaskCompletionSource<DateTimeOffset>(timer);
        timer.Change(millisecondsTimeout, Timeout.Infinite);
        return tcs.Task;
    }
    // </Snippet4>

   // <Snippet5>
   public static async Task Poll(Uri url, CancellationToken cancellationToken, 
                                 IProgress<bool> progress)
   {
       while(true)
       {
           await Task.Delay(TimeSpan.FromSeconds(10), cancellationToken);
           bool success = false;
           try
           {
               await DownloadStringAsync(url);
               success = true;
           }
           catch { /* ignore errors */ }
           progress.Report(success);
       }
   }
   // </Snippet5>
   
   static Task<string> DownloadStringAsync(Uri url) 
   { 
      var tcs = new TaskCompletionSource<string>();
      return tcs.Task; 
   }

}

public class Pattern
{
   int value = 0;

   // <Snippet2>
   public Task<int> MethodAsync(string input)
   {
       if (input == null) throw new ArgumentNullException("input");
       return MethodAsyncInternal(input);
   }
   
   private async Task<int> MethodAsyncInternal(string input)
   {

      // code that uses await goes here

      return value;
   }
   // </Snippet2>
   
   // <Snippet3>
   internal Task<Bitmap> RenderAsync(
                 ImageData data, CancellationToken cancellationToken)
   {
       return Task.Run(() =>
       {
           var bmp = new Bitmap(data.Width, data.Height);
           for(int y=0; y<data.Height; y++)
           {
               cancellationToken.ThrowIfCancellationRequested();
               for(int x=0; x<data.Width; x++)
               {
                   // render pixel [x,y] into bmp
               }
           }
           return bmp;
       }, cancellationToken);
   }
   // </Snippet3> 
     
   // <Snippet6>
   public static Task<bool> Delay(int millisecondsTimeout)
   {
        TaskCompletionSource<bool> tcs = null;
        Timer timer = null;
 
        timer = new Timer(delegate
        {
            timer.Dispose();
            tcs.TrySetResult(true);
        }, null, Timeout.Infinite, Timeout.Infinite);
 
        tcs = new TaskCompletionSource<bool>(timer);
        timer.Change(millisecondsTimeout, Timeout.Infinite);
        return tcs.Task;
   }
   // </Snippet6> 
   
   // <Snippet7>
   public async Task<Bitmap> DownloadDataAndRenderImageAsync(
       CancellationToken cancellationToken)
   {
       var imageData = await DownloadImageDataAsync(cancellationToken);
       return await RenderAsync(imageData, cancellationToken);
   }
   // </Snippet7>
   
   private async Task<ImageData> DownloadImageDataAsync(CancellationToken c)
   {
      // return new TaskCompletionSource<ImageData>().Task;
      return new ImageData();
   }
}

internal class ImageData
{
    public int Width = 0;
    public int Height = 0;
}