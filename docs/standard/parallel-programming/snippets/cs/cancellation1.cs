using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public class CancellationExample
{
    public static async Task Main()
    {
        var random = new Random();
        using var cts = new CancellationTokenSource();
        CancellationToken token = cts.Token;
        var timer = new Timer(Elapsed, cts, 5000, Timeout.Infinite);

        var task = Task.Run(
            () =>
            {
                var product33 = new List<int>();
                for (int ctr = 1; ctr < short.MaxValue; ctr++)
                {
                    if (token.IsCancellationRequested)
                    {
                        Console.WriteLine("\nCancellation requested in antecedent...\n");
                        token.ThrowIfCancellationRequested();
                    }
                    if (ctr % 2000 == 0)
                    {
                        int delay = random.Next(16, 501);
                        Thread.Sleep(delay);
                    }
                    if (ctr % 33 == 0)
                    {
                        product33.Add(ctr);
                    }
            }

            return product33.ToArray();
        }, token);

        Task continuation = task.ContinueWith(
            antecedent =>
            {
                Console.WriteLine("Multiples of 33:\n");
                int[] arr = antecedent.Result;
                for (int ctr = 0; ctr < arr.Length; ctr++)
                {
                    if (token.IsCancellationRequested)
                    {
                        Console.WriteLine("\nCancellation requested in continuation...\n");
                        token.ThrowIfCancellationRequested();
                    }
                    if (ctr % 100 == 0)
                    {
                        int delay = random.Next(16, 251);
                        Thread.Sleep(delay);
                    }

                    Console.Write($"{arr[ctr]:N0}{(ctr != arr.Length - 1 ? ", " : "")}");

                    if (Console.CursorLeft >= 74)
                    {
                        Console.WriteLine();
                    }
            }
            Console.WriteLine();
        }, token);

        try
        {
            await continuation;
        }
        catch (AggregateException e)
        {
            foreach (Exception ie in e.InnerExceptions)
            {
                Console.WriteLine($"{ie.GetType().Name}: {ie.Message}");
            }
        }

        Console.WriteLine("\nAntecedent Status: {0}", task.Status);
        Console.WriteLine("Continuation Status: {0}", continuation.Status);
    }

    static void Elapsed(object state)
    {
        if (state is CancellationTokenSource cts)
        {
            cts.Cancel();
            Console.WriteLine("\nCancellation request issued...\n");
        }
    }
}
// The example displays the following output:
//    Multiples of 33:
//
//    33, 66, 99, 132, 165, 198, 231, 264, 297, 330, 363, 396, 429, 462, 495, 528,
//    561, 594, 627, 660, 693, 726, 759, 792, 825, 858, 891, 924, 957, 990, 1,023,
//    1,056, 1,089, 1,122, 1,155, 1,188, 1,221, 1,254, 1,287, 1,320, 1,353, 1,386,
//    1,419, 1,452, 1,485, 1,518, 1,551, 1,584, 1,617, 1,650, 1,683, 1,716, 1,749,
//    1,782, 1,815, 1,848, 1,881, 1,914, 1,947, 1,980, 2,013, 2,046, 2,079, 2,112,
//    2,145, 2,178, 2,211, 2,244, 2,277, 2,310, 2,343, 2,376, 2,409, 2,442, 2,475,
//    2,508, 2,541, 2,574, 2,607, 2,640, 2,673, 2,706, 2,739, 2,772, 2,805, 2,838,
//    2,871, 2,904, 2,937, 2,970, 3,003, 3,036, 3,069, 3,102, 3,135, 3,168, 3,201,
//    3,234, 3,267, 3,300, 3,333, 3,366, 3,399, 3,432, 3,465, 3,498, 3,531, 3,564,
//    Cancellation requested in continuation...
//
//
//    Cancellation request issued...
//
//    TaskCanceledException: A task was canceled.
//
//    Antecedent Status: RanToCompletion
//    Continuation Status: Canceled
