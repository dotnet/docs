// <Snippet19>
using System;
using System.Diagnostics;
using System.Linq;

class ExampleMeasure
{
    static void Main()
    {
        var source = Enumerable.Range(0, 3000000);

        var queryToMeasure =
             from num in source.AsParallel()
             where num % 3 == 0
             select Math.Sqrt(num);

        Console.WriteLine("Measuring...");

        // The query does not run until it is enumerated.
        // Therefore, start the timer here.
        var sw = Stopwatch.StartNew();

        // For pure query cost, enumerate and do nothing else.
        foreach (var n in queryToMeasure) { }

        sw.Stop();
        long elapsed = sw.ElapsedMilliseconds; // or sw.ElapsedTicks
        Console.WriteLine($"Total query time: {elapsed} ms");

        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }
}
// </Snippet19>
