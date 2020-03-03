//<Snippet1>
using System;
using System.Threading;

public class Fibonacci
{
    private ManualResetEvent _doneEvent;

    public Fibonacci(int n, ManualResetEvent doneEvent)
    {
        N = n;
        _doneEvent = doneEvent;
    }

    public int N { get; }

    public int FibOfN { get; private set; }

    public void ThreadPoolCallback(Object threadContext)
    {
        int threadIndex = (int)threadContext;
        Console.WriteLine($"Thread {threadIndex} started...");
        FibOfN = Calculate(N);
        Console.WriteLine($"Thread {threadIndex} result calculated...");
        _doneEvent.Set();
    }

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
        const int FibonacciCalculations = 5;

        var doneEvents = new ManualResetEvent[FibonacciCalculations];
        var fibArray = new Fibonacci[FibonacciCalculations];
        var rand = new Random();

        Console.WriteLine($"Launching {FibonacciCalculations} tasks...");
        for (int i = 0; i < FibonacciCalculations; i++)
        {
            doneEvents[i] = new ManualResetEvent(false);
            var f = new Fibonacci(rand.Next(20, 40), doneEvents[i]);
            fibArray[i] = f;
            ThreadPool.QueueUserWorkItem(f.ThreadPoolCallback, i);
        }

        WaitHandle.WaitAll(doneEvents);
        Console.WriteLine("All calculations are complete.");

        for (int i = 0; i < FibonacciCalculations; i++)
        {
            Fibonacci f = fibArray[i];
            Console.WriteLine($"Fibonacci({f.N}) = {f.FibOfN}");
        }
    }
}
// The output is similar to:
// Launching 5 tasks...
// Thread 3 started...
// Thread 4 started...
// Thread 2 started...
// Thread 1 started...
// Thread 0 started...
// Thread 2 result calculated...
// Thread 3 result calculated...
// Thread 4 result calculated...
// Thread 1 result calculated...
// Thread 0 result calculated...
// All calculations are complete.
// Fibonacci(35) = 9227465
// Fibonacci(27) = 196418
// Fibonacci(25) = 75025
// Fibonacci(25) = 75025
// Fibonacci(27) = 196418
//</Snippet1>