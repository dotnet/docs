// <Snippet1>
using System;
using System.Threading;

class Name
{
    static void Main()
    {
        // Check whether the thread has previously been named
        // to avoid a possible InvalidOperationException.
        if(Thread.CurrentThread.Name == null)
        {
            Thread.CurrentThread.Name = "MainThread";
        }
        else
        {
            Console.WriteLine("Unable to name a previously " +
                "named thread.");
        }
    }
}
// </Snippet1>