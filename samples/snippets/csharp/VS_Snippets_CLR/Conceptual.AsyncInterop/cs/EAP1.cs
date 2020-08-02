using System;
using System.Net;
using System.Threading.Tasks;

public class Example
{
    // <Snippet11>
    public static Task<string> DownloadStringAsync(Uri url)
    {
        var tcs = new TaskCompletionSource<string>();
        var wc = new WebClient();
        wc.DownloadStringCompleted += (s, e) =>
            {
                if (e.Error != null)
                    tcs.TrySetException(e.Error);
                else if (e.Cancelled)
                    tcs.TrySetCanceled();
                else
                    tcs.TrySetResult(e.Result);
            };
        wc.DownloadStringAsync(url);
        return tcs.Task;
    }
    // </Snippet11>
}
