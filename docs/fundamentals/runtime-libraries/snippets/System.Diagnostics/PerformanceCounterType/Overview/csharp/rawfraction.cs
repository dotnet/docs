//<snippet1>
using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.Versioning;

[SupportedOSPlatform("Windows")]
public class App5
{
    private static PerformanceCounter PC;
    private static PerformanceCounter BPC;

    public static void Main()
    {
        ArrayList samplesList = new ArrayList();

        // If the category does not exist, create the category and exit.
        // Performance counters should not be created and immediately used.
        // There is a latency time to enable the counters, they should be created
        // prior to executing the application that uses the counters.
        // Execute this sample a second time to use the counters.
        if (SetupCategory())
            return;
        CreateCounters();
        CollectSamples(samplesList);
        CalculateResults(samplesList);
    }

    private static bool SetupCategory()
    {

        if (!PerformanceCounterCategory.Exists("RawFractionSampleCategory"))
        {

            CounterCreationDataCollection CCDC = new CounterCreationDataCollection();

            // Add the counter.
            CounterCreationData rf = new CounterCreationData();
            rf.CounterType = PerformanceCounterType.RawFraction;
            rf.CounterName = "RawFractionSample";
            CCDC.Add(rf);

            // Add the base counter.
            CounterCreationData rfBase = new CounterCreationData();
            rfBase.CounterType = PerformanceCounterType.RawBase;
            rfBase.CounterName = "RawFractionSampleBase";
            CCDC.Add(rfBase);

            // Create the category.
            PerformanceCounterCategory.Create("RawFractionSampleCategory",
                "Demonstrates usage of the RawFraction performance counter type.",
                PerformanceCounterCategoryType.SingleInstance, CCDC);

            return (true);
        }
        else
        {
            Console.WriteLine("Category exists - RawFractionSampleCategory");
            return (false);
        }
    }

    private static void CreateCounters()
    {
        // Create the counters.
        PC = new PerformanceCounter("RawFractionSampleCategory",
            "RawFractionSample",
            false);

        BPC = new PerformanceCounter("RawFractionSampleCategory",
            "RawFractionSampleBase",
            false);

        PC.RawValue = 0;
        BPC.RawValue = 0;
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
            Console.Write(j + " = " + value);

            // Increment the base every time, because the counter measures the number
            // of high hits (raw fraction value) against all the hits (base value).
            BPC.Increment();

            // Get the % of samples that are 9 or 10 out of all the samples taken.
            if (value >= 9)
                PC.Increment();

            // Copy out the next value every ten times around the loop.
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
        for (int i = 0; i < samplesList.Count; i++)
        {
            // Output the sample.
            OutputSample((CounterSample)samplesList[i]);

            // Use .NET to calculate the counter value.
            Console.WriteLine(".NET computed counter value = " +
                CounterSampleCalculator.ComputeCounterValue((CounterSample)samplesList[i]));

            // Calculate the counter value manually.
            Console.WriteLine("My computed counter value = " +
                MyComputeCounterValue((CounterSample)samplesList[i]));
        }
    }

    //++++++++//++++++++//++++++++//++++++++//++++++++//++++++++//++++++++//++++++++
    // Formula from MSDN -
    //      Description - This counter type shows the ratio of a subset to its set as a percentage.
    //			For example, it compares the number of bytes in use on a disk to the
    //			total number of bytes on the disk. Counters of this type display the
    //			current percentage only, not an average over time.
    //
    // Generic type - Instantaneous, Percentage
    //	    Formula - (N0 / D0), where D represents a measured attribute and N represents one
    //			component of that attribute.
    //
    //		Average - SUM (N / D) /x
    //		Example - Paging File\% Usage Peak
    //++++++++//++++++++//++++++++//++++++++//++++++++//++++++++//++++++++//++++++++
    private static Single MyComputeCounterValue(CounterSample rfSample)
    {
        Single numerator = (Single)rfSample.RawValue;
        Single denomenator = (Single)rfSample.BaseValue;
        Single counterValue = (numerator / denomenator) * 100;
        return (counterValue);
    }

    // Output information about the counter sample.
    private static void OutputSample(CounterSample s)
    {
        Console.WriteLine("+++++++++++");
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
