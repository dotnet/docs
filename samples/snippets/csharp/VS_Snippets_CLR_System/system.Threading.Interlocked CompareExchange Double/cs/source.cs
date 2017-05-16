//<Snippet1>
// This example demonstrates a thread-safe method that adds to a
// running total.  
using System;
using System.Threading;

public class ThreadSafe
{
    // Field totalValue contains a running total that can be updated
    // by multiple threads. It must be protected from unsynchronized 
    // access.
    private double totalValue = 0.0;

    // The Total property returns the running total.
    public double Total { get { return totalValue; }}

    // AddToTotal safely adds a value to the running total.
    public double AddToTotal(double addend)
    {
        double initialValue, computedValue;
        do
        {
            // Save the current running total in a local variable.
            initialValue = totalValue;

            // Add the new value to the running total.
            computedValue = initialValue + addend;

            // CompareExchange compares totalValue to initialValue. If
            // they are not equal, then another thread has updated the
            // running total since this loop started. CompareExchange
            // does not update totalValue. CompareExchange returns the
            // contents of totalValue, which do not equal initialValue,
            // so the loop executes again.
        }
        while (initialValue != Interlocked.CompareExchange(ref totalValue, 
            computedValue, initialValue));
        // If no other thread updated the running total, then 
        // totalValue and initialValue are equal when CompareExchange
        // compares them, and computedValue is stored in totalValue.
        // CompareExchange returns the value that was in totalValue
        // before the update, which is equal to initialValue, so the 
        // loop ends.

        // The function returns computedValue, not totalValue, because
        // totalValue could be changed by another thread between
        // the time the loop ends and the function returns.
        return computedValue;
    }
}

public class Test
{
    // Create an instance of the ThreadSafe class to test.
    private static ThreadSafe ts = new ThreadSafe();
    private static double control;

    private static Random r = new Random();
    private static ManualResetEvent mre = new ManualResetEvent(false);

    public static void Main()
    {
        // Create two threads, name them, and start them. The
        // thread will block on mre.
        Thread t1 = new Thread(TestThread);
        t1.Name = "Thread 1";
        t1.Start();
        Thread t2 = new Thread(TestThread);
        t2.Name = "Thread 2";
        t2.Start();

        // Now let the threads begin adding random numbers to 
        // the total.
        mre.Set();
        
        // Wait until all the threads are done.
        t1.Join();
        t2.Join();

        Console.WriteLine("Thread safe: {0}  Ordinary Double: {1}", 
            ts.Total, control);
    }

    private static void TestThread()
    {
        // Wait until the signal.
        mre.WaitOne();

        for(int i = 1; i <= 1000000; i++)
        {
            // Add to the running total in the ThreadSafe instance, and
            // to an ordinary double.
            //
            double testValue = r.NextDouble();
            control += testValue;
            ts.AddToTotal(testValue);
        }
    }
}

/* On a dual-processor computer, this code example produces output 
   similar to the following:

Thread safe: 998068.049623744  Ordinary Double: 759775.417190589
 */
//</Snippet1>


