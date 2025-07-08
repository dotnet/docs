// Notice that the sample is conditionally compiled for Everett vs.
// Whidbey builds.  Whidbey introduced new APIs that are not available
// in Everett.  Snippet IDs do not overlap between Whidbey and Everett;
// Snippet #1 is Everett, Snippet #2 and #3 are Whidbey.

#if (BELOW_WHIDBEY_BUILD)

//<snippet1>

using System;
using System.Collections;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Runtime.InteropServices;

public class App
{

	private static PerformanceCounter PC;
	private static PerformanceCounter BPC;

	public static void Main()
	{	
		ArrayList samplesList = new ArrayList();

		SetupCategory();
		CreateCounters();
		CollectSamples(samplesList);
		CalculateResults(samplesList);
	}


	
	
	private static bool SetupCategory()
	{
		
		if ( !PerformanceCounterCategory.Exists("AverageTimer32SampleCategory") )
		{

			CounterCreationDataCollection CCDC = new CounterCreationDataCollection();

			// Add the counter.
			CounterCreationData averageTimer32 = new CounterCreationData();
			averageTimer32.CounterType = PerformanceCounterType.AverageTimer32;
			averageTimer32.CounterName = "AverageTimer32Sample";
			CCDC.Add(averageTimer32);
	
	        // Add the base counter.
			CounterCreationData averageTimer32Base = new CounterCreationData();
			averageTimer32Base.CounterType = PerformanceCounterType.AverageBase;
			averageTimer32Base.CounterName = "AverageTimer32SampleBase";
			CCDC.Add(averageTimer32Base);

			// Create the category.
			PerformanceCounterCategory.Create("AverageTimer32SampleCategory",
				"Demonstrates usage of the AverageTimer32 performance counter type",
				CCDC);
				
			return(true);
		}
		else
		{
			Console.WriteLine("Category exists - " + "AverageTimer32SampleCategory");
			return(false);
		}
	}
	
	private static void CreateCounters()
	{
		// Create the counters.
		PC = new PerformanceCounter("AverageTimer32SampleCategory",
			"AverageTimer32Sample",
			false);
			
		BPC = new PerformanceCounter("AverageTimer32SampleCategory",
			"AverageTimer32SampleBase",
			false);
			
		PC.RawValue = 0;
		BPC.RawValue = 0;
	}
	

	private static void CollectSamples(ArrayList samplesList)
	{
		
		long perfTime = 0;
	    Random r = new Random( DateTime.Now.Millisecond );

	    // Loop for the samples.
	    for (int i = 0; i < 10; i++) {
	
			QueryPerformanceCounter(out perfTime);
			PC.RawValue = perfTime;
			
			BPC.IncrementBy(10);

	        System.Threading.Thread.Sleep(1000);
			Console.WriteLine("Next value = " + PC.NextValue().ToString());
			samplesList.Add(PC.NextSample());
	    }

    }

	private static void CalculateResults(ArrayList samplesList)
	{
		for(int i = 0; i < (samplesList.Count - 1); i++)
		{
			// Output the sample.
			OutputSample( (CounterSample)samplesList[i] );
			OutputSample( (CounterSample)samplesList[i+1] );

			// Use .NET to calculate the counter value.
			Console.WriteLine(".NET computed counter value = " +
				CounterSample.Calculate((CounterSample)samplesList[i],
				(CounterSample)samplesList[i+1]) );

			// Calculate the counter value manually.
			Console.WriteLine("My computed counter value = " +
				MyComputeCounterValue((CounterSample)samplesList[i],
				(CounterSample)samplesList[i+1]) );

		}
	}
	
	

    //++++++++//++++++++//++++++++//++++++++//++++++++//++++++++//+++++++
    // PERF_AVERAGE_TIMER
    //  Description - This counter type measures the time it takes, on
    //     average, to complete a process or operation. Counters of this
    //     type display a ratio of the total elapsed time of the sample
    //     interval to the number of processes or operations completed
    //     during that time. This counter type measures time in ticks
    //     of the system clock. The F variable represents the number of
    //     ticks per second. The value of F is factored into the equation
    //     so that the result can be displayed in seconds.
    //
    //  Generic type - Average
    //
    //  Formula - ((N1 - N0) / F) / (D1 - D0), where the numerator (N)
    //     represents the number of ticks counted during the last
    //     sample interval, F represents the frequency of the ticks,
    //     and the denominator (D) represents the number of operations
    //     completed during the last sample interval.
    //
    //  Average - ((Nx - N0) / F) / (Dx - D0)
    //
    //  Example - PhysicalDisk\ Avg. Disk sec/Transfer
    //++++++++//++++++++//++++++++//++++++++//++++++++//++++++++//+++++++
    private static Single MyComputeCounterValue(CounterSample s0, CounterSample s1)
	{
		Int64 n1 = s1.RawValue;
		Int64 n0 = s0.RawValue;
		ulong f = (ulong)s1.SystemFrequency;
		Int64 d1 = s1.BaseValue;
		Int64 d0 = s0.BaseValue;

		double numerator = (double)(n1 - n0);
		double denominator = (double)(d1 - d0);
		Single counterValue = (Single)(( numerator / f ) / denominator);
		return(counterValue);
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
	

	[DllImport("Kernel32.dll")]
	public static extern bool QueryPerformanceCounter(out long value);

}

//</snippet1>
#else
// Build sample for Whidbey or higher.

//<snippet2>
using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.Versioning;

[SupportedOSPlatform("Windows")]
public class App2
{
    private static PerformanceCounter PC;
    private static PerformanceCounter BPC;

