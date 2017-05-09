// Alternative to using SignalTime to ensure that Elapsed 
// events are not processed if they occur after the timer 
// has been stopped. The object is to avoid race conditions.
//
//<Snippet1>
using System;
using System.Timers;
using System.Threading;

public class Test
{    
    // Change these values to control the behavior of the program.
    private static int testRuns = 100;
    // Times are given in milliseconds:
    private static int testRunsFor = 500;
    private static int timerIntervalBase = 100;
    private static int timerIntervalDelta = 20;

    // Timers.
    private static System.Timers.Timer Timer1 = new System.Timers.Timer();
    private static System.Timers.Timer Timer2 = new System.Timers.Timer();
    private static System.Timers.Timer currentTimer = null;

    private static Random rand = new Random();

    // This is the synchronization point that prevents events
    // from running concurrently, and prevents the main thread 
    // from executing code after the Stop method until any 
    // event handlers are done executing.
    private static int syncPoint = 0;

    // Count the number of times the event handler is called,
    // is executed, is skipped, or is called after Stop.
    private static int numEvents = 0;
    private static int numExecuted = 0;
    private static int numSkipped = 0;
    private static int numLate = 0;

    // Count the number of times the thread that calls Stop
    // has to wait for an Elapsed event to finish.
    private static int numWaits = 0;

    [MTAThread]
    public static void Main()
    {
        Timer1.Elapsed += new ElapsedEventHandler(Timer1_ElapsedEventHandler);
        Timer2.Elapsed += new ElapsedEventHandler(Timer2_ElapsedEventHandler);

        Console.WriteLine();
        for(int i = 1; i <= testRuns; i++)
        {
            TestRun();
            Console.Write("\rTest {0}/{1}    ", i, testRuns);
        }

        Console.WriteLine("{0} test runs completed.", testRuns);
        Console.WriteLine("{0} events were raised.", numEvents);
        Console.WriteLine("{0} events executed.", numExecuted);
        Console.WriteLine("{0} events were skipped for concurrency.", numSkipped);
        Console.WriteLine("{0} events were skipped because they were late.", numLate);
        Console.WriteLine("Control thread waited {0} times for an event to complete.", numWaits);
    }

    public static void TestRun()
    {
        // Set syncPoint to zero before starting the test 
        // run. 
        syncPoint = 0;

        // Test runs alternate between Timer1 and Timer2, to avoid
        // race conditions between tests, or with very late events.
        if (currentTimer == Timer1)
            currentTimer = Timer2;
        else
            currentTimer = Timer1;

        currentTimer.Interval = timerIntervalBase 
            - timerIntervalDelta + rand.Next(timerIntervalDelta * 2);
        currentTimer.Enabled = true;

        // Start the control thread that shuts off the timer.
        Thread t = new Thread(ControlThreadProc);
        t.Start();

        // Wait until the control thread is done before proceeding.
        // This keeps the test runs from overlapping.
        t.Join();

    }


    private static void ControlThreadProc()
    {
        // Allow the timer to run for a period of time, and then 
        // stop it.
        Thread.Sleep(testRunsFor);
        currentTimer.Stop();

        // The 'counted' flag ensures that if this thread has
        // to wait for an event to finish, the wait only gets 
        // counted once.
        bool counted = false;

        // Ensure that if an event is currently executing,
        // no further processing is done on this thread until
        // the event handler is finished. This is accomplished
        // by using CompareExchange to place -1 in syncPoint,
        // but only if syncPoint is currently zero (specified
        // by the third parameter of CompareExchange). 
        // CompareExchange returns the original value that was
        // in syncPoint. If it was not zero, then there's an
        // event handler running, and it is necessary to try
        // again.
        while (Interlocked.CompareExchange(ref syncPoint, -1, 0) != 0)
        {
            // Give up the rest of this thread's current time
            // slice. This is a naive algorithm for yielding.
            Thread.Sleep(1);

            // Tally a wait, but don't count multiple calls to
            // Thread.Sleep.
            if (!counted)
            {
                numWaits += 1;
                counted = true;
            }
        }

        // Any processing done after this point does not conflict
        // with timer events. This is the purpose of the call to
        // CompareExchange. If the processing done here would not
        // cause a problem when run concurrently with timer events,
        // then there is no need for the extra synchronization.
    }


    // Event-handling methods for the Elapsed events of the two
    // timers.
    //
    private static void Timer1_ElapsedEventHandler(object sender, 
        ElapsedEventArgs e)
    {
        HandleElapsed(sender, e);
    }

    private static void Timer2_ElapsedEventHandler(object sender, 
        ElapsedEventArgs e)
    {
        HandleElapsed(sender, e);
    }

    private static void HandleElapsed(object sender, ElapsedEventArgs e)
    {
        numEvents += 1;

        // This example assumes that overlapping events can be
        // discarded. That is, if an Elapsed event is raised before 
        // the previous event is finished processing, the second
        // event is ignored. 
        //
        // CompareExchange is used to take control of syncPoint, 
        // and to determine whether the attempt was successful. 
        // CompareExchange attempts to put 1 into syncPoint, but
        // only if the current value of syncPoint is zero 
        // (specified by the third parameter). If another thread
        // has set syncPoint to 1, or if the control thread has
        // set syncPoint to -1, the current event is skipped. 
        // (Normally it would not be necessary to use a local 
        // variable for the return value. A local variable is 
        // used here to determine the reason the event was 
        // skipped.)
        //
        int sync = Interlocked.CompareExchange(ref syncPoint, 1, 0);
        if (sync == 0)
        {
            // No other event was executing.
            // The event handler simulates an amount of work
            // lasting between 50 and 200 milliseconds, so that
            // some events will overlap.
            int delay = timerIntervalBase 
                - timerIntervalDelta / 2 + rand.Next(timerIntervalDelta);
            Thread.Sleep(delay);
            numExecuted += 1;

            // Release control of syncPoint.
            syncPoint = 0;
        }
        else
        {
            if (sync == 1) { numSkipped += 1; } else { numLate += 1; }
        }
    }
}

/* On a dual-processor computer, this code example produces
   results similar to the following:

Test 100/100    100 test runs completed.
436 events were raised.
352 events executed.
84 events were skipped for concurrency.
0 events were skipped because they were late.
Control thread waited 77 times for an event to complete.
 */
//</Snippet1>



