//<snippet02>
using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

class ProgramWithCancellation
{
    static int inputs = 2000;

    static void Main()
    {
        // The token source for issuing the cancelation request.
        var cts = new CancellationTokenSource();

        // A blocking collection that can hold no more than 100 items at a time.
        var numberCollection = new BlockingCollection<int>(100);

        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            int width = Math.Max(Console.BufferWidth, 80);
            int height = Math.Max(Console.BufferHeight, 8000);

            // Preserve all the display output for Adds and Takes
            Console.SetBufferSize(width, height);
        }

        // The simplest UI thread ever invented.
        Task.Run(() =>
        {
            if (Console.ReadKey(true).KeyChar == 'c')
            {
                cts.Cancel();
            }
        });

        // Start one producer and one consumer.
        Task t1 = Task.Run(() => NonBlockingConsumer(numberCollection, cts.Token));
        Task t2 = Task.Run(() => NonBlockingProducer(numberCollection, cts.Token));

        // Wait for the tasks to complete execution
        Task.WaitAll(t1, t2);

        cts.Dispose();
        Console.WriteLine("Press the Enter key to exit.");
        Console.ReadLine();
    }

    static void NonBlockingConsumer(BlockingCollection<int> bc, CancellationToken ct)
    {
        // IsCompleted == (IsAddingCompleted && Count == 0)
        while (!bc.IsCompleted)
        {
            int nextItem = 0;
            try
            {
                if (!bc.TryTake(out nextItem, 0, ct))
                {
                    Console.WriteLine(" Take Blocked");
                }
                else
                {
                    Console.WriteLine($" Take:{nextItem}");
                }
            }

            catch (OperationCanceledException)
            {
                Console.WriteLine("Taking canceled.");
                break;
            }

            // Slow down consumer just a little to cause
            // collection to fill up faster, and lead to "AddBlocked"
            Thread.SpinWait(500000);
        }

        Console.WriteLine("\r\nNo more items to take.");
    }

    static void NonBlockingProducer(BlockingCollection<int> bc, CancellationToken ct)
    {
        int itemToAdd = 0;
        bool success = false;

        do
        {
            // Cancellation causes OCE. We know how to handle it.
            try
            {
                // A shorter timeout causes more failures.
                success = bc.TryAdd(itemToAdd, 2, ct);
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Add loop canceled.");
                // Let other threads know we're done in case
                // they aren't monitoring the cancellation token.
                bc.CompleteAdding();
                break;
            }

            if (success)
            {
                Console.WriteLine($" Add:{itemToAdd}");
                itemToAdd++;
            }
            else
            {
                Console.Write(" AddBlocked:{0} Count = {1}", itemToAdd.ToString(), bc.Count);
                // Don't increment nextItem. Try again on next iteration.

                //Do something else useful instead.
                UpdateProgress(itemToAdd);
            }
        } while (itemToAdd < inputs);

        // No lock required here because only one producer.
        bc.CompleteAdding();
    }

    static void UpdateProgress(int i)
    {
        double percent = ((double)i / inputs) * 100;
        Console.WriteLine($"Percent complete: {percent}");
    }
}
//</snippet02>