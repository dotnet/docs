using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

public class CancellationExample
{
    static readonly Random s_random = new Random((int)DateTime.Now.Ticks);

    public static async Task Main()
    {
        using var cts = new CancellationTokenSource();
        CancellationToken token = cts.Token;
        var timer = new Timer(Elapsed, cts, 5000, Timeout.Infinite);

        var task = Task.Run(
            async () =>
            {
                var product33 = new List<int>();
                for (int index = 1; index < short.MaxValue; index++)
                {
                    if (token.IsCancellationRequested)
                    {
                        Console.WriteLine("\nCancellation requested in antecedent...\n");
                        token.ThrowIfCancellationRequested();
                    }
                    if (index % 2000 == 0)
                    {
                        int delay = s_random.Next(16, 501);
                        await Task.Delay(delay);
                    }
                    if (index % 33 == 0)
                    {
                        product33.Add(index);
                    }
                }

                return product33.ToArray();
            }, token);

        Task<double> continuation = task.ContinueWith(
            async antecedent =>
            {
                Console.WriteLine("Multiples of 33:\n");
                int[] array = antecedent.Result;
                for (int index = 0; index < array.Length; index++)
                {
                    if (token.IsCancellationRequested)
                    {
                        Console.WriteLine("\nCancellation requested in continuation...\n");
                        token.ThrowIfCancellationRequested();
                    }
                    if (index % 100 == 0)
                    {
                        int delay = s_random.Next(16, 251);
                        await Task.Delay(delay);
                    }

                    Console.Write($"{array[index]:N0}{(index != array.Length - 1 ? ", " : "")}");

                    if (Console.CursorLeft >= 74)
                    {
                        Console.WriteLine();
                    }
                }
                Console.WriteLine();
                return array.Average();
            }, token).Unwrap();

        try
        {
            await task;
            double result = await continuation;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine($"\nAntecedent Status: {task.Status}");
        Console.WriteLine($"Continuation Status: {continuation.Status}");
    }

    static void Elapsed(object? state)
    {
        if (state is CancellationTokenSource cts)
        {
            cts.Cancel();
            Console.WriteLine("\nCancellation request issued...\n");
        }
    }
}
// The example displays the similar output:
//     Multiples of 33:
//     
//     33, 66, 99, 132, 165, 198, 231, 264, 297, 330, 363, 396, 429, 462, 495, 528,
//     561, 594, 627, 660, 693, 726, 759, 792, 825, 858, 891, 924, 957, 990, 1,023,
//     1,056, 1,089, 1,122, 1,155, 1,188, 1,221, 1,254, 1,287, 1,320, 1,353, 1,386,
//     1,419, 1,452, 1,485, 1,518, 1,551, 1,584, 1,617, 1,650, 1,683, 1,716, 1,749,
//     1,782, 1,815, 1,848, 1,881, 1,914, 1,947, 1,980, 2,013, 2,046, 2,079, 2,112,
//     2,145, 2,178, 2,211, 2,244, 2,277, 2,310, 2,343, 2,376, 2,409, 2,442, 2,475,
//     2,508, 2,541, 2,574, 2,607, 2,640, 2,673, 2,706, 2,739, 2,772, 2,805, 2,838,
//     2,871, 2,904, 2,937, 2,970, 3,003, 3,036, 3,069, 3,102, 3,135, 3,168, 3,201,
//     3,234, 3,267, 3,300, 3,333, 3,366, 3,399, 3,432, 3,465, 3,498, 3,531, 3,564,
//     3,597, 3,630, 3,663, 3,696, 3,729, 3,762, 3,795, 3,828, 3,861, 3,894, 3,927,
//     3,960, 3,993, 4,026, 4,059, 4,092, 4,125, 4,158, 4,191, 4,224, 4,257, 4,290,
//     4,323, 4,356, 4,389, 4,422, 4,455, 4,488, 4,521, 4,554, 4,587, 4,620, 4,653,
//     4,686, 4,719, 4,752, 4,785, 4,818, 4,851, 4,884, 4,917, 4,950, 4,983, 5,016,
//     5,049, 5,082, 5,115, 5,148, 5,181, 5,214, 5,247, 5,280, 5,313, 5,346, 5,379,
//     5,412, 5,445, 5,478, 5,511, 5,544, 5,577, 5,610, 5,643, 5,676, 5,709, 5,742,
//     Cancellation request issued...
//
//     5,775,
//     Cancellation requested in continuation...
//       
//     The operation was canceled.
//       
//     Antecedent Status: RanToCompletion
//     Continuation Status: Canceled
