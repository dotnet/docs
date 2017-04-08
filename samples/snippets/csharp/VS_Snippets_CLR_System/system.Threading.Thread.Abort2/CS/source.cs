// <Snippet1>
using System;
using System.Threading;

class Test
{
    public static void Main()
    {
        Thread newThread  = new Thread(new ThreadStart(TestMethod));
        newThread.Start();
        Thread.Sleep(1000);

        // Abort newThread.
        Console.WriteLine("Main aborting new thread.");
        newThread.Abort("Information from Main.");

        // Wait for the thread to terminate.
        newThread.Join();
        Console.WriteLine("New thread terminated - Main exiting.");
    }

    static void TestMethod()
    {
        try
        {
            while(true)
            {
                Console.WriteLine("New thread running.");
                Thread.Sleep(1000);
            }
        }
        catch(ThreadAbortException abortException)
        {
            Console.WriteLine((string)abortException.ExceptionState);
        }
    }
}
// </Snippet1>