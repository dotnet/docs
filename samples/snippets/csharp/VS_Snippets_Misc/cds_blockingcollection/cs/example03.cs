//<snippet03>
using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

class Example
{
    // Limit the collection size to 2000 items at any given time.
    // Set itemsToProduce to > 500 to hit the limit.
    const int UpperLimit = 1000;

    // Adjust this number to see how it impacts the producing-consuming pattern.
    const int ItemsToProduce = 100;

    static readonly BlockingCollection<long> Collection =
        new BlockingCollection<long>(UpperLimit);

    // Variables for diagnostic output only.
    static readonly Stopwatch Stopwatch = new Stopwatch();
    static int TotalAdditions = 0;

    static async Task Main()
    {
        Stopwatch.Start();

        // Queue the consumer task.
        var consumerTask = Task.Run(() => RunConsumer());

        // Queue the producer tasks.
        var produceTaskOne = Task.Run(() => RunProducer("A", 0));
        var produceTaskTwo = Task.Run(() => RunProducer("B", ItemsToProduce));
        var producerTasks = new[] { produceTaskOne , produceTaskTwo };

        // Create a cleanup task that will call CompleteAdding after
        // all producers are done adding items.
        var cleanupTask = Task.Factory.ContinueWhenAll(producerTasks, _ => Collection.CompleteAdding());

        // Wait for all tasks to complete
        await Task.WhenAll(consumerTask, produceTaskOne, produceTaskTwo, cleanupTask);

        // Keep the console window open while the
        // consumer thread completes its output.
        Console.WriteLine("Press any key to exit");
        Console.ReadKey(true);
    }

    static void RunProducer(string id, int start)
    {
        var additions = 0;
        for (var i = start; i < start + ItemsToProduce; i++)
        {
            // The data that is added to the collection.
            var ticks = Stopwatch.ElapsedTicks;

            // Display additions and subtractions.
            Console.WriteLine($"{id} adding tick value {ticks}. item# {i}");

            if (!Collection.IsAddingCompleted)
            {
                Collection.Add(ticks);
            }

            // Counter for demonstration purposes only.
            additions++;

            // Comment this line to speed up the producer threads.
            Thread.SpinWait(100000);
        }

        Interlocked.Add(ref TotalAdditions, additions);
        Console.WriteLine($"{id} is done adding: {additions} items");
    }

    static void RunConsumer()
    {
        // GetConsumingEnumerable returns the enumerator for the underlying collection.
        var subtractions = 0;
        foreach (var item in Collection.GetConsumingEnumerable())
        {
            Console.WriteLine(
                $"Consuming tick value {item:D18} : item# {subtractions++} : current count = {Collection.Count}");
        }

        Console.WriteLine(
            $"Total added: {TotalAdditions} Total consumed: {subtractions} Current count: {Collection.Count}");

        Stopwatch.Stop();
    }
}
//</snippet03>
