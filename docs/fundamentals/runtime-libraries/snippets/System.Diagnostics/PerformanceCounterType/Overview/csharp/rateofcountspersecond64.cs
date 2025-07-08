//<snippet1>
using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.Versioning;

[SupportedOSPlatform("Windows")]
public class App4
{
    private static PerformanceCounter PC;

    public static void Main()
    {
        ArrayList samplesList = new ArrayList();

        // If the category does not exist, create the category and exit.
        // Perfomance counters should not be created and immediately used.
        // There is a latency time to enable the counters, they should be created
        // prior to executing the application that uses the counters.
        // Execute this sample a second time to use the category.
        if (SetupCategory())
            return;
        CreateCounters();
        CollectSamples(samplesList);
        CalculateResults(samplesList);
    }

    private static bool SetupCategory()
    {

        if (!PerformanceCounterCategory.Exists("RateOfCountsPerSecond64SampleCategory"))
        {

            CounterCreationDataCollection CCDC = new CounterCreationDataCollection();

            // Add the counter.
            CounterCreationData rateOfCounts64 = new CounterCreationData();
            rateOfCounts64.CounterType = PerformanceCounterType.RateOfCountsPerSecond64;
            rateOfCounts64.CounterName = "RateOfCountsPerSecond64Sample";
            CCDC.Add(rateOfCounts64);

            // Create the category.
            PerformanceCounterCategory.Create("RateOfCountsPerSecond64SampleCategory",
                "Demonstrates usage of the RateOfCountsPerSecond64 performance counter type.",
                PerformanceCounterCategoryType.SingleInstance, CCDC);
            return (true);
        }
        else
        {
            Console.WriteLine("Category exists - RateOfCountsPerSecond64SampleCategory");
            return (false);
        }
    }

    private static void CreateCounters()
    {
        // Create the counter.
        PC = new PerformanceCounter("RateOfCountsPerSecond64SampleCategory",
            "RateOfCountsPerSecond64Sample",
            false);

        PC.RawValue = 0;
    }

    private static void CollectSamples(ArrayList samplesList)
    {

        Random r = new Random(DateTime.Now.Millisecond);

        // Initialize the performance counter.
        PC.NextSample();

        // Loop for the samples.
        for (int j = 0; j < 100; j++)
        {

            int value = r.Next(1, 10);
            PC.IncrementBy(value);
            Console.Write(j + " = " + value);

            if ((j % 10) == 9)
            {
                Console.WriteLine(";       NextValue() = " + PC.NextValue().ToString());
                OutputSample(PC.NextSample());
                samplesList.Add(PC.NextSample());
            }
            else
            {
                Console.WriteLine();
            }

            System.Threading.Thread.Sleep(50);
        }
    }

    private static void CalculateResults(ArrayList samplesList)
    {
        for (int i = 0; i < (samplesList.Count - 1); i++)
        {
            // Output the sample.
            OutputSample((CounterSample)samplesList[i]);
            OutputSample((CounterSample)samplesList[i + 1]);

            // Use .NET to calculate the counter value.
            Console.WriteLine(".NET computed counter value = " +
                CounterSampleCalculator.ComputeCounterValue((CounterSample)samplesList[i],
                (CounterSample)samplesList[i + 1]));

            // Calculate the counter value manually.
            Console.WriteLine("My computed counter value = " +
                MyComputeCounterValue((CounterSample)samplesList[i],
                (CounterSample)samplesList[i + 1]));
        }
    }

    //++++++++//++++++++//++++++++//++++++++//++++++++//++++++++//++++++++//++++++++
    //	PERF_COUNTER_COUNTER
    //	Description	 - This counter type shows the average number of operations completed
    //		during each second of the sample interval. Counters of this type
    //		measure time in ticks of the system clock. The F variable represents
    //		the number of ticks per second. The value of F is factored into the
    //		equation so that the result can be displayed in seconds.
    //
    //	Generic type - Difference
    //
    //	Formula - (N1 - N0) / ( (D1 - D0) / F), where the numerator (N) represents the number
    //		of operations performed during the last sample interval, the denominator
    //		(D) represents the number of ticks elapsed during the last sample
    //		interval, and F is the frequency of the ticks.
    //
    //	Average - (Nx - N0) / ((Dx - D0) / F)
    //
    //  Example - System\ File Read Operations/sec
    //++++++++//++++++++//++++++++//++++++++//++++++++//++++++++//++++++++//++++++++
    private static Single MyComputeCounterValue(CounterSample s0, CounterSample s1)
    {
        Single numerator = (Single)(s1.RawValue - s0.RawValue);
        Single denomenator = (Single)(s1.TimeStamp - s0.TimeStamp) / (Single)s1.SystemFrequency;
        Single counterValue = numerator / denomenator;
        return (counterValue);
    }

    private static void OutputSample(CounterSample s)
    {
        Console.WriteLine("\r\n+++++++++++");
        Console.WriteLine("Sample values - \r\n");
        Console.WriteLine("   BaseValue        = " + s.BaseValue);
        Console.WriteLine("   CounterFrequency = " + s.CounterFrequency);
        Console.WriteLine("   CounterTimeStamp = " + s.CounterTimeStamp);
        Console.WriteLine("   CounterType      = " + s.CounterType);
        Console.WriteLine("   RawValue         = " + s.RawValue);
        Console.WriteLine("   SystemFrequency  = " + s.SystemFrequency);
        Console.WriteLine("   TimeStamp        = " + s.TimeStamp);
        Console.WriteLine("   TimeStamp100nSec = " + s.TimeStamp100nSec);
        Console.WriteLine("++++++++++++++++++++++");
    }
}

//</snippet1>
