//<snippet01>
using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        // Increase or decrease this value as desired.
        int itemsToAdd = 500;

        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            int width = Math.Max(Console.BufferWidth, 80);
            int height = Math.Max(Console.BufferHeight, itemsToAdd * 2 + 3);

            // Preserve all the display output for Adds and Takes
            Console.SetBufferSize(width, height);
        }

        // A bounded collection. Increase, decrease, or remove the
        // maximum capacity argument to see how it impacts behavior.
        var numbers = new BlockingCollection<int>(50);

        // A simple blocking consumer with no cancellation.
        Task.Run(() =>
        {
            int i = -1;
            while (!numbers.IsCompleted)
            {
                try
                {
                    i = numbers.Take();
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine("Adding was completed!");
                    break;
                }
                Console.WriteLine($"Take:{i} ");

                // Simulate a slow consumer. This will cause
                // collection to fill up fast and thus Adds wil block.
                Thread.SpinWait(100000);
            }

            Console.WriteLine("\r\nNo more items to take. Press the Enter key to exit.");
        });

        // A simple blocking producer with no cancellation.
        Task.Run(() =>
        {
            for (int i = 0; i < itemsToAdd; i++)
            {
                numbers.Add(i);
                Console.WriteLine($"Add:{i} Count={numbers.Count}");
            }

            // See documentation for this method.
            numbers.CompleteAdding();
        });

        // Keep the console display open in debug mode.
        Console.ReadLine();
    }
}
//</snippet01>
