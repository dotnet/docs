//<Snippet1>
using System;
using System.Threading;

public class Example
{
    public static void Main()
    {
        // The value of this variable is set by the semaphore
        // constructor. It is true if the named system semaphore was
        // created, and false if the named semaphore already existed.
        //
        bool semaphoreWasCreated;

        // Create a Semaphore object that represents the named 
        // system semaphore "SemaphoreExample". The semaphore has a
        // maximum count of five, and an initial count of two. The
        // Boolean value that indicates creation of the underlying 
        // system object is placed in semaphoreWasCreated.
        //
        Semaphore sem = new Semaphore(2, 5, "SemaphoreExample", 
            out semaphoreWasCreated);

        if (semaphoreWasCreated)
        {
            // If the named system semaphore was created, its count is
            // set to the initial count requested in the constructor.
            // In effect, the current thread has entered the semaphore
            // three times.
            // 
            Console.WriteLine("Entered the semaphore three times.");
        }
        else
        {      
            // If the named system semaphore was not created,  
            // attempt to enter it three times. If another copy of
            // this program is already running, only the first two
            // requests can be satisfied. The third blocks.
            //
            sem.WaitOne();
            Console.WriteLine("Entered the semaphore once.");
            sem.WaitOne();
            Console.WriteLine("Entered the semaphore twice.");
            sem.WaitOne();
            Console.WriteLine("Entered the semaphore three times.");
        }

        // The thread executing this program has entered the 
        // semaphore three times. If a second copy of the program
        // is run, it will block until this program releases the 
        // semaphore at least once.
        //
        Console.WriteLine("Enter the number of times to call Release.");
        int n;
        if (int.TryParse(Console.ReadLine(), out n))
        {
            sem.Release(n);
        }

        int remaining = 3 - n;
        if (remaining > 0)
        {
            Console.WriteLine("Press Enter to release the remaining " +
                "count ({0}) and exit the program.", remaining);
            Console.ReadLine();
            sem.Release(remaining);
        }
    } 
} 
//</Snippet1>


