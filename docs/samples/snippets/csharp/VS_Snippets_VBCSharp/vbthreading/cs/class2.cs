// How to: Use a Thread Pool
// 5426dae4c3f34e76a99819f7ca4baf3f

//<Snippet20>
using System;
using System.Threading;

public class Fibonacci
{
    private int _n;
    private int _fibOfN;
    private ManualResetEvent _doneEvent;

    public int N { get { return _n; } }
    public int FibOfN { get { return _fibOfN; } }

    // Constructor.
    public Fibonacci(int n, ManualResetEvent doneEvent)
    {
        _n = n;
        _doneEvent = doneEvent;
    }

    // Wrapper method for use with thread pool.
    public void ThreadPoolCallback(Object threadContext)
    {
        int threadIndex = (int)threadContext;
        Console.WriteLine("thread {0} started...", threadIndex);
        _fibOfN = Calculate(_n);
        Console.WriteLine("thread {0} result calculated...", threadIndex);
        _doneEvent.Set();
    }

    // Recursive method that calculates the Nth Fibonacci number.
    public int Calculate(int n)
    {
        if (n <= 1)
        {
            return n;
        }

        return Calculate(n - 1) + Calculate(n - 2);
    }
}

public class ThreadPoolExample
{
    static void Main()
    {
        const int FibonacciCalculations = 10;

        // One event is used for each Fibonacci object.
        ManualResetEvent[] doneEvents = new ManualResetEvent[FibonacciCalculations];
        Fibonacci[] fibArray = new Fibonacci[FibonacciCalculations];
        Random r = new Random();

        // Configure and start threads using ThreadPool.
        Console.WriteLine("launching {0} tasks...", FibonacciCalculations);
        for (int i = 0; i < FibonacciCalculations; i++)
        {
            doneEvents[i] = new ManualResetEvent(false);
            Fibonacci f = new Fibonacci(r.Next(20, 40), doneEvents[i]);
            fibArray[i] = f;
            ThreadPool.QueueUserWorkItem(f.ThreadPoolCallback, i);
        }

        // Wait for all threads in pool to calculate.
        WaitHandle.WaitAll(doneEvents);
        Console.WriteLine("All calculations are complete.");

        // Display the results.
        for (int i= 0; i<FibonacciCalculations; i++)
        {
            Fibonacci f = fibArray[i];
            Console.WriteLine("Fibonacci({0}) = {1}", f.N, f.FibOfN);
        }
    }
}
//</Snippet20>

