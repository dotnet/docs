//<Snippet1>
using System;
using System.Threading;

public class Test
{
    public static void Main()
    {
        // Create the named mutex. Only one system object named 
        // "MyMutex" can exist; the local Mutex object represents 
        // this system object, regardless of which process or thread
        // caused "MyMutex" to be created.
        Mutex m = new Mutex(false, "MyMutex");
        
        // Try to gain control of the named mutex. If the mutex is 
        // controlled by another thread, wait for it to be released.        
        Console.WriteLine("Waiting for the Mutex.");
        m.WaitOne();

        // Keep control of the mutex until the user presses
        // ENTER.
        Console.WriteLine("This application owns the mutex. " +
            "Press ENTER to release the mutex and exit.");
        Console.ReadLine();

        m.ReleaseMutex();
    }
}
//</Snippet1>
