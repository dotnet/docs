// <Snippet1>
using System;
using System.Threading;

class ApartmentTest
{
    static void Main()
    {
        Thread newThread = 
            new Thread(new ThreadStart(ThreadMethod));
        newThread.SetApartmentState(ApartmentState.MTA);

        Console.WriteLine("ThreadState: {0}, ApartmentState: {1}", 
            newThread.ThreadState, newThread.ApartmentState);

        newThread.Start();

        // Wait for newThread to start and go to sleep.
        Thread.Sleep(300);
        try
        {
            // This causes an exception since newThread is sleeping.
            newThread.SetApartmentState(ApartmentState.STA);
        }
        catch(ThreadStateException stateException)
        {
            Console.WriteLine("\n{0} caught:\n" +
                "Thread is not in the Unstarted or Running state.", 
                stateException.GetType().Name);
            Console.WriteLine("ThreadState: {0}, ApartmentState: {1}",
                newThread.ThreadState, newThread.GetApartmentState());
        }
    }

    static void ThreadMethod()
    {
        Thread.Sleep(1000);
    }
}
// </Snippet1>