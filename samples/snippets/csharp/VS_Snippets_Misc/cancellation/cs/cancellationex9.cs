// How to: Cancel by using a WaitHandle

//<snippet9>
using System;
using System.Threading;
using System.Threading.Tasks;

class CancelOldStyleEvents
{
    // Old-style MRE that doesn't support unified cancellation.
    static ManualResetEvent mre = new ManualResetEvent(false);

    static void Main()
    {
        var cts = new CancellationTokenSource();

        // Pass the same token source to the delegate and to the task instance.
        Task.Run(() => DoWork(cts.Token), cts.Token);
        Console.WriteLine("Press s to start/restart, p to pause, or c to cancel.");
        Console.WriteLine("Or any other key to exit.");

        // Old-style UI thread.
        bool goAgain = true;
        while (goAgain)
        {
            char ch = Console.ReadKey(true).KeyChar;

            switch (ch)
            {
                case 'c':
                    cts.Cancel();
                    break;
                case 'p':
                    mre.Reset();
                    break;
                case 's':
                    mre.Set();
                    break;
                default:
                    goAgain = false;
                    break;
            }

            Thread.Sleep(100);
        }
        cts.Dispose();
    }

    static void DoWork(CancellationToken token)
    {
        while (true)
        {
            //<snippet5>
            // Wait on the event if it is not signaled.
            int eventThatSignaledIndex =
                   WaitHandle.WaitAny(new WaitHandle[] { mre, token.WaitHandle },
                                      new TimeSpan(0, 0, 20));
            //</snippet5>

            // Were we canceled while waiting?
            if (eventThatSignaledIndex == 1)
            {
                Console.WriteLine("The wait operation was canceled.");
                throw new OperationCanceledException(token);
            }
            // Were we canceled while running?
            else if (token.IsCancellationRequested)
            {
                Console.WriteLine("I was canceled while running.");
                token.ThrowIfCancellationRequested();
            }
            // Did we time out?
            else if (eventThatSignaledIndex == WaitHandle.WaitTimeout)
            {
                Console.WriteLine("I timed out.");
                break;
            }
            else
            {
                Console.Write("Working... ");
                // Simulating work.
                Thread.SpinWait(5000000);
            }
        }
    }
}
//</snippet9>
