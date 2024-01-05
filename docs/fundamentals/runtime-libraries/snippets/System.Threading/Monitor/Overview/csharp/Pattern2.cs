using System;
using System.Runtime.CompilerServices;
using System.Threading;

public class Example3
{
    public static void Main()
    {
        // <Snippet2>
        // Define the lock object.
        var obj = new Object();

        // Define the critical section.
        Monitor.Enter(obj);
        try
        {
            // Code to execute one thread at a time.
        }
        // catch blocks go here.
        finally
        {
            Monitor.Exit(obj);
        }
        // </Snippet2>
    }

    // <Snippet3>
    [MethodImplAttribute(MethodImplOptions.Synchronized)]
    void MethodToLock()
    {
        // Method implementation.
    }
    // </Snippet3>
}
