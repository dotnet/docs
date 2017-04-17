// <snippet3>
using System;
using System.Threading;

// TaskInfo contains data that will be passed to the callback
// method.
public class TaskInfo
{
    public RegisteredWaitHandle Handle = null;
    public string OtherInfo = "default";
}

public class Example
{
    public static void Main(string[] args)
    {
        // The main thread uses AutoResetEvent to signal the
        // registered wait handle, which executes the callback
        // method.
        AutoResetEvent ev = new AutoResetEvent(false);

        TaskInfo ti = new TaskInfo();
        ti.OtherInfo = "First task";
        // The TaskInfo for the task includes the registered wait
        // handle returned by RegisterWaitForSingleObject.  This
        // allows the wait to be terminated when the object has
        // been signaled once (see WaitProc).
        ti.Handle = ThreadPool.RegisterWaitForSingleObject(
            ev,
            new WaitOrTimerCallback(WaitProc),
            ti,
            1000,
            false );

        // The main thread waits three seconds, to demonstrate the
        // time-outs on the queued thread, and then signals.
        Thread.Sleep(3100);
        Console.WriteLine("Main thread signals.");
        ev.Set();

        // The main thread sleeps, which should give the callback
        // method time to execute.  If you comment out this line, the
        // program usually ends before the ThreadPool thread can execute.
        Thread.Sleep(1000);
        // If you start a thread yourself, you can wait for it to end
        // by calling Thread.Join.  This option is not available with
        // thread pool threads.
    }

    // The callback method executes when the registered wait times out,
    // or when the WaitHandle (in this case AutoResetEvent) is signaled.
    // WaitProc unregisters the WaitHandle the first time the event is
    // signaled.
    public static void WaitProc(object state, bool timedOut)
    {
        // The state object must be cast to the correct type, because the
        // signature of the WaitOrTimerCallback delegate specifies type
        // Object.
        TaskInfo ti = (TaskInfo) state;

        string cause = "TIMED OUT";
        if (!timedOut)
        {
            cause = "SIGNALED";
            // If the callback method executes because the WaitHandle is
            // signaled, stop future execution of the callback method
            // by unregistering the WaitHandle.
            if (ti.Handle != null)
                ti.Handle.Unregister(null);
        }

        Console.WriteLine("WaitProc( {0} ) executes on thread {1}; cause = {2}.",
            ti.OtherInfo,
            Thread.CurrentThread.GetHashCode().ToString(),
            cause
        );
    }
}
// </snippet3>
