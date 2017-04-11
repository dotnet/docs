// REDMOND\glennha
//<Snippet1>
using System;
using System.Threading;

class Example
{
    public static void Main()
    {
        Thread t = new Thread(ThreadProc);
        Console.WriteLine("Before setting apartment state: {0}", 
            t.GetApartmentState());

        t.SetApartmentState(ApartmentState.STA);
        Console.WriteLine("After setting apartment state: {0}", 
            t.GetApartmentState());

        bool result = t.TrySetApartmentState(ApartmentState.MTA);
        Console.WriteLine("Try to change state: {0}", result);

        t.Start();

        Thread.Sleep(500);

        try
        {
            t.TrySetApartmentState(ApartmentState.STA);
        }
        catch (ThreadStateException)
        {
            Console.WriteLine("ThreadStateException occurs " +
                "if apartment state is set after starting thread.");
        }

        t.Join();
    }

    public static void ThreadProc()
    {
        Thread.Sleep(2000);
    }
}

/* This code example produces the following output:

Before setting apartment state: Unknown
After setting apartment state: STA
Try to change state: False
ThreadStateException occurs if apartment state is set after starting thread.
 */
//</Snippet1>



