//<Snippet1>
using System;
using System.Threading;

public class Example
{
    // A semaphore that can satisfy at most two concurrent
    // requests.
    //
    private static Semaphore _pool = new Semaphore(2, 2);

    public static void Main()
    {
        // Create and start two threads, A and B. 
        //
        Thread tA = new Thread(new ThreadStart(ThreadA));
        tA.Start();

        Thread tB = new Thread(new ThreadStart(ThreadB));
        tB.Start();
    }

    private static void ThreadA()
    {
        // Thread A enters the semaphore and simulates a task
        // that lasts a second.
        //
        _pool.WaitOne();
        Console.WriteLine("Thread A entered the semaphore.");

        Thread.Sleep(1000);

        try
        {
            _pool.Release();
            Console.WriteLine("Thread A released the semaphore.");
        }
        catch(Exception ex)
        {
            Console.WriteLine("Thread A: {0}", ex.Message);
        }
    }

    private static void ThreadB()
    {
        // Thread B simulates a task that lasts half a second,
        // then enters the semaphore.
        //
        Thread.Sleep(500);

        _pool.WaitOne();
        Console.WriteLine("Thread B entered the semaphore.");
        
        // Due to a programming error, Thread B releases the
        // semaphore twice. To fix the program, delete one line.
        _pool.Release();
        _pool.Release();
        Console.WriteLine("Thread B exits successfully.");
    }
}
/* This code example produces the following output:

Thread A entered the semaphore.
Thread B entered the semaphore.
Thread B exits successfully.
Thread A: Adding the given count to the semaphore would cause it to exceed its maximum count.
 */
//</Snippet1>



