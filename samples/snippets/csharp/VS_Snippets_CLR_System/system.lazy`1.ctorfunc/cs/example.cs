//<SnippetAll>
using System;
using System.Threading;

class Program
{
    static Lazy<LargeObject> lazyLargeObject = null;

    //<SnippetFactoryFunc>
    static LargeObject InitLargeObject()
    {
        return new LargeObject();
    }
    //</SnippetFactoryFunc>


    static void Main()
    {
        // The lazy initializer is created here. LargeObject is not created until the 
        // ThreadProc method executes.
        //<SnippetNewLazy>
        lazyLargeObject = new Lazy<LargeObject>(InitLargeObject);

        // The following lines show how to use other constructors to achieve exactly the
        // same result as the previous line: 
        //lazyLargeObject = new Lazy<LargeObject>(InitLargeObject, true);
        //lazyLargeObject = new Lazy<LargeObject>(InitLargeObject, LazyThreadSafetyMode.ExecutionAndPublication);
        //</SnippetNewLazy>


        Console.WriteLine(
            "\r\nLargeObject is not created until you access the Value property of the lazy" +
            "\r\ninitializer. Press Enter to create LargeObject.");
        Console.ReadLine();

        // Create and start 3 threads, each of which tries to use LargeObject.
        Thread[] threads = { new Thread(ThreadProc), new Thread(ThreadProc), new Thread(ThreadProc) };
        foreach (Thread t in threads)
        {
            t.Start();
        }

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
        //<SnippetValueProp>
        try
        {
            LargeObject large = lazyLargeObject.Value;

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
        catch (ApplicationException aex)
        {
            Console.WriteLine("Exception: {0}", aex.Message);
        }
        //</SnippetValueProp>
    }
}

class LargeObject
{
    int initBy = 0;
    public int InitializedBy { get { return initBy; } }

    //<SnippetLargeCtor>
    static int instanceCount = 0;
    public LargeObject()
    {
        if (1 == Interlocked.Increment(ref instanceCount))
        {
            throw new ApplicationException("Throw only ONCE.");
        }

        initBy = Thread.CurrentThread.ManagedThreadId;
        Console.WriteLine("LargeObject was created on thread id {0}.", initBy);
    }
    //</SnippetLargeCtor>
    public long[] Data = new long[100000000];
}

/* This example produces output similar to the following:

LargeObject is not created until you access the Value property of the lazy
initializer. Press Enter to create LargeObject.

Exception: Throw only ONCE.
Exception: Throw only ONCE.
Exception: Throw only ONCE.

Press Enter to end the program
 */
//</SnippetAll>

