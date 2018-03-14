//<snippet10>
using System;
using System.Diagnostics;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;

// Remote object.
public class RemoteService : MarshalByRefObject
{
    private DateTime startTime;

    public RemoteService()
    {
        // Notify the user that the constructor was invoked.
        Console.WriteLine("Constructor invoked.");
        startTime = DateTime.Now;
    }

    ~RemoteService()
    {
        // Notify the user that the destructor was invoked.
        TimeSpan elapsedTime = 
            new TimeSpan(DateTime.Now.Ticks - startTime.Ticks);
        Console.WriteLine("Destructor invoked after " + 
            elapsedTime.ToString() + " seconds.");
    }

    public void Hello(string name)
    {
        // Print a simple message.
        Console.WriteLine("Hello, " + name);
    }
}
//</snippet10>
