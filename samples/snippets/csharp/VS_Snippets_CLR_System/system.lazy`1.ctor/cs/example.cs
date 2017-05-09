//<SnippetAll>
using System;
using System.Threading;

class Program
{
    static Lazy<LargeObject> lazyLargeObject = null;

    static void Main()
    {
        // The lazy initializer is created here. LargeObject is not created until the 
        // ThreadProc method executes.
        //<SnippetNewLazy>
        lazyLargeObject = new Lazy<LargeObject>();

        // The following lines show how to use other constructors to achieve exactly the
        // same result as the previous line: 
        //lazyLargeObject = new Lazy<LargeObject>(true);
        //lazyLargeObject = new Lazy<LargeObject>(LazyThreadSafetyMode.ExecutionAndPublication);
        //</SnippetNewLazy>


        Console.WriteLine(
            "\r\nLargeObject is not created until you access the Value property of the lazy" +
            "\r\ninitializer. Press Enter to create LargeObject.");
        Console.ReadLine();

        // Create and start 3 threads, passing the same blocking event to all of them.
        ManualResetEvent startingGate = new ManualResetEvent(false);
        Thread[] threads = { new Thread(ThreadProc), new Thread(ThreadProc), new Thread(ThreadProc) };
        foreach (Thread t in threads)
        {
            t.Start(startingGate);
        }

        // Give all 3 threads time to start and wait, then release them all at once.
        Thread.Sleep(100);
        startingGate.Set();

        // Wait for all 3 threads to finish. (The order doesn't matter.)
        foreach (Thread t in threads)
        {
            t.Join();
        }

        Console.WriteLine("\r\nPress Enter to end the program");
        Console.ReadLine();
    }


    static void ThreadProc(object state)
    {
        // Wait for the signal.
        ManualResetEvent waitForStart = (ManualResetEvent) state;
        waitForStart.WaitOne();

        //<SnippetValueProp>
        LargeObject large = lazyLargeObject.Value;
        //</SnippetValueProp>

        // The following line introduces an artificial delay, to exaggerate the race 
        // condition.
        Thread.Sleep(5); 

        // IMPORTANT: Lazy initialization is thread-safe, but it doesn't protect the  
        //            object after creation. You must lock the object before accessing it,
        //            unless the type is thread safe. (LargeObject is not thread safe.)
        lock(large)
        {
            large.Data[0] = Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine("Initialized by thread {0}; last used by thread {1}.", 
                large.InitializedBy, large.Data[0]);
        }
    }
}

class LargeObject
{
    int initBy = 0;
    public int InitializedBy { get { return initBy; } }

    public LargeObject()
    {
        initBy = Thread.CurrentThread.ManagedThreadId;
        Console.WriteLine("LargeObject was created on thread id {0}.", initBy);
    }
    public long[] Data = new long[100000000];
}

/* This example produces output similar to the following:

LargeObject is not created until you access the Value property of the lazy
initializer. Press Enter to create LargeObject.

LargeObject was created on thread id 4.
Initialized by thread 4; last used by thread 3.
Initialized by thread 4; last used by thread 4.
Initialized by thread 4; last used by thread 5.

Press Enter to end the program
 */
//</SnippetAll>
