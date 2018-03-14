//<Snippet1>
using System;
using System.Threading;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;

// Demonstrate CERs using abrupt thread aborts. Demonstrate there
// is always a finally invocation for any CER that is entered.
class AbruptThreadAbort
{
    public static int Main(String[] args)
    {
        // Run the test a few times--it is timing dependent. The argument 
        // passed in is the stack depth to create.
        for (int i = 0; i < 1000; i++)
            if (!Test(i % 5))
            {
                Console.WriteLine("Failed");
                return 0;
            }

        Console.WriteLine("Succeeded");
        return 100;
    }

    // Create a thread and tell it to create a stack of the required depth. 
    // The first 3 levels will contain CERs, those after will not. Wait for 
    // the thread to start up, but abort it immediately. The thread may be 
    // in the process of setting the stack up at the point the abort occurs.
    // Check a state variable after the thread exits to determine if there is 
    // a consistent state following the abort. Each level of the stack with a
    // CER maintains a consistency variable that is reset on entry to the try 
    // and set in the corresponding finally block. None of these variables 
    // should be in a reset state after aborting the thread.
    static bool Test(int d)
    {
        // Create the context for the thread. This sets the stack depth for 
        // the thread and gives the final consistency state after the abort.
        WorkUnit wu = new WorkUnit(d);

        // Create and start the thread.
        Thread t = new Thread(new ThreadStart(wu.StackDepth1));
        t.Start();

        // Wait until the thread is ready to begin.
        wu.wait.WaitOne();

        // Abort immediately. This will occassionally interrupt the thread 
        // as it is setting up the stack, which is good.
        t.Abort();

        // Wait for the thread to exit.
        t.Join();

        // Check the final state for consistency.
        return wu.consistentLevel1;
    }
}

// Context class for the thread worker.
class WorkUnit
{
    public EventWaitHandle wait;
    public bool consistentLevel1;
    public bool consistentLevel2;
    public bool consistentLevel3;
    public int depth;

    public WorkUnit(int d)
    {
        wait = new EventWaitHandle(false, EventResetMode.AutoReset);
        depth = d;
    }
    //<Snippet2>
    public void StackDepth1()
    {
        // Declare the root CER.
        RuntimeHelpers.PrepareConstrainedRegions();
        try
        {

            // Cannot be interrupted until the event set below, so set up 
            // for initial success. Level 1 consistency is achieved by 
            // executing the finally; the other two levels are assumed 
            // consistent.
            consistentLevel1 = false;
            consistentLevel2 = true;
            consistentLevel3 = true;

            // Signal the parent thread. From this point on, the thread 
            // can be aborted.
            wait.Set();

            // Halt now if we want a one-level stack.
            if (depth == 1)
                Thread.Sleep(-1);

            // Else move to the next level.
            StackDepth2();

        }
        finally
        {
            // We should always get here. Compute consistency based on 
            // all the levels.
            consistentLevel1 = consistentLevel2 && consistentLevel3;
        }
    }
    //</Snippet2>

    //<Snippet3>
    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    void StackDepth2()
    {
        try
        {
            consistentLevel2 = false;
            if (depth == 2)
                Thread.Sleep(-1);
            StackDepth3();
        }
        finally
        {
            consistentLevel2 = true;
        }
    }
    //</Snippet3>
    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    void StackDepth3()
    {
        try
        {
            consistentLevel3 = false;
            if (depth == 3)
                Thread.Sleep(-1);
            StackDepth4();
        }
        finally
        {
            consistentLevel3 = true;
        }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    void StackDepth4()
    {
        if (depth == 4)
            Thread.Sleep(-1);
        StackDepth5();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    void StackDepth5()
    {
        Thread.Sleep(-1);
    }
}
//</Snippet1>
