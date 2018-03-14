// C# and VB versions originally written by REDMOND\glennha
//<Snippet1>
using System;
using System.Threading;
using System.Runtime.InteropServices;

public class Example
{
    public static void Main()
    {
        // 1. Queue ThreadProc as a task for a ThreadPool thread.
        ThreadPool.QueueUserWorkItem(ThreadProc, " from a ThreadPool thread");
        Thread.Sleep(1000);

        // 2. Execute ThreadProc on an ordinary thread.
        Thread t = new Thread(ThreadProc);
        t.Start(" from an ordinary thread");
        t.Join();

        // 3. Execute ThreadProc on the main thread, with 
        //    exception handling.
        try
        {
            ThreadProc(" from the main application thread (handled)");
        }
        catch (AppDomainUnloadedException adue)
        {
            Console.WriteLine("Main thread caught AppDomainUnloadedException: {0}", adue.Message);
        }

        // 4. Execute ThreadProc on the main thread without
        //    exception handling.
        ThreadProc(" from the main application thread (unhandled)");

        Console.WriteLine("Main: This message is never displayed.");
    }

    private static void ThreadProc(object state)
    {
        // Create an application domain, and create an instance
        // of TestClass in the application domain. The first
        // parameter of CreateInstanceAndUnwrap is the name of
        // this executable. If you compile the example code using
        // any name other than "Sample.exe", you must change the
        // parameter appropriately.
        AppDomain ad = AppDomain.CreateDomain("TestDomain");
        TestClass tc = (TestClass)ad.CreateInstanceAndUnwrap("Sample", "TestClass");

        // In the new application domain, execute a method that
        // unloads the AppDomain. The unhandled exception this
        // causes ends the current thread.
        tc.UnloadCurrentDomain(state);

        Console.WriteLine("ThreadProc: This message is never displayed.");
    }
}

// TestClass derives from MarshalByRefObject, so it can be marshaled
// across application domain boundaries. 
//
public class TestClass : MarshalByRefObject
{
    public void UnloadCurrentDomain(object state)
    {
        Console.WriteLine("\nUnloading the current AppDomain{0}.", state);
 
        // Unload the current application domain. This causes
        // an AppDomainUnloadedException to be thrown.
        //
        AppDomain.Unload(AppDomain.CurrentDomain);
    }
}

/* This code example produces output similar to the following:
Unloading the current AppDomain from a ThreadPool thread.

Unloading the current AppDomain from an ordinary thread.

Unloading the current AppDomain from the main application thread (handled).
Main thread caught AppDomainUnloadedException: The application domain in which the thread was running has been unloaded.

Unloading the current AppDomain from the main application thread (unhandled).

Unhandled Exception: System.AppDomainUnloadedException: The application domain in which the thread was running has been unloaded.
   at TestClass.UnloadCurrentDomain(Object state)
   at Example.ThreadProc(Object state)
   at Example.Main()
 */
//</Snippet1>
