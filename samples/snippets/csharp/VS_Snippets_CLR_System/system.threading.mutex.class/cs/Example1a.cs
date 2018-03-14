
// <Snippet3>
using System;
using System.Threading;

class Example
{
    // Create a new Mutex. The creating thread does not own the mutex.
    private static Mutex mut = new Mutex();
    private const int numIterations = 1;
    private const int numThreads = 3;

    static void Main()
    {
        // Create the threads that will use the protected resource.
        for(int i = 0; i < numThreads; i++)
        {
            Thread newThread = new Thread(new ThreadStart(ThreadProc));
            newThread.Name = String.Format("Thread{0}", i + 1);
            newThread.Start();
        }

        // The main thread exits, but the application continues to
        // run until all foreground threads have exited.
    }

    private static void ThreadProc()
    {
        for(int i = 0; i < numIterations; i++)
        {
            UseResource();
        }
    }

    // This method represents a resource that must be synchronized
    // so that only one thread at a time can enter.
    private static void UseResource()
    {
        // Wait until it is safe to enter.
        Console.WriteLine("{0} is requesting the mutex", 
                          Thread.CurrentThread.Name);
        mut.WaitOne();

        Console.WriteLine("{0} has entered the protected area", 
                          Thread.CurrentThread.Name);

        // Place code to access non-reentrant resources here.

        // Simulate some work.
        Thread.Sleep(500);

        Console.WriteLine("{0} is leaving the protected area", 
            Thread.CurrentThread.Name);

        // Release the Mutex.
        mut.ReleaseMutex();
        Console.WriteLine("{0} has released the mutex", 
            Thread.CurrentThread.Name);
    }
}
// The example displays output like the following:
//       Thread1 is requesting the mutex
//       Thread2 is requesting the mutex
//       Thread1 has entered the protected area
//       Thread3 is requesting the mutex
//       Thread1 is leaving the protected area
//       Thread1 has released the mutex
//       Thread3 has entered the protected area
//       Thread3 is leaving the protected area
//       Thread3 has released the mutex
//       Thread2 has entered the protected area
//       Thread2 is leaving the protected area
//       Thread2 has released the mutex
// </Snippet3>
