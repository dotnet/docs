// How to: Cancel Threads Cooperatively

//<snippet14>
using System;
using System.Threading;

public class ServerClass
{
    public static void StaticMethod(object? obj)
    {
        if (obj is null)
            return;

        CancellationToken ct = (CancellationToken)obj;
        Console.WriteLine("ServerClass.StaticMethod is running on another thread.");

        // Simulate work that can be canceled.
        while (!ct.IsCancellationRequested)
        {
            Thread.SpinWait(50000);
        }
        Console.WriteLine("The worker thread has been canceled. Press any key to exit.");
        Console.ReadKey(true);
    }
}

public class Simple
{
    public static void Main()
    {
        // The Simple class controls access to the token source.
        CancellationTokenSource cts = new CancellationTokenSource();

        Console.WriteLine("Press 'C' to terminate the application...\n");
        // Allow the UI thread to capture the token source, so that it
        // can issue the cancel command.
        Thread t1 = new Thread(() =>
        {
            if (Console.ReadKey(true).KeyChar.ToString().ToUpperInvariant() == "C")
                cts.Cancel();
        });

        // ServerClass sees only the token, not the token source.
        Thread t2 = new Thread(new ParameterizedThreadStart(ServerClass.StaticMethod));
        // Start the UI thread.

        t1.Start();

        // Start the worker thread and pass it the token.
        t2.Start(cts.Token);

        t2.Join();
        cts.Dispose();
    }
}
// The example displays the following output:
//       Press 'C' to terminate the application...
//
//       ServerClass.StaticMethod is running on another thread.
//       The worker thread has been canceled. Press any key to exit.
//</snippet14>
