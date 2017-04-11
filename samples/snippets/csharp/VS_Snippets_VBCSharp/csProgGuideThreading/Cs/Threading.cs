//Copyright (C) Microsoft Corporation.  All rights reserved.

//<Snippet1>
using System;
using System.Threading;

public class Worker
{
    // This method is called when the thread is started.
    //<Snippet2>
    public void DoWork()
    {
        while (!_shouldStop)
        {
            Console.WriteLine("Worker thread: working...");
        }
        Console.WriteLine("Worker thread: terminating gracefully.");
    }
    //</Snippet2>
    //<Snippet3>
    public void RequestStop()
    {
        _shouldStop = true;
    }
    //</Snippet3>
    // Keyword volatile is used as a hint to the compiler that this data
    // member is accessed by multiple threads.
    //<Snippet4>
    private volatile bool _shouldStop;
    //</Snippet4>
}

public class WorkerThreadExample
{
    static void Main()
    {
        // Create the worker thread object. This does not start the thread.
        //<Snippet5>
        Worker workerObject = new Worker();
        Thread workerThread = new Thread(workerObject.DoWork);
        //</Snippet5>

        // Start the worker thread.
        //<Snippet6>
        workerThread.Start();
        //</Snippet6>
        Console.WriteLine("Main thread: starting worker thread...");

        // Loop until the worker thread activates.
        //<Snippet7>
        while (!workerThread.IsAlive) ;
        //</Snippet7>

        // Put the main thread to sleep for 1 millisecond to
        // allow the worker thread to do some work.
        //<Snippet8>
        Thread.Sleep(1);
        //</Snippet8>

        // Request that the worker thread stop itself.
        //<Snippet9>
        workerObject.RequestStop();
        //</Snippet9>

        // Use the Thread.Join method to block the current thread 
        // until the object's thread terminates.
        //<Snippet10>
        workerThread.Join();
        //</Snippet10>
        Console.WriteLine("Main thread: worker thread has terminated.");
    }
    // Sample output:
    // Main thread: starting worker thread...
    // Worker thread: working...
    // Worker thread: working...
    // Worker thread: working...
    // Worker thread: working...
    // Worker thread: working...
    // Worker thread: working...
    // Worker thread: terminating gracefully.
    // Main thread: worker thread has terminated.
}
//</Snippet1>
