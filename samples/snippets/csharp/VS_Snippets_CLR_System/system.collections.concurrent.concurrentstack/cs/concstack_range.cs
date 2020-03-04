//<snippet1>
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

class Example
{
    // Demonstrates:
    //      ConcurrentStack<T>.PushRange();
    //      ConcurrentStack<T>.TryPopRange();
    static async Task Main()
    {
        int numParallelTasks = 4;
        int numItems = 1000;
        var stack = new ConcurrentStack<int>();

        // Push a range of values onto the stack concurrently
        await Task.WhenAll(Enumerable.Range(0, numParallelTasks).Select(i => Task.Factory.StartNew((state) =>
        {
            // state = i * numItems
            int index = (int)state;
            int[] array = new int[numItems];
            for (int j = 0; j < numItems; j++)
            {
                array[j] = index + j;
            }

            Console.WriteLine($"Pushing an array of ints from {array[0]} to {array[numItems - 1]}");
            stack.PushRange(array);
        }, i * numItems, CancellationToken.None, TaskCreationOptions.DenyChildAttach, TaskScheduler.Default)).ToArray());

        int numTotalElements = 4 * numItems;
        int[] resultBuffer = new int[numTotalElements];
        await Task.WhenAll(Enumerable.Range(0, numParallelTasks).Select(i => Task.Factory.StartNew(obj =>
        {
            int index = (int)obj;
            int result = stack.TryPopRange(resultBuffer, index, numItems);

            Console.WriteLine($"TryPopRange expected {numItems}, got {result}.");
        }, i * numItems, CancellationToken.None, TaskCreationOptions.LongRunning, TaskScheduler.Default)).ToArray());

        for (int i = 0; i < numParallelTasks; i++)
        {
            // Create a sequence we expect to see from the stack taking the last number of the range we inserted
            var expected = Enumerable.Range(resultBuffer[i*numItems + numItems - 1], numItems);

            // Take the range we inserted, reverse it, and compare to the expected sequence
            var areEqual = expected.SequenceEqual(resultBuffer.Skip(i * numItems).Take(numItems).Reverse());
            if (areEqual)
            {
                Console.WriteLine($"Expected a range of {expected.First()} to {expected.Last()}. Got {resultBuffer[i * numItems + numItems - 1]} to {resultBuffer[i * numItems]}");
            }
            else
            {
                Console.WriteLine($"Unexpected consecutive ranges.");
            }   
        }
    }
}
//</snippet1>
