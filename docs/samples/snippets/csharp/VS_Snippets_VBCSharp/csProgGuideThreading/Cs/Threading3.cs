//<Snippet17>
using System;
using System.Threading;

class MutexSample
{
    static Mutex gM1;
    static Mutex gM2;

    const int ITERS = 100;

    static AutoResetEvent Event1 = new AutoResetEvent(false);
    static AutoResetEvent Event2 = new AutoResetEvent(false);
    static AutoResetEvent Event3 = new AutoResetEvent(false);
    static AutoResetEvent Event4 = new AutoResetEvent(false);
    
    static void Main()
    {
        Console.WriteLine("Mutex Sample ...");

        // Create Mutex initialOwned, with name of "Mutex1".
        gM1 = new Mutex(true,"Mutex1");

        // Create Mutex initialOwned, with no name.
        gM2 = new Mutex(true);

        Console.WriteLine(" - Main Owns gM1 and gM2");

        AutoResetEvent[] events = new AutoResetEvent[4];
        
        events[0] = Event1;  // event for thread 1
        events[1] = Event2;  // event for thread 2
        events[2] = Event3;  // event for thread 3
        events[3] = Event4;  // event for thread 4

        MutexSample ms = new MutexSample( );

        Thread t1 = new Thread(new ThreadStart(ms.t1Start));
        Thread t2 = new Thread(new ThreadStart(ms.t2Start));
        Thread t3 = new Thread(new ThreadStart(ms.t3Start));
        Thread t4 = new Thread(new ThreadStart(ms.t4Start));

        t1.Start();  // calls Mutex.WaitAll(Mutex[] of gM1 and gM2)
        t2.Start();  // calls Mutex.WaitOne(Mutex gM1)
        t3.Start();  // calls Mutex.WaitAny(Mutex[] of gM1 and gM2)
        t4.Start();  // calls Mutex.WaitOne(Mutex gM2)

        Thread.Sleep(2000);

        Console.WriteLine(" - Main releases gM1");
        gM1.ReleaseMutex( );  // t2 and t3 will end and signal

        Thread.Sleep(1000);

        Console.WriteLine(" - Main releases gM2");
        gM2.ReleaseMutex( );  // t1 and t4 will end and signal

        // Waiting until all four threads signal that they are done.
        WaitHandle.WaitAll(events); 

        Console.WriteLine("... Mutex Sample");
    }

    public void t1Start( )
    {
        Console.WriteLine("t1Start started,  Mutex.WaitAll(Mutex[])");

        // Create and load an array of Mutex for WaitAll call.
        Mutex[] gMs = new Mutex[2];
        gMs[0] = gM1;
        gMs[1] = gM2;

        // Waits until both gM1 and gM2 are released.
        Mutex.WaitAll(gMs);

        Thread.Sleep(2000);
        Console.WriteLine("t1Start finished, Mutex.WaitAll(Mutex[]) satisfied");
        gM1.ReleaseMutex();
        gM2.ReleaseMutex();

        // AutoResetEvent.Set() flagging method is done.
        Event1.Set( );
    }

    public void t2Start( )
    {
        Console.WriteLine("t2Start started,  gM1.WaitOne( )");

        // Waits until Mutex gM1 is released.
        gM1.WaitOne( );
        Console.WriteLine("t2Start finished, gM1.WaitOne( ) satisfied");
        gM1.ReleaseMutex();

        // AutoResetEvent.Set() flagging method is done.
        Event2.Set( );
    }

    public void t3Start( )
    {
        Console.WriteLine("t3Start started,  Mutex.WaitAny(Mutex[])");

        // Create and load an array of Mutex for WaitAny call.
        Mutex[] gMs = new Mutex[2];
        gMs[0] = gM1;
        gMs[1] = gM2;

        // Waits until either Mutex is released.
        int index = Mutex.WaitAny(gMs);
        Console.WriteLine("t3Start finished, Mutex.WaitAny(Mutex[])");
        gMs[index].ReleaseMutex();

        // AutoResetEvent.Set() flagging method is done.
        Event3.Set( );
    }

    public void t4Start( )
    {
        Console.WriteLine("t4Start started,  gM2.WaitOne( )");

        // Waits until Mutex gM2 is released.
        gM2.WaitOne( );
        Console.WriteLine("t4Start finished, gM2.WaitOne( )");
        gM2.ReleaseMutex();

        // AutoResetEvent.Set() flagging method is done.
        Event4.Set( );
    }
}
//</Snippet17>
