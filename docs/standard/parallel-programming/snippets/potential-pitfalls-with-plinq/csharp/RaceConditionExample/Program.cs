using System;
using System.Linq;
using System.Threading;

class RaceConditionExample
{
    static void Main()
    {
        Console.WriteLine("=== Race Condition Example ===");
        DemonstrateRaceCondition();
        
        Console.WriteLine("\n=== Fixed Version ===");
        DemonstrateCorrectApproach();
    }

    // <RaceConditionBad>
    static void DemonstrateRaceCondition()
    {
        int total = 0;
        var numbers = Enumerable.Range(0, 10000);

        // UNSAFE: Multiple threads writing to shared variable
        numbers.AsParallel().ForAll(n => total += n);

        Console.WriteLine($"Total (with race condition): {total}");
        // Expected: 49,995,000 but result is unpredictable due to race condition
    }
    // </RaceConditionBad>

    // <RaceConditionGood>
    static void DemonstrateCorrectApproach()
    {
        var numbers = Enumerable.Range(0, 10000);

        // SAFE: Use thread-safe aggregate operation
        int total = numbers.AsParallel().Sum();

        Console.WriteLine($"Total (correct): {total}");
        // Result is always 49,995,000
    }
    // </RaceConditionGood>
}
