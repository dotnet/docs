// <Snippet3>
using System;
using System.Threading;

public class Example13
{
    [ThreadStatic] static double previous = 0.0;
    [ThreadStatic] static int perThreadCtr = 0;
    [ThreadStatic] static double perThreadTotal = 0.0;
    static CancellationTokenSource source;
    static CountdownEvent countdown;
    static Object randLock, numericLock;
    static Random rand;
    double totalValue = 0.0;
    int totalCount = 0;

    public Example13()
    {
        rand = new Random();
        randLock = new Object();
        numericLock = new Object();
        countdown = new CountdownEvent(1);
        source = new CancellationTokenSource();
    }

    public static void Main()
    {
        Example13 ex = new Example13();
        Thread.CurrentThread.Name = "Main";
        ex.Execute();
    }

    private void Execute()
    {
        CancellationToken token = source.Token;

        for (int threads = 1; threads <= 10; threads++)
        {
            Thread newThread = new Thread(this.GetRandomNumbers);
            newThread.Name = threads.ToString();
            newThread.Start(token);
        }
        this.GetRandomNumbers(token);

        countdown.Signal();
        // Make sure all threads have finished.
        countdown.Wait();
        source.Dispose();

        Console.WriteLine($"\nTotal random numbers generated: {totalCount:N0}");
        Console.WriteLine($"Total sum of all random numbers: {totalValue:N2}");
        Console.WriteLine($"Random number mean: {totalValue / totalCount:N4}");
    }

    private void GetRandomNumbers(Object o)
    {
        CancellationToken token = (CancellationToken)o;
        double result = 0.0;
        countdown.AddCount(1);

        try
        {
            for (int ctr = 0; ctr < 2000000; ctr++)
            {
                // Make sure there's no corruption of Random.
                token.ThrowIfCancellationRequested();

                lock (randLock)
                {
                    result = rand.NextDouble();
                }
                // Check for corruption of Random instance.
                if ((result == previous) && result == 0)
                {
                    source.Cancel();
                }
                else
                {
                    previous = result;
                }
                perThreadCtr++;
                perThreadTotal += result;
            }

            Console.WriteLine($"Thread {Thread.CurrentThread.Name} finished execution.");
            Console.WriteLine($"Random numbers generated: {perThreadCtr:N0}");
            Console.WriteLine($"Sum of random numbers: {perThreadTotal:N2}");
            Console.WriteLine($"Random number mean: {perThreadTotal / perThreadCtr:N4}\n");

            // Update overall totals.
            lock (numericLock)
            {
                totalCount += perThreadCtr;
                totalValue += perThreadTotal;
            }
        }
        catch (OperationCanceledException e)
        {
            Console.WriteLine($"Corruption in Thread {Thread.CurrentThread.Name}");
        }
        finally
        {
            countdown.Signal();
        }
    }
}
// The example displays output like the following:
//       Thread 6 finished execution.
//       Random numbers generated: 2,000,000
//       Sum of random numbers: 1,000,491.05
//       Random number mean: 0.5002
//
//       Thread 10 finished execution.
//       Random numbers generated: 2,000,000
//       Sum of random numbers: 999,329.64
//       Random number mean: 0.4997
//
//       Thread 4 finished execution.
//       Random numbers generated: 2,000,000
//       Sum of random numbers: 1,000,166.89
//       Random number mean: 0.5001
//
//       Thread 8 finished execution.
//       Random numbers generated: 2,000,000
//       Sum of random numbers: 999,628.37
//       Random number mean: 0.4998
//
//       Thread Main finished execution.
//       Random numbers generated: 2,000,000
//       Sum of random numbers: 999,920.89
//       Random number mean: 0.5000
//
//       Thread 3 finished execution.
//       Random numbers generated: 2,000,000
//       Sum of random numbers: 999,370.45
//       Random number mean: 0.4997
//
//       Thread 7 finished execution.
//       Random numbers generated: 2,000,000
//       Sum of random numbers: 999,330.92
//       Random number mean: 0.4997
//
//       Thread 9 finished execution.
//       Random numbers generated: 2,000,000
//       Sum of random numbers: 1,000,172.79
//       Random number mean: 0.5001
//
//       Thread 5 finished execution.
//       Random numbers generated: 2,000,000
//       Sum of random numbers: 1,000,079.43
//       Random number mean: 0.5000
//
//       Thread 1 finished execution.
//       Random numbers generated: 2,000,000
//       Sum of random numbers: 999,817.91
//       Random number mean: 0.4999
//
//       Thread 2 finished execution.
//       Random numbers generated: 2,000,000
//       Sum of random numbers: 999,930.63
//       Random number mean: 0.5000
//
//
//       Total random numbers generated: 22,000,000
//       Total sum of all random numbers: 10,998,238.98
//       Random number mean: 0.4999
// </Snippet3>