    private const String categoryName = "AverageTimer32SampleCategory";
    private const String counterName = "AverageTimer32Sample";
    private const String baseCounterName = "AverageTimer32SampleBase";

    public static void Main()
    {
        ArrayList samplesList = new ArrayList();

        // If the category does not exist, create the category and exit.
        // Performance counters should not be created and immediately used.
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
        if (!PerformanceCounterCategory.Exists(categoryName))
        {

            CounterCreationDataCollection CCDC = new CounterCreationDataCollection();

            // Add the counter.
            CounterCreationData averageTimer32 = new CounterCreationData();
            averageTimer32.CounterType = PerformanceCounterType.AverageTimer32;
            averageTimer32.CounterName = counterName;
            CCDC.Add(averageTimer32);

            // Add the base counter.
            CounterCreationData averageTimer32Base = new CounterCreationData();
            averageTimer32Base.CounterType = PerformanceCounterType.AverageBase;
            averageTimer32Base.CounterName = baseCounterName;
            CCDC.Add(averageTimer32Base);

            // Create the category.
            PerformanceCounterCategory.Create(categoryName,
                "Demonstrates usage of the AverageTimer32 performance counter type",
                PerformanceCounterCategoryType.SingleInstance, CCDC);

            Console.WriteLine("Category created - " + categoryName);

            return (true);
        }
        else
        {
            Console.WriteLine("Category exists - " + categoryName);
            return (false);
        }
    }

    private static void CreateCounters()
    {
        // Create the counters.
        PC = new PerformanceCounter(categoryName,
                 counterName,
                 false);

        BPC = new PerformanceCounter(categoryName,
            baseCounterName,
            false);

        PC.RawValue = 0;
        BPC.RawValue = 0;
    }

    private static void CollectSamples(ArrayList samplesList)
    {

        Random r = new Random(DateTime.Now.Millisecond);

        // Loop for the samples.
        for (int i = 0; i < 10; i++)
        {

            PC.RawValue = Stopwatch.GetTimestamp();

            BPC.IncrementBy(10);

            System.Threading.Thread.Sleep(1000);

            Console.WriteLine("Next value = " + PC.NextValue().ToString());
            samplesList.Add(PC.NextSample());
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
                CounterSample.Calculate((CounterSample)samplesList[i],
                (CounterSample)samplesList[i + 1]));

            // Calculate the counter value manually.
            Console.WriteLine("My computed counter value = " +
                MyComputeCounterValue((CounterSample)samplesList[i],
                (CounterSample)samplesList[i + 1]));
        }
    }

    //++++++++//++++++++//++++++++//++++++++//++++++++//++++++++//+++++++
    // PERF_AVERAGE_TIMER
    //  Description - This counter type measures the time it takes, on
    //     average, to complete a process or operation. Counters of this
    //     type display a ratio of the total elapsed time of the sample
    //     interval to the number of processes or operations completed
    //     during that time. This counter type measures time in ticks
    //     of the system clock. The F variable represents the number of
    //     ticks per second. The value of F is factored into the equation
    //     so that the result can be displayed in seconds.
    //
    //  Generic type - Average
    //
    //  Formula - ((N1 - N0) / F) / (D1 - D0), where the numerator (N)
    //     represents the number of ticks counted during the last
    //     sample interval, F represents the frequency of the ticks,
    //     and the denominator (D) represents the number of operations
    //     completed during the last sample interval.
    //
    //  Average - ((Nx - N0) / F) / (Dx - D0)
    //
    //  Example - PhysicalDisk\ Avg. Disk sec/Transfer
    //++++++++//++++++++//++++++++//++++++++//++++++++//++++++++//+++++++
    private static Single MyComputeCounterValue(CounterSample s0, CounterSample s1)
    {
        Int64 n1 = s1.RawValue;
        Int64 n0 = s0.RawValue;
        ulong f = (ulong)s1.SystemFrequency;
        Int64 d1 = s1.BaseValue;
        Int64 d0 = s0.BaseValue;

        double numerator = (double)(n1 - n0);
        double denominator = (double)(d1 - d0);
        Single counterValue = (Single)((numerator / f) / denominator);
        return (counterValue);
    }

    // Output information about the counter sample.
    private static void OutputSample(CounterSample s)
    {
        Console.WriteLine("+++++++++++");
        Console.WriteLine("Sample values - \r\n");
        Console.WriteLine("   CounterType      = " + s.CounterType);
        Console.WriteLine("   RawValue         = " + s.RawValue);
        Console.WriteLine("   BaseValue        = " + s.BaseValue);
        Console.WriteLine("   CounterFrequency = " + s.CounterFrequency);
        Console.WriteLine("   CounterTimeStamp = " + s.CounterTimeStamp);
        Console.WriteLine("   SystemFrequency  = " + s.SystemFrequency);
        Console.WriteLine("   TimeStamp        = " + s.TimeStamp);
        Console.WriteLine("   TimeStamp100nSec = " + s.TimeStamp100nSec);
        Console.WriteLine("++++++++++++++++++++++");
    }
}

//</snippet2>

#endif
