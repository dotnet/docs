//<snippet2>
using System;
using System.Threading;

public class ServerClass
{
    // The method that will be called when the thread is started.
    public void InstanceMethod()
    {
        Console.WriteLine(
            "ServerClass.InstanceMethod is running on another thread.");

        // Pause for a moment to provide a delay to make
        // threads more apparent.
        Thread.Sleep(3000);
        Console.WriteLine(
            "The instance method called by the worker thread has ended.");
    }

    public static void StaticMethod()
    {
        Console.WriteLine(
            "ServerClass.StaticMethod is running on another thread.");

        // Pause for a moment to provide a delay to make
        // threads more apparent.
        Thread.Sleep(5000);
        Console.WriteLine(
            "The static method called by the worker thread has ended.");
    }
}

public class Simple
{
    public static void Main()
    {
        ServerClass serverObject = new ServerClass();

        // Create the thread object, passing in the
        // serverObject.InstanceMethod method using a
        // ThreadStart delegate.
        Thread InstanceCaller = new(new ThreadStart(serverObject.InstanceMethod));

        // Start the thread.
        InstanceCaller.Start();

        Console.WriteLine("The Main() thread calls this after "
            + "starting the new InstanceCaller thread.");

        // Create the thread object, passing in the
        // ServerClass.StaticMethod method using a
        // ThreadStart delegate.
        Thread StaticCaller = new(new ThreadStart(ServerClass.StaticMethod));

        // Start the thread.
        StaticCaller.Start();

        Console.WriteLine("The Main() thread calls this after "
            + "starting the new StaticCaller thread.");
    }
}
// The example displays the output like the following:
//    The Main() thread calls this after starting the new InstanceCaller thread.
//    The Main() thread calls this after starting the new StaticCaller thread.
//    ServerClass.StaticMethod is running on another thread.
//    ServerClass.InstanceMethod is running on another thread.
//    The instance method called by the worker thread has ended.
//    The static method called by the worker thread has ended.
//</snippet2>
