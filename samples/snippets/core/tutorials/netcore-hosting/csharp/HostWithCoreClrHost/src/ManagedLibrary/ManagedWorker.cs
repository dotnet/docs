using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;

namespace ManagedLibrary
{
    // Sample managed code for the host to call
    public class ManagedWorker
    {
        // This assembly is being built as an exe as a simple way to
        // get .NET Core runtime libraries deployed (`dotnet publish` will
        // publish .NET Core libraries for exes). Therefore, this assembly
        // requires an entry point method even though it is unused.
        public static void Main()
        {
            Console.WriteLine("This assembly is not meant to be run directly.");
            Console.WriteLine("Instead, please use the SampleHost process to load this assembly.");
        }

        public delegate int ReportProgressFunction(int progress);

        // This test method doesn't actually do anything, it just takes some input parameters,
        // waits (in a loop) for a bit, invoking the callback function periodically, and
        // then returns a string version of the double[] passed in.
        [return: MarshalAs(UnmanagedType.LPStr)]
        public static string DoWork(
            [MarshalAs(UnmanagedType.LPStr)] string jobName,
            int iterations,
            int dataSize,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] double[] data,
            ReportProgressFunction reportProgressFunction)
        {
            for (int i = 1; i <= iterations; i++)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Beginning work iteration {i}");
                Console.ResetColor();

                // Pause as if doing work
                Thread.Sleep(1000);

                // Call the native callback and write its return value to the console
                var progressResponse = reportProgressFunction(i);
                Console.WriteLine($"Received response [{progressResponse}] from progress function");
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Work completed");
            Console.ResetColor();

            return $"Data received: {string.Join(", ", data.Select(d => d.ToString()))}";
        }
    }
}
