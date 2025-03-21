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


	public static void Main()
	{	
		ArrayList samplesList = new ArrayList();

		SetupCategory();
        CreateCounters();
		CollectSamples(samplesList);
	}


    private static bool SetupCategory()
    {
        if ( !PerformanceCounterCategory.Exists("ElapsedTimeSampleCategory") )
        {

            CounterCreationDataCollection CCDC = new CounterCreationDataCollection();

            // Add the counter.
            CounterCreationData ETimeData = new CounterCreationData();
            ETimeData.CounterType = PerformanceCounterType.ElapsedTime;
            ETimeData.CounterName = "ElapsedTimeSample";
            CCDC.Add(ETimeData);	
		
            // Create the category.
            PerformanceCounterCategory.Create("ElapsedTimeSampleCategory",
                "Demonstrates usage of the ElapsedTime performance counter type.",
                CCDC);

            return(true);
        }
        else
        {
            Console.WriteLine("Category exists - ElapsedTimeSampleCategory");
            return(false);
        }
    }

    private static void CreateCounters()
    {
        // Create the counter.
        PC = new PerformanceCounter("ElapsedTimeSampleCategory",
            "ElapsedTimeSample",
            false);

    }

    private static void CollectSamples(ArrayList samplesList)
    {
	
        long pcValue;
        DateTime Start;

        // Initialize the counter.
        QueryPerformanceCounter(out pcValue);
        PC.RawValue = pcValue;
        Start = DateTime.Now;

        // Loop for the samples.
        for (int j = 0; j < 1000; j++)
        {
            // Output the values.
            if ((j % 10) == 9)
            {
                Console.WriteLine("NextValue() = " + PC.NextValue().ToString());
                Console.WriteLine("Actual elapsed time = " + DateTime.Now.Subtract(Start).ToString());
                OutputSample(PC.NextSample());
                samplesList.Add( PC.NextSample() );
            }

            // Reset the counter on 100th iteration.
            if (j % 100 == 0)
            {
                QueryPerformanceCounter(out pcValue);
                PC.RawValue = pcValue;
                Start = DateTime.Now;
            }
            System.Threading.Thread.Sleep(50);
        }

        Console.WriteLine("Elapsed time = " + DateTime.Now.Subtract(Start).ToString());
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


	// Reads the counter information to enable setting the RawValue.
	[DllImport("Kernel32.dll")]
	public static extern bool QueryPerformanceCounter(out long value);
}
//</snippet1>

#else
// Build sample for Whidbey or higher.

//<Snippet2>

using System;
using System.Diagnostics;
using System.Runtime.Versioning;

[SupportedOSPlatform("Windows")]
public class App
{
    public static void Main()
    {	
        CollectSamples();
    }

    public static void CollectSamples()
    {
        const String categoryName = "ElapsedTimeSampleCategory";
        const String counterName = "ElapsedTimeSample";

        // If the category does not exist, create the category and exit.
        // Performance counters should not be created and immediately used.
        // There is a latency time to enable the counters, they should be created
        // prior to executing the application that uses the counters.
        // Execute this sample a second time to use the category.
        if ( !PerformanceCounterCategory.Exists(categoryName) )
        {

            CounterCreationDataCollection CCDC = new CounterCreationDataCollection();

            // Add the counter.
            CounterCreationData ETimeData = new CounterCreationData();
            ETimeData.CounterType = PerformanceCounterType.ElapsedTime;
            ETimeData.CounterName = counterName;
            CCDC.Add(ETimeData);	
		
            // Create the category.
            PerformanceCounterCategory.Create(categoryName,
                    "Demonstrates ElapsedTime performance counter usage.",
                PerformanceCounterCategoryType.SingleInstance, CCDC);
            // Return, rerun the application to make use of the new counters.
            return;
        }
        else
        {
            Console.WriteLine($"Category exists - {categoryName}");
        }

        //<Snippet3>
        // Create the performance counter.
        PerformanceCounter PC = new PerformanceCounter(categoryName,
                                                       counterName,
                                                       false);
        // Initialize the counter.
        PC.RawValue = Stopwatch.GetTimestamp();
        //</Snippet3>

        DateTime Start = DateTime.Now;

        // Loop for the samples.
        for (int j = 0; j < 100; j++)
        {
            // Output the values.
            if ((j % 10) == 9)
            {
                Console.WriteLine("NextValue() = " + PC.NextValue().ToString());
                Console.WriteLine("Actual elapsed time = " + DateTime.Now.Subtract(Start).ToString());
                OutputSample(PC.NextSample());
            }

            // Reset the counter on every 20th iteration.
            if (j % 20 == 0)
            {
                PC.RawValue = Stopwatch.GetTimestamp();
                Start = DateTime.Now;
            }
            System.Threading.Thread.Sleep(50);
        }

        Console.WriteLine("Elapsed time = " + DateTime.Now.Subtract(Start).ToString());
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
//</Snippet2>
#endif
