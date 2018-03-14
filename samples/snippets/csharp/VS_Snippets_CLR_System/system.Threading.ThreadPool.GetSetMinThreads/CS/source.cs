// <Snippet1>
using System;
using System.Threading;

public class Test
{
    public static void Main()
    {
        int minWorker, minIOC;
        // Get the current settings.
        ThreadPool.GetMinThreads(out minWorker, out minIOC);
        // Change the minimum number of worker threads to four, but
        // keep the old setting for minimum asynchronous I/O 
        // completion threads.
        if (ThreadPool.SetMinThreads(4, minIOC))
        {
            // The minimum number of threads was set successfully.
        }
        else
        {
            // The minimum number of threads was not changed.
        }
    }
}
// </Snippet1>
