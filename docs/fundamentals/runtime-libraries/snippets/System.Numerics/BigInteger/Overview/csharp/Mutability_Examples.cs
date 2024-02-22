using System;
using System.Diagnostics;
using System.Numerics;

public class MutabilityEx
{
    public static void Main()
    {
        ShowSimpleAdd();
        PerformBigIntegerOperation();
        PerformWithIntermediary();
    }

    private static void ShowSimpleAdd()
    {
        // <Snippet1>
        BigInteger number = BigInteger.Multiply(Int64.MaxValue, 3);
        number++;
        Console.WriteLine(number);
        // </Snippet1>
    }

    private static void PerformBigIntegerOperation()
    {
        Stopwatch sw = Stopwatch.StartNew();

        // <Snippet12>
        BigInteger number = Int64.MaxValue ^ 5;
        int repetitions = 1000000;
        // Perform some repetitive operation 1 million times.
        for (int ctr = 0; ctr <= repetitions; ctr++)
        {
            // Perform some operation. If it fails, exit the loop.
            if (!SomeOperationSucceeds()) break;
            // The following code executes if the operation succeeds.
            number++;
        }
        // </Snippet12>

        sw.Stop();
        Console.WriteLine("Incrementing a BigInteger: " + sw.Elapsed.ToString());
    }

    private static void PerformWithIntermediary()
    {
        Stopwatch sw = Stopwatch.StartNew();

        // <Snippet3>
        BigInteger number = Int64.MaxValue ^ 5;
        int repetitions = 1000000;
        int actualRepetitions = 0;
        // Perform some repetitive operation 1 million times.
        for (int ctr = 0; ctr <= repetitions; ctr++)
        {
            // Perform some operation. If it fails, exit the loop.
            if (!SomeOperationSucceeds()) break;
            // The following code executes if the operation succeeds.
            actualRepetitions++;
        }
        number += actualRepetitions;
        // </Snippet3>

        sw.Stop();
        Console.WriteLine("Incrementing a BigInteger: " + sw.Elapsed.ToString());
    }

    private static bool SomeOperationSucceeds()
    {
        return true;
    }
}

// <Snippet2>
// CAPS bug: snippet2 is seen as duplicated, even though it isn't.
// </Snippet2>
