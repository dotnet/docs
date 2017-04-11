//<snippet01>
using System;
using System.Threading;
using System.Threading.Tasks;

class SpinWaitDemo
{
    // Demonstrates:
    //      SpinWait construction
    //      SpinWait.SpinOnce()
    //      SpinWait.NextSpinWillYield
    //      SpinWait.Count
    static void Main()
    {
        bool someBoolean = false;
        int numYields = 0;

        // First task: SpinWait until someBoolean is set to true
        Task t1 = Task.Factory.StartNew(() =>
        {
            SpinWait sw = new SpinWait();
            while (!someBoolean)
            {
                // The NextSpinWillYield property returns true if
                // calling sw.SpinOnce() will result in yielding the
                // processor instead of simply spinning.
                if (sw.NextSpinWillYield) numYields++;
                sw.SpinOnce();
            }

            // As of .NET Framework 4: After some initial spinning, SpinWait.SpinOnce() will yield every time.
            Console.WriteLine("SpinWait called {0} times, yielded {1} times", sw.Count, numYields);
        });

        // Second task: Wait 100ms, then set someBoolean to true
        Task t2 = Task.Factory.StartNew(() =>
        {
            Thread.Sleep(100);
            someBoolean = true;
        });

        // Wait for tasks to complete
        Task.WaitAll(t1, t2);
    }
}
//</snippet01>